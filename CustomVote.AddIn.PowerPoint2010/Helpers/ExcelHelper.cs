using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CustomVote.AddIn.PowerPoint2010.Questions.Data;
using Microsoft.Office.Interop;
using System.Windows.Forms;
using System.Reflection;

namespace CustomVote.AddIn.PowerPoint2010.Helpers
{
    public class ExcelHelper
    {
        public static ExportationData GetExportationData(Session.SessionManager session)
        {
            ExportationData exp = new ExportationData();

            exp.PresentationName = Globals.ThisAddIn.Application.ActivePresentation.Name;
            exp.CreatedAt = DateTime.Now;

            //questions
            exp.Questions = new List<ExpQuestions>();
            exp.KeypadsData = new List<ExpKeypadData>();

            foreach (var q in session.QuestionSlideConfigurations)
            {
                //answers
                ExpQuestions expQ = new ExpQuestions()
                {
                    Title = q.QuetionTitle,
                    Answers = new List<ExpAnswerEntity>()
                };
                foreach (var a in q.Answers)
                {
                    ExpAnswerEntity expA = new ExpAnswerEntity()
                    {
                        Name = a.Text,
                        Points = a.Points
                    };

                    expQ.Answers.Add(expA);

                    //votes
                    foreach (var v in a.Votes)
                    {
                        //keypads
                        var keypad = exp.KeypadsData.Where(x => x.KeyPadId == v.KeyId).FirstOrDefault();
                        if (keypad == null)
                        {
                            keypad = new ExpKeypadData()
                            {
                                KeyPadId = v.KeyId,
                                FrienlyName = session.HardwareConfiguration.GetFrienlyNameForKeyPad(v.KeyId),
                                PartialPoints = new List<int>()
                            };
                            exp.KeypadsData.Add(keypad);
                        }
                        keypad.PartialPoints.Add(a.Points);
                    }
                }
                exp.Questions.Add(expQ);
            }
            return exp;
        }

        public class ExportationData
        {
            public string PresentationName { get; set; }
            public DateTime CreatedAt { get; set; }
            public List<ExpQuestions> Questions { get; set; }
            public List<ExpKeypadData> KeypadsData { get; set; }
        }

        public class ExpQuestions
        {
            public string Title { get; set; }
            public List<ExpAnswerEntity> Answers { get; set; }

            internal string GetAnswersText()
            {
                StringBuilder sb = new StringBuilder();
                foreach (var a in Answers)
                {
                    sb.AppendLine(a.Name);
                }
                return sb.ToString();
            }

            internal string GetAnswersPointsText()
            {
                StringBuilder sb = new StringBuilder();
                foreach (var a in Answers)
                {
                    sb.AppendLine(a.Points.ToString());
                }
                return sb.ToString();
            }
        }
        public class ExpAnswerEntity
        {
            public string Name { get; set; }
            public int Points { get; set; }
        }
        public class ExpKeypadData
        {
            public int KeyPadId { get; set; }
            public string FrienlyName { get; set; }
            public int TotalPoints
            {
                get
                {
                    if (PartialPoints == null)
                        return 0;
                    if (PartialPoints.Count == 0)
                        return 0;

                    return PartialPoints.Sum();
                }
            }
            public List<int> PartialPoints { get; set; }
        }

