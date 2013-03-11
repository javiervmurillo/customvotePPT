using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CustomVote.AddIn.PowerPoint2010.Results.Data;
using CustomVote.AddIn.PowerPoint2010.Helpers;

namespace CustomVote.AddIn.PowerPoint2010.Results.strategies
{
    public class MirrorStrategy : IResultStrategy
    {
        public void DrawSlide(Data.ResultSlideConfiguration resultConfig, List<Helpers.ItemList> lstQuestions)
        {
            foreach (var q in lstQuestions)
            {
                var selectedQ = new SelectedQuetions();
                selectedQ.QuestionRelation = q;
                var qConfig = Globals.ThisAddIn.Session.GetQuestionSlideConfiguration(selectedQ.QuestionRelation.Id);

                selectedQ.MirrorAnswersVoted = CreateAnswersVotedShapes(resultConfig, qConfig, lstQuestions.IndexOf(q) + 1);
                resultConfig.SelectedQuestions.Add(selectedQ);
            }
        }

        private List<MirrorAnswerVotedEntity> CreateAnswersVotedShapes(ResultSlideConfiguration resultConfig, Questions.Data.QuestionSlideConfiguration qConfig, int index)
        {
            var lst = new List<MirrorAnswerVotedEntity>();

            float initialTop = 110;
            foreach (var answer in qConfig.Answers)
            {
                var ansVoted = new MirrorAnswerVotedEntity();
                //text Answer
                if (index == 1)
                {
                    int answerWidth = Convert.ToInt32(-100 + (100 - resultConfig.HistWidthPercent) * PowerPointHelper.SlideWidth / 100);
                    int answerTextboxIndex;
                    var answerTextbox = PowerPointHelper.CreateTextboxOn(resultConfig.SlideAssociated, 50, initialTop, answerWidth, 35,
                                                answer.TextToShow, 24,
                                                Microsoft.Office.Interop.PowerPoint.PpParagraphAlignment.ppAlignLeft, out answerTextboxIndex);
                    ansVoted.AnswerTextBox = answerTextbox;
                    ansVoted.AnswerTextBoxIndex = answerTextboxIndex;
                }

                //chart
                int leftChart = PowerPointHelper.GetLeftByPercent(resultConfig.HistWidthPercent, (index==1?2:1));
                if (index == 2)
                    leftChart += 60;
                int widthChartValue = 0;
                if (!double.IsNaN(answer.GetPercentValue((int)resultConfig.Decimals)))
                    widthChartValue = Convert.ToInt32(answer.GetPercentValue((int)resultConfig.Decimals));
                int widthChart = PowerPointHelper.GetWidthByPercent(resultConfig.HistWidthPercent, widthChartValue);
                int shapeChartIndex;
                var shapeChart = PowerPointHelper.CreateShapeOn(resultConfig.SlideAssociated, leftChart, initialTop, widthChart, 35, out shapeChartIndex);

                //text Chart
                int leftChartValue = leftChart + widthChart;
                int widtChartValue = 95;
                int shapeChartValueIndex;
                var shapeChartValue = PowerPointHelper.CreateTextboxOn(resultConfig.SlideAssociated, leftChartValue, initialTop, widtChartValue, 35,
                                            answer.GetValue(resultConfig.Valuetype, (int)resultConfig.Decimals), answer.GetValueFontSize(),
                                            Microsoft.Office.Interop.PowerPoint.PpParagraphAlignment.ppAlignLeft, out shapeChartValueIndex);

                if (index == 1)
                {
                    ansVoted.AnswerChart = shapeChart;
                    ansVoted.AnswerChartIndex = shapeChartIndex;

                    ansVoted.AnswerChartValue = shapeChartValue;
                    ansVoted.AnswerChartValueIndex = shapeChartValueIndex;

                    ansVoted.AnswerAssociated = answer;
                }
                else if (index == 2)
                {
                    ansVoted.AnswerChart2 = shapeChart;
                    ansVoted.AnswerChart2Index = shapeChartIndex;

                    ansVoted.AnswerChartValue2 = shapeChartValue;
                    ansVoted.AnswerChartValue2Index = shapeChartValueIndex;

                    ansVoted.AnswerAssociated2 = answer;
                }
                lst.Add(ansVoted);

                initialTop += 50;
            }

            return lst;
        }

