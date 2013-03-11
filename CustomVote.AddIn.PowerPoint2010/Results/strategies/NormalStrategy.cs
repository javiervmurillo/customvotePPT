using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CustomVote.AddIn.PowerPoint2010.Results.Data;
using CustomVote.AddIn.PowerPoint2010.Helpers;

namespace CustomVote.AddIn.PowerPoint2010.Results.strategies
{
    public class NormalStrategy: IResultStrategy
    {
        public void DrawSlide(ResultSlideConfiguration resultConfig, List<ItemList> lstQuestions)
        {
            foreach (var q in lstQuestions)
            {
                var selectedQ = new SelectedQuetions();
                selectedQ.QuestionRelation = q;
                var qConfig = Globals.ThisAddIn.Session.GetQuestionSlideConfiguration(selectedQ.QuestionRelation.Id);
                selectedQ.AnswersVoted = CreateAnswersVotedShapes(resultConfig, qConfig);
                resultConfig.SelectedQuestions.Add(selectedQ);
            }
            
        }

        public void CreateTitle(ResultSlideConfiguration resultConfig)
        {
            var qas = resultConfig.SelectedQuestions.First().QuestionRelation.Name;
            int index;
            var question = PowerPointHelper.CreateTextboxOn(resultConfig.SlideAssociated, 50, 20, 600, 50,
                                            qas, 36,
                                            Microsoft.Office.Interop.PowerPoint.PpParagraphAlignment.ppAlignCenter, out index);
        }

        public void Ordering(ResultSlideConfiguration resultConfig)
        {
            var q = resultConfig.SelectedQuestions.First();
            switch (resultConfig.ValueOrder)
            {
                case HistValueOrder.Ninguno:
                    //Ordering(q.AnswersVoted);
                    break;
                case HistValueOrder.Ascendente:
                    var orderedAsc = q.AnswersVoted.OrderBy(x => x.AnswerAssociated.GetNumericValueForOrder((int)resultConfig.Decimals)).ToList();
                    Ordering(orderedAsc);
                    break;
                case HistValueOrder.Descendente:
                    var orderedDesc = q.AnswersVoted.OrderByDescending(x => x.AnswerAssociated.GetNumericValueForOrder((int)resultConfig.Decimals)).ToList();
                    Ordering(orderedDesc);
                    break;
                default:
                    break;
            }
        }

        public void ResizeCharts(ResultSlideConfiguration resultConfig)
        {
            var q = resultConfig.SelectedQuestions.First();
            foreach (var answ in q.AnswersVoted)
            {
                int answerWidth = Convert.ToInt32(-100 + (100 - resultConfig.HistWidthPercent) * PowerPointHelper.SlideWidth / 100);
                answ.AnswerTextBox.Width = answerWidth;

                int leftChart = PowerPointHelper.GetLeftByPercent(resultConfig.HistWidthPercent)-70;
                int widthChart = PowerPointHelper.GetWidthByPercent(resultConfig.HistWidthPercent, Convert.ToInt32(answ.AnswerAssociated.GetPercentValue((int)resultConfig.Decimals)));

                answ.AnswerChart.Width = widthChart;
                int leftChartValue = leftChart + widthChart + 2;

                if (resultConfig.ValueOrder != HistValueOrder.Ninguno)
                {
                    answ.AnswerChart.Left = leftChart;
                    answ.AnswerChartValue.Left = leftChartValue;
                }
                else
                {
                    //if(resultConfig.NormalConfig.CopyQuestionShpapesFormat)
                    //{
                    //    CopyQuestionShapesFormat(answ);
                    //}
                    if(resultConfig.NormalConfig.KeepTogetherResult)
                    {
                        answ.AnswerChartValue.Left = answ.AnswerChart.Left + answ.AnswerChart.Width + 2;
                        answ.AnswerChartValue.Top = answ.AnswerChart.Top + 1;
                    }
                    
                }
                answ.AnswerChartValue.TextFrame.TextRange.Font.Size = answ.AnswerAssociated.GetValueFontSize();

            }
        }
        private void CopyQuestionShapesFormat(NormalAnswerVotedEntity answ)
        {
            answ.AnswerTextBox.Left = answ.AnswerAssociated.AnswerTextBox.Left;
            answ.AnswerTextBox.Top = answ.AnswerAssociated.AnswerTextBox.Top;

            answ.AnswerChart.Left = answ.AnswerTextBox.Left + answ.AnswerTextBox.Width - 70;
            answ.AnswerChart.Top = answ.AnswerTextBox.Top;

            answ.AnswerChartValue.Left = answ.AnswerChart.Left + answ.AnswerChart.Width;
            answ.AnswerChartValue.Top = answ.AnswerTextBox.Top;
        }

