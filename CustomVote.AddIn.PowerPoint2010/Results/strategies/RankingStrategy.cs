using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CustomVote.AddIn.PowerPoint2010.Results.Data;
using CustomVote.AddIn.PowerPoint2010.Helpers;
using CustomVote.AddIn.PowerPoint2010.Hardware;
using CustomVote.AddIn.PowerPoint2010.Questions.Data;

namespace CustomVote.AddIn.PowerPoint2010.Results.strategies
{
    public class RankingStrategy:IResultStrategy
    {
        public void DrawSlide(Data.ResultSlideConfiguration resultConfig, List<Helpers.ItemList> lstQuestions)
        {
            foreach (var q in lstQuestions)
            {
                var selectedQ = new SelectedQuetions();
                selectedQ.QuestionRelation = q;
                
                resultConfig.SelectedQuestions.Add(selectedQ);
            }
            resultConfig.RankingConfig.RankigVotedShapes = RankigVotedShapes(resultConfig);
        }

        private List<RankingAnswerVotedEntity> RankigVotedShapes(ResultSlideConfiguration resultConfig)
        {
            float initialTop = 110;
            List<RankingAnswerVotedEntity> lst = new List<RankingAnswerVotedEntity>();
            for (int i = 0; i < resultConfig.RankingConfig.TopRanking; i++)
            {
                var ansVoted = new RankingAnswerVotedEntity();

                int answerWidth = Convert.ToInt32(-100 + (100 - resultConfig.HistWidthPercent) * PowerPointHelper.SlideWidth / 100);
                int answerTextboxIndex;
                var answerTextbox = PowerPointHelper.CreateTextboxOn(resultConfig.SlideAssociated, 50, initialTop, answerWidth, 35,
                                            "#", 24,
                                            Microsoft.Office.Interop.PowerPoint.PpParagraphAlignment.ppAlignLeft, out answerTextboxIndex);

                int leftChart = PowerPointHelper.GetLeftByPercent(resultConfig.HistWidthPercent)-70;
                int widthChartValue = 0;
                //if (!double.IsNaN(answer.GetPercentValue((int)resultConfig.Decimals)))
                //    widthChartValue = Convert.ToInt32(answer.GetPercentValue((int)resultConfig.Decimals));
                int widthChart = PowerPointHelper.GetWidthByPercent(resultConfig.HistWidthPercent, widthChartValue);

                int shapeChartIndex;
                var shapeChart = PowerPointHelper.CreateShapeOn(resultConfig.SlideAssociated, leftChart, initialTop, widthChart, 35, out shapeChartIndex);


                int leftChartValue = leftChart + widthChart + 2;
                int widtChartValue = 95;
                int shapeChartValueIndex;
                var shapeChartValue = PowerPointHelper.CreateTextboxOn(resultConfig.SlideAssociated, leftChartValue, initialTop, widtChartValue, 35,
                                            "0", 14,
                                            Microsoft.Office.Interop.PowerPoint.PpParagraphAlignment.ppAlignLeft, out shapeChartValueIndex);

                ansVoted.AnswerTextBox = answerTextbox;
                ansVoted.AnswerTextBoxIndex = answerTextboxIndex;

                ansVoted.AnswerChart = shapeChart;
                ansVoted.AnswerChartIndex = shapeChartIndex;

                ansVoted.AnswerChartValue = shapeChartValue;
                ansVoted.AnswerChartValueIndex = shapeChartValueIndex;

                lst.Add(ansVoted);

                initialTop += 50;
            }
            return lst;
        }

        public void UpdateSlide(Data.ResultSlideConfiguration resultConfig)
        {
            resultConfig.RankingConfig.ResetValues();
            
            List<RankingVotes> rvotes = GetRankingVotes(resultConfig);

            foreach (var item in rvotes)
            {
                var index = rvotes.IndexOf(item);
                
                resultConfig.RankingConfig.RankigVotedShapes[index].AnswerTextBox.TextFrame.TextRange.Text = Globals.ThisAddIn.Session.HardwareConfiguration.GetFrienlyNameForKeyPad( item.KeyId);

                var textChartValue = "";
                if (!resultConfig.RankingConfig.ShowPointsAcum)
                {
                    if (resultConfig.RankingConfig.ShowTime)
                        textChartValue = item.CorrectAnswerCount.ToString() + " (" + item.TimeSum + " s)";
                    else
                        textChartValue = item.CorrectAnswerCount.ToString();
                }
                else
                {
                    if (resultConfig.RankingConfig.ShowTime)
                        textChartValue = item.PointsSum.ToString() + " (" + item.TimeSum + " s)";
                    else
                        textChartValue = item.PointsSum.ToString();
                }
                resultConfig.RankingConfig.RankigVotedShapes[index].AnswerChartValue.TextFrame.TextRange.Text = textChartValue;
            }
            
        }