        internal static void ExportSession(ExportationData expData)
        {
            Microsoft.Office.Interop.Excel.Application oXL;
            Microsoft.Office.Interop.Excel._Workbook oWB;
            Microsoft.Office.Interop.Excel._Worksheet oSheet;
            Microsoft.Office.Interop.Excel.Range oRng;

            try
            {
                //Start Excel and get Application object.
                oXL = new Microsoft.Office.Interop.Excel.Application();
                oXL.Visible = true;

                //Get a new workbook.
                oWB = (Microsoft.Office.Interop.Excel._Workbook)(oXL.Workbooks.Add(Missing.Value));
                oSheet = (Microsoft.Office.Interop.Excel._Worksheet)oWB.ActiveSheet;

                //headers
                oSheet.Cells[1, 4] = "Presentación";
                oSheet.Cells[1, 5] = "Fecha";
                int qnum = 1;
                int qcolIndex = 6;
                foreach (var q in expData.Questions)
                {
                    oSheet.Cells[1, qcolIndex] = "Pregunta " + qnum.ToString();
                    oSheet.Cells[1, qcolIndex + 1] = "Pts";
                    qnum += 1;
                    qcolIndex += 2;
                }

                oSheet.Cells[3, 6] = "Preguntas";
                oSheet.Cells[4, 6] = "Respuestas";

                //identificacion
                oSheet.Cells[2, 4] = expData.PresentationName;
                oSheet.Cells[2, 5] = expData.CreatedAt.ToShortDateString() + " " + expData.CreatedAt.ToShortTimeString();


                //Preguntas/respuestas
                qcolIndex = 6;
                foreach (var q in expData.Questions)
                {
                    oSheet.Cells[3, qcolIndex] = q.Title;
                    oSheet.Cells[4, qcolIndex] = q.GetAnswersText();
                    oSheet.Cells[4, qcolIndex+1] = q.GetAnswersPointsText();

                    qcolIndex += 2;
                }

                //keypads
                qcolIndex = 1;
                int qrowindex = 6;
                foreach (var k in expData.KeypadsData)
                {
                    oSheet.Cells[qrowindex, qcolIndex] = expData.KeypadsData.IndexOf(k).ToString();
                    oSheet.Cells[qrowindex, qcolIndex + 1] = k.TotalPoints;
                    
                    //todo: add cell comment
                    //oSheet.Cells.Range[qrowindex, qcolIndex + 1].AddComment("Puntuación total de cada Participante");
                    oSheet.Cells[qrowindex, qcolIndex + 2] = k.KeyPadId;
                    oSheet.Cells[qrowindex, qcolIndex + 3] = k.FrienlyName;
                    qcolIndex += 4;

                    foreach (var partial in k.PartialPoints)
                    {
                        qcolIndex += 2;
                        oSheet.Cells[qrowindex, qcolIndex] = partial.ToString();
                    }
                    qcolIndex = 1;
                    qrowindex += 1;
                }

                //cell formats
                oSheet.get_Range("A1", "Z100").Columns.AutoFit();
                oSheet.get_Range("F1", "F100").ColumnWidth = 20;
                oSheet.get_Range("H1", "H100").ColumnWidth = 20;
                oSheet.get_Range("J1", "J100").ColumnWidth = 20;
                oSheet.get_Range("L1", "L100").ColumnWidth = 20;
                oSheet.get_Range("N1", "N100").ColumnWidth = 20;
                oSheet.get_Range("P1", "P100").ColumnWidth = 20;
                oSheet.get_Range("R1", "R100").ColumnWidth = 20;
                oSheet.get_Range("T1", "T100").ColumnWidth = 20;
                oSheet.get_Range("V1", "V100").ColumnWidth = 20;
                oSheet.get_Range("X1", "X100").ColumnWidth = 20;
                oSheet.get_Range("Z1", "Z100").ColumnWidth = 20;

                oSheet.get_Range("A4", "Z4").Rows.AutoFit();

                //Make sure Excel is visible and give the user control
                //of Microsoft Excel's lifetime.
                oXL.Visible = true;
                oXL.UserControl = true;

            }
            catch (Exception theException)
            {
                String errorMessage;
                errorMessage = "Error: ";
                errorMessage = String.Concat(errorMessage, theException.Message);
                errorMessage = String.Concat(errorMessage, " Line: ");
                errorMessage = String.Concat(errorMessage, theException.Source);

                MessageBox.Show(errorMessage, "Error");
            }
        }
    }
}
