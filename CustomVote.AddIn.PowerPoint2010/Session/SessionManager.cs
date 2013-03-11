using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CustomVote.AddIn.PowerPoint2010.Questions.Data;
using CustomVote.AddIn.PowerPoint2010.Helpers;
using CustomVote.AddIn.PowerPoint2010.Results.Data;
using System.Windows.Forms;

namespace CustomVote.AddIn.PowerPoint2010.Session
{
    [Serializable]
    public class SessionManager
    {
        public  SessionManager() 
        {
            QuestionSlideConfigurations = new List<QuestionSlideConfiguration>();
            ResultSlideConfigurations = new List<ResultSlideConfiguration>();
            Globals.ThisAddIn.Application.PresentationNewSlide += new Microsoft.Office.Interop.PowerPoint.EApplication_PresentationNewSlideEventHandler(Application_PresentationNewSlide);
            this.HardwareConfiguration = new HardwareConfiguration();
        }

        public HardwareConfiguration HardwareConfiguration { get; set; }

        void Application_PresentationNewSlide(Microsoft.Office.Interop.PowerPoint.Slide Sld)
        {
            var questionSlide = QuestionSlideConfigurations.Where(x => x.SlideId == Sld.SlideID).FirstOrDefault();
            if (questionSlide != null)
                QuestionSlideConfigurations.Remove(questionSlide);

            var resultSlide = ResultSlideConfigurations.Where(x => x.SlideId == Sld.SlideID).FirstOrDefault();
            if (resultSlide != null)
                ResultSlideConfigurations.Remove(resultSlide);
        }
        public List<QuestionSlideConfiguration> QuestionSlideConfigurations { get; private set; }
        private List<ResultSlideConfiguration> ResultSlideConfigurations { get; set; }

        public QuestionSlideConfiguration GetQuestionSlideConfiguration(int slideId)
        {
            QuestionSlideConfiguration config = QuestionSlideConfigurations.Where(x => x.SlideId == slideId).FirstOrDefault();
            if (config == null)
                config = QuestionSlideConfiguration.GenerateDefaultConfig(slideId);

            if (!config.IsNew)
                config.UpdateUserChanges();

            return config;
        }

        internal bool IsQuestionSlide(int slideId)
        {
            return (QuestionSlideConfigurations.Where(x => x.SlideId == slideId).Any() &&
                    !ResultSlideConfigurations.Where(x => x.SlideId == slideId).Any()) ||
                    (!QuestionSlideConfigurations.Where(x => x.SlideId == slideId).Any() &&
                    !ResultSlideConfigurations.Where(x => x.SlideId == slideId).Any());
        }
        internal bool IsResultSlide(int slideId)
        {
            return (ResultSlideConfigurations.Where(x => x.SlideId == slideId).Any() &&
                    !QuestionSlideConfigurations.Where(x => x.SlideId == slideId).Any()) ||
                    (!QuestionSlideConfigurations.Where(x => x.SlideId == slideId).Any() &&
                    !ResultSlideConfigurations.Where(x => x.SlideId == slideId).Any());
        }

        internal void SaveQuestionConfiguration(QuestionSlideConfiguration config)
        {
            config.IsNew = false;
            QuestionSlideConfigurations.Add(config);
        }

        public List<ItemList> GetQuestionList()
        {
            List<ItemList> lst = new List<ItemList>();

            foreach (var q in QuestionSlideConfigurations)
            {
                q.UpdateUserChanges();
                lst.Add(new ItemList() { Id = q.SlideId, Name = q.QuetionTitle });
            }

            return lst;
        }

        internal void SaveResultConfiguration(ResultSlideConfiguration resultConfig)
        {
            resultConfig.IsNew = false;
            this.ResultSlideConfigurations.Add(resultConfig);
        }

        internal ResultSlideConfiguration GetResultSlideConfiguration(int slideId)
        {
            var resultConfig = this.ResultSlideConfigurations.Where(x => x.SlideId == slideId).FirstOrDefault();
            if (resultConfig == null)
                return new ResultSlideConfiguration() 
                { 
                    SlideId = slideId,
                    ResultType = ResultType.Normal,
                    Valuetype = HistValueType.Porcentual,
                    ValueOrder = HistValueOrder.Ninguno,
                    HistWidthPercent = 20,
                    SelectedQuestions = new List<SelectedQuetions>(),
                    RankingConfig = new RankingConfig(),
                    CrossCompConfig = new CrossComparizonConfig(),
                    NormalConfig = new NormalConfig()
                };
            return resultConfig;
        }