        private List<RankingVotes> GetRankingVotes(ResultSlideConfiguration resultConfig)
        {
            List<VotesFlat> rankingTotal = new List<VotesFlat>();
            Dictionary<AnswerEntity, List<VotesFlat>> dictAnswer = new Dictionary<Questions.Data.AnswerEntity, List<VotesFlat>>();

            foreach (var selectedQ in resultConfig.SelectedQuestions)
            {
                var qConfig = Globals.ThisAddIn.Session.GetQuestionSlideConfiguration(selectedQ.QuestionRelation.Id);
                AnswerEntity correctAnswer = null;
                List<VotesFlat> qRanking = qConfig.GetVotesFromCorrectAnswer(out correctAnswer);
                rankingTotal.AddRange(qRanking);
                if (correctAnswer != null)
                {
                    dictAnswer.Add(correctAnswer, qRanking);
                }
            }
            List<RankingVotes> rvotes = new List<RankingVotes>();
            foreach (var rnkg in rankingTotal)
            {
                int points = ComputatePointsFromCorrectAnswer(dictAnswer, rnkg);
                var r = rvotes.Where(x => x.KeyId == rnkg.KeyId).FirstOrDefault();
                if (r == null)
                    rvotes.Add(new RankingVotes(rnkg.KeyId, rnkg.Keytime, points));
                else
                {
                    r.CorrectAnswerCount++;
                    r.TimeSum += rnkg.Keytime;
                    r.PointsSum += points;
                }
            }

            List<RankingVotes> rvotesOrd = null;
            switch (resultConfig.ValueOrder)
            {
                case HistValueOrder.Ninguno:
                case HistValueOrder.Ascendente:
                    if(resultConfig.RankingConfig.ShowPointsAcum)
                        rvotesOrd = rvotes.OrderBy(x => x.PointsSum).ThenByDescending(y => y.TimeSum).ToList();
                    else
                        rvotesOrd = rvotes.OrderBy(x => x.CorrectAnswerCount).ThenByDescending(y => y.TimeSum).ToList();
                    break;
                case HistValueOrder.Descendente:
                    if (resultConfig.RankingConfig.ShowPointsAcum)
                        rvotesOrd = rvotes.OrderByDescending(x => x.PointsSum).ThenBy(y => y.TimeSum).ToList();
                    else
                        rvotesOrd = rvotes.OrderByDescending(x => x.CorrectAnswerCount).ThenBy(y => y.TimeSum).ToList();
                    break;
            }

            return rvotesOrd.Take(resultConfig.RankingConfig.TopRanking).ToList();
        }

        private int ComputatePointsFromCorrectAnswer(Dictionary<AnswerEntity, List<VotesFlat>> dictAnswer, VotesFlat rnkg)
        {
            foreach (var answ in dictAnswer.Keys)
            {
                if (dictAnswer[answ].Contains(rnkg))
                    return answ.Points;
            }
            return 0;
        }



        public void CreateTitle(Data.ResultSlideConfiguration resultConfig)
        {
            int index;
            var question = PowerPointHelper.CreateTextboxOn(resultConfig.SlideAssociated, 50, 20, 600, 50,
                                            "Ranking", 36,
                                            Microsoft.Office.Interop.PowerPoint.PpParagraphAlignment.ppAlignCenter, out index);
        }

        public void Ordering(Data.ResultSlideConfiguration resultConfig)
        {
            //throw new NotImplementedException();
        }

        public void ResizeCharts(Data.ResultSlideConfiguration resultConfig)
        {

            List<RankingVotes> rvotes = GetRankingVotes(resultConfig);

            foreach (var item in rvotes)
            {
                var index = rvotes.IndexOf(item);
                

                int answerWidth = Convert.ToInt32(-100 + (100 - resultConfig.HistWidthPercent) * PowerPointHelper.SlideWidth / 100);
                resultConfig.RankingConfig.RankigVotedShapes[index].AnswerTextBox.Width = answerWidth;

                int leftChart = PowerPointHelper.GetLeftByPercent(resultConfig.HistWidthPercent)-70;

                var percentValue = item.GetPercentValueFrom(rvotes, Convert.ToInt32(resultConfig.Decimals));

                if(resultConfig.RankingConfig.ShowPointsAcum)
                    percentValue = item.GetPercentValueByPointsFrom(rvotes, Convert.ToInt32(resultConfig.Decimals));
                else
                    percentValue = item.GetPercentValueFrom(rvotes, Convert.ToInt32(resultConfig.Decimals));

                int widthChart = PowerPointHelper.GetWidthByPercent(resultConfig.HistWidthPercent, Convert.ToInt32(percentValue));
                resultConfig.RankingConfig.RankigVotedShapes[index].AnswerChart.Left = leftChart;
                resultConfig.RankingConfig.RankigVotedShapes[index].AnswerChart.Width = widthChart;


                int leftChartValue = leftChart + widthChart + 2;

                resultConfig.RankingConfig.RankigVotedShapes[index].AnswerChartValue.Left = leftChartValue;
            }
        }
    }
}