        public void UpdateSlide(ResultSlideConfiguration resultConfig)
        {
            foreach (var q in resultConfig.SelectedQuestions)
            {
                foreach (var answ in q.AnswersVoted)
                {
                    answ.AnswerChartValue.TextFrame.TextRange.Text = answ.AnswerAssociated.GetValue(resultConfig.Valuetype, (int)resultConfig.Decimals);
                }
            }
        }

        private List<NormalAnswerVotedEntity> CreateAnswersVotedShapes(ResultSlideConfiguration resultConfig, Questions.Data.QuestionSlideConfiguration qConfig)
        {
            var lst = new List<NormalAnswerVotedEntity>();

            float initialTop = 110;
            foreach (var answer in qConfig.Answers)
            {
                var ansVoted = new NormalAnswerVotedEntity();

                int answerWidth = Convert.ToInt32(-100 + (100 - resultConfig.HistWidthPercent) * PowerPointHelper.SlideWidth / 100);
                int answerTextboxIndex;
                var answerTextbox = PowerPointHelper.CreateTextboxOn(resultConfig.SlideAssociated, 50, initialTop, answerWidth, 35,
                                            answer.TextToShow, 24,
                                            Microsoft.Office.Interop.PowerPoint.PpParagraphAlignment.ppAlignLeft, out answerTextboxIndex);

                int leftChart = PowerPointHelper.GetLeftByPercent(resultConfig.HistWidthPercent)-70;
                int widthChartValue = 0;
                if (!double.IsNaN(answer.GetPercentValue((int)resultConfig.Decimals)))
                    widthChartValue = Convert.ToInt32(answer.GetPercentValue((int)resultConfig.Decimals));
                int widthChart = PowerPointHelper.GetWidthByPercent(resultConfig.HistWidthPercent, widthChartValue);

                int shapeChartIndex;
                var shapeChart = PowerPointHelper.CreateShapeOn(resultConfig.SlideAssociated, leftChart, initialTop, widthChart, 35, out shapeChartIndex);


                int leftChartValue = (leftChart + widthChart + 2);
                int widtChartValue = 95;
                int shapeChartValueIndex;
                var shapeChartValue = PowerPointHelper.CreateTextboxOn(resultConfig.SlideAssociated, leftChartValue, initialTop, widtChartValue, 35,
                                            answer.GetValue(resultConfig.Valuetype, (int)resultConfig.Decimals), answer.GetValueFontSize(),
                                            Microsoft.Office.Interop.PowerPoint.PpParagraphAlignment.ppAlignLeft, out shapeChartValueIndex);

                ansVoted.AnswerTextBox = answerTextbox;
                ansVoted.AnswerTextBoxIndex = answerTextboxIndex;

                ansVoted.AnswerChart = shapeChart;
                ansVoted.AnswerChartIndex = shapeChartIndex;

                ansVoted.AnswerChartValue = shapeChartValue;
                ansVoted.AnswerChartValueIndex = shapeChartValueIndex;

                ansVoted.AnswerAssociated = answer;

                lst.Add(ansVoted);

                initialTop += 50;
            }

            if (resultConfig.ValueOrder == HistValueOrder.Ninguno)
                if(resultConfig.NormalConfig.CopyQuestionShpapesFormat)
                    foreach (var answ in lst)
                    {
                        CopyQuestionShapesFormat(answ);
                    }

            return lst;
        }

        private void Ordering(List<NormalAnswerVotedEntity> ordered)
        {
            float initialTop = 110;
            foreach (var item in ordered)
            {
                item.AnswerTextBox.Top = initialTop;
                item.AnswerChart.Top = initialTop;
                item.AnswerChartValue.Top = initialTop;
                initialTop += 50;
            }
        }
    }
}