        internal void SaveVotes(Hardware.KeyStatusValues keyStatusValues, int slideId)
        {
            var q = GetQuestionSlideConfiguration(slideId);
            var array = (new string[10] { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J" }).ToList();

            foreach (var vote in keyStatusValues.GetValues())
            {
                int index = array.IndexOf(vote.Value.KeyValue);
                if (index < q.Answers.Count)
                {
                    q.Answers[index].VotesCount++;
                    q.Answers[index].Votes.Add(new Hardware.VotesFlat(vote));
                    if (q.Answers[index].Time < vote.Value.Keytime)
                        q.Answers[index].Time = vote.Value.Keytime;
                }
            }

            q.HasVotes = true;

            UpdateResults(q.SlideId);
        } 

        private void UpdateResults(int questionSlideId)
        {
            var lst = new List<ResultSlideConfiguration>();
            foreach (var result in ResultSlideConfigurations)
            {
                var exist = result.SelectedQuestions.Any(x => x.QuestionRelation.Id == questionSlideId);
                if (exist)
                    lst.Add(result);
            }

            foreach (var item in lst)
            {
                item.UdateChart();
            }

            return;
        }

        internal void ClearVotes(int questionSlideId)
        {
            var qs = GetQuestionSlideConfiguration(questionSlideId);
            foreach (var item in qs.Answers)
            {
                item.VotesCount = 0;
                item.Time = 0;
                item.Votes.Clear();
            }
            //UpdateResults(questionSlideId);
        }

        internal void ReBuildReferences()
        {
            foreach (var qconf in QuestionSlideConfigurations)
            {
                qconf.SlideAssociated = PowerPointHelper.FindSlideById(qconf.SlideId);
                qconf.QuetionTitleTextBox = PowerPointHelper.FindShapeById(qconf.SlideId, qconf.QuetionTitleTextBoxIndex);
                qconf.CheckButtonShape = PowerPointHelper.FindShapeById(qconf.SlideId, qconf.IndexForCheckButtonShape);
                qconf.TimerShape = PowerPointHelper.FindShapeById(qconf.SlideId, qconf.IndexForTimer);
                qconf.CountVotesShape = PowerPointHelper.FindShapeById(qconf.SlideId, qconf.IndexCountVotes);
                foreach (var ans in qconf.Answers)
                {
                    ans.AnswerTextBox = PowerPointHelper.FindShapeById(qconf.SlideId, ans.AnswerTextBoxIndex);
                }
                

                qconf.ChangeUnCheckButonToCheck();
            }
            foreach (var rConfig in ResultSlideConfigurations)
            {
                if (rConfig.CrossCompConfig != null && rConfig.CrossCompConfig.ChartShapeIndex!=0)
                {
                    rConfig.CrossCompConfig.ChartShape = PowerPointHelper.FindShapeById(rConfig.SlideId, rConfig.CrossCompConfig.ChartShapeIndex);
                }
                if (rConfig.RankingConfig != null && rConfig.RankingConfig.RankigVotedShapes.Count>0)
                {
                    foreach (var rnk in rConfig.RankingConfig.RankigVotedShapes)
                    {
                        rnk.AnswerTextBox = PowerPointHelper.FindShapeById(rConfig.SlideId, rnk.AnswerTextBoxIndex);
                        rnk.AnswerChart = PowerPointHelper.FindShapeById(rConfig.SlideId, rnk.AnswerChartIndex);
                        rnk.AnswerChartValue = PowerPointHelper.FindShapeById(rConfig.SlideId, rnk.AnswerChartValueIndex);
                    }
                }

                foreach (var questSelected in rConfig.SelectedQuestions)
                {
                    if (questSelected.AnswersVoted != null)
                    {
                        foreach (var ansVoted in questSelected.AnswersVoted)
                        {
                            if (ansVoted.AnswerTextBoxIndex > 0)
                                ansVoted.AnswerTextBox = PowerPointHelper.FindShapeById(rConfig.SlideId, ansVoted.AnswerTextBoxIndex);
                            if (ansVoted.AnswerChartIndex > 0)
                                ansVoted.AnswerChart = PowerPointHelper.FindShapeById(rConfig.SlideId, ansVoted.AnswerChartIndex);
                            if (ansVoted.AnswerChartValueIndex > 0)
                                ansVoted.AnswerChartValue = PowerPointHelper.FindShapeById(rConfig.SlideId, ansVoted.AnswerChartValueIndex);
                        }
                    }
                    else if (questSelected.MirrorAnswersVoted != null)
                    {
                        foreach (var mirroransVoted in questSelected.MirrorAnswersVoted)
                        {
                            if (mirroransVoted.AnswerTextBoxIndex > 0)
                                mirroransVoted.AnswerTextBox = PowerPointHelper.FindShapeById(rConfig.SlideId, mirroransVoted.AnswerTextBoxIndex);
                            if (mirroransVoted.AnswerChartIndex > 0)
                                mirroransVoted.AnswerChart = PowerPointHelper.FindShapeById(rConfig.SlideId, mirroransVoted.AnswerChartIndex);
                            if (mirroransVoted.AnswerChartValueIndex > 0)
                                mirroransVoted.AnswerChartValue = PowerPointHelper.FindShapeById(rConfig.SlideId, mirroransVoted.AnswerChartValueIndex);

                            if (mirroransVoted.AnswerChart2Index > 0)
                                mirroransVoted.AnswerChart2 = PowerPointHelper.FindShapeById(rConfig.SlideId, mirroransVoted.AnswerChart2Index);
                            if (mirroransVoted.AnswerChartValue2Index > 0)
                                mirroransVoted.AnswerChartValue2 = PowerPointHelper.FindShapeById(rConfig.SlideId, mirroransVoted.AnswerChartValue2Index);
                           
                        }
                    }
                }
            }
        }
        [NonSerialized]
        private Hardware.RetrieveVotesForm _currentRetrieveVotesForm;

        public Hardware.RetrieveVotesForm CurrentRetrieveVotesForm
        {
            get { return _currentRetrieveVotesForm; }
            set { _currentRetrieveVotesForm = value; }
        }

        internal void ExportData()
        {
            var result = MessageBox.Show("¿Desea guardar la sesión?", "Sesión",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                var expData = ExcelHelper.GetExportationData(this);

                ExcelHelper.ExportSession(expData);
            }
        }

        internal void ClearAllVotes()
        {
            foreach (var q in QuestionSlideConfigurations)
            {
                foreach (var a in q.Answers)
                {
                    a.VotesCount = 0;
                    a.Time = 0;
                    a.Votes.Clear();
                }
            }
        }

        internal void UpdateResultsCharts()
        {
            foreach (var res in this.ResultSlideConfigurations)
            {
                res.UdateChart();
            }
        }
    }
}
