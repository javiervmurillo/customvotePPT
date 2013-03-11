using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CustomVote.AddIn.PowerPoint2010.Results.Data;
using CustomVote.AddIn.PowerPoint2010.Helpers;
using CustomVote.AddIn.PowerPoint2010.Hardware;
using Microsoft.Office.Interop.Excel;

namespace CustomVote.AddIn.PowerPoint2010.Results.strategies
{
    public class CrossComparisonStrategy : IResultStrategy
    {
        public void DrawSlide(Data.ResultSlideConfiguration resultConfig, List<Helpers.ItemList> lstQuestions)
        {
            foreach (var q in lstQuestions)
            {
                var selectedQ = new SelectedQuetions();
                selectedQ.QuestionRelation = q;

                resultConfig.SelectedQuestions.Add(selectedQ);
            }
            int index;
            resultConfig.CrossCompConfig.ChartShape = CreateChart(resultConfig, out index);
            resultConfig.CrossCompConfig.ChartShapeIndex = index;
        }

        private Microsoft.Office.Interop.PowerPoint.Shape CreateChart(ResultSlideConfiguration resultConfig, out int index)
        {
            if (resultConfig.SelectedQuestions.Count != 2)
                throw new Exception("Debe seleccionar 2 preguntas");

            CrossComparisonEntity cross = new CrossComparisonEntity(resultConfig);

            var shape = PowerPointHelper.CreateChartOn(resultConfig.SlideAssociated,30,90,600,400, out index);

            var chart = shape.Chart;

            UpdateDataChart(chart, cross);
            
            return shape;
        }

        private void UpdateDataChart(Microsoft.Office.Interop.PowerPoint.Chart chart, CrossComparisonEntity cross)
        {
            chart.ChartData.Activate();
            Workbook wb = chart.ChartData.Workbook;
            Worksheet ws = wb.Worksheets[1];

            wb.Application.WindowState = XlWindowState.xlMinimized;
            //_app.WindowState = Microsoft.Office.Interop.PowerPoint.PpWindowState.ppWindowNormal;

            //ws.ListObjects[1].Resize(ws.get_Range("A1", "N15"));
            

            //ws.Cells.Clear();
            
            
            var charArrays = "-ABCDEFGHIJKLMN".ToCharArray();
            int indexCol = 2;
            int indexRow = 2;

            int indexColMax = 0;
            int indexRowMax = 0;

            foreach (var r in cross.Matriz.Keys)
            {
                foreach (var h in cross.Matriz[r].Keys)
                {
                    if (indexRow == 2)
                    {
                        string cellTitle = charArrays[indexCol] + 1.ToString();
                        ws.Range[cellTitle].Value = h.Text;
                    }
                    if (indexCol == 2)
                    {
                        string cellTitle = charArrays[indexCol - 1] + indexRow.ToString();
                        ws.Range[cellTitle].Value = r.Text;
                    }
                    string cell = charArrays[indexCol] + indexRow.ToString();
                    ws.Range[cell].Value = cross.Matriz[r][h];

                    indexColMax = (indexCol > indexColMax) ? indexCol : indexColMax;

                    indexCol++;
                }
                indexCol = 2;
                indexRowMax = (indexRow > indexRowMax) ? indexRow : indexRowMax;
                indexRow++;
            }
            
            string columnMax = charArrays[indexColMax] + indexRowMax.ToString();

            ws.ListObjects[1].Resize(ws.get_Range("A1", columnMax));
            wb.Application.Visible = false;



            //chart.ApplyDataLabels(Microsoft.Office.Interop.PowerPoint.XlDataLabelsType.xlDataLabelsShowLabel);
        }


        public void UpdateSlide(ResultSlideConfiguration resultConfig)
        {
            CrossComparisonEntity cross = new CrossComparisonEntity(resultConfig);

            var shape = resultConfig.CrossCompConfig.ChartShape;

            var chart = shape.Chart;

            UpdateDataChart(chart, cross);
        }

        public void CreateTitle(ResultSlideConfiguration resultConfig)
        {
            int index;
            var question = PowerPointHelper.CreateTextboxOn(resultConfig.SlideAssociated, 50, 20, 600, 50,
                                           "Comparación cruzada", 36,
                                           Microsoft.Office.Interop.PowerPoint.PpParagraphAlignment.ppAlignCenter, out index);
        }

        public void Ordering(ResultSlideConfiguration resultConfig)
        {
            //throw new NotImplementedException();
        }

        public void ResizeCharts(ResultSlideConfiguration resultConfig)
        {
            //throw new NotImplementedException();
        }
    }
}