        public void UpdateSlide(Data.ResultSlideConfiguration resultConfig)
        {
            foreach (var q in resultConfig.SelectedQuestions)
            {
                foreach (var answ in q.MirrorAnswersVoted)
                {
                    if (answ.AnswerChartValue != null)
                        answ.AnswerChartValue.TextFrame.TextRange.Text = answ.AnswerAssociated.GetValue(resultConfig.Valuetype, (int)resultConfig.Decimals);
                    else if(((MirrorAnswerVotedEntity)answ).AnswerChartValue2 != null)
                        ((MirrorAnswerVotedEntity)answ).AnswerChartValue2.TextFrame.TextRange.Text =
                            ((MirrorAnswerVotedEntity)answ).AnswerAssociated2.GetValue(resultConfig.Valuetype, (int)resultConfig.Decimals);
                }
            }
        }

        public void CreateTitle(Data.ResultSlideConfiguration resultConfig)
        {
            int index;
            var question = PowerPointHelper.CreateTextboxOn(resultConfig.SlideAssociated, 50, 20, 600, 50,
                                           "Comparación Espejo", 36,
                                           Microsoft.Office.Interop.PowerPoint.PpParagraphAlignment.ppAlignCenter, out index);
        }

        public void Ordering(Data.ResultSlideConfiguration resultConfig)
        {
            //throw new NotImplementedException();
        }

        public void ResizeCharts(Data.ResultSlideConfiguration resultConfig)
        {
            foreach (var q in resultConfig.SelectedQuestions)
            {
                var index = resultConfig.SelectedQuestions.IndexOf(q)+1;
                foreach (var answ in q.MirrorAnswersVoted)
                {
                    int answerWidth = Convert.ToInt32(-100 + (100 - resultConfig.HistWidthPercent) * PowerPointHelper.SlideWidth / 100);

                    if (answ.AnswerTextBox != null)
                        answ.AnswerTextBox.Width = answerWidth;

                    var answerAssociated = answ.AnswerAssociated!=null?answ.AnswerAssociated:((MirrorAnswerVotedEntity)answ).AnswerAssociated2;
                    int leftChart = PowerPointHelper.GetLeftByPercent(resultConfig.HistWidthPercent, (index == 1 ? 2 : 1));
                    if (index == 2)
                        leftChart += 60;
                    
                    int widthChart = PowerPointHelper.GetWidthByPercent(resultConfig.HistWidthPercent, Convert.ToInt32(answerAssociated.GetPercentValue((int)resultConfig.Decimals)));

                    if (answ.AnswerChart != null)
                        answ.AnswerChart.Left = leftChart;
                    else if (((MirrorAnswerVotedEntity)answ).AnswerChart2 != null)
                        ((MirrorAnswerVotedEntity)answ).AnswerChart2.Left = leftChart;

                    if (answ.AnswerChart != null)
                        answ.AnswerChart.Width = widthChart;
                    else if (((MirrorAnswerVotedEntity)answ).AnswerChart2 != null)
                        ((MirrorAnswerVotedEntity)answ).AnswerChart2.Width = widthChart;


                    int leftChartValue = leftChart + widthChart;

                    if (answ.AnswerChartValue != null)
                        answ.AnswerChartValue.Left = leftChartValue;
                    else if (((MirrorAnswerVotedEntity)answ).AnswerChartValue2 != null)
                        ((MirrorAnswerVotedEntity)answ).AnswerChartValue2.Left = leftChartValue;
                }
            }
        }
    }
}
