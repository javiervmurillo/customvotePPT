using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CustomVote.AddIn.PowerPoint2010.Properties;
using CustomVote.AddIn.PowerPoint2010.Questions.Data;
using Microsoft.Office.Interop.PowerPoint;
using System.Reflection;
using System.IO;

namespace CustomVote.AddIn.PowerPoint2010.Helpers
{
    public static class PowerPointHelper
    {
        private static Microsoft.Office.Interop.PowerPoint.Application _app = Globals.ThisAddIn.Application;
        public const float SlideWidth = 600;

        public static Microsoft.Office.Interop.PowerPoint.Slide CreateSlideOn(int slideId)
        {
            var slide = _app.ActivePresentation.Slides.FindBySlideID(slideId);
            slide.Layout = PpSlideLayout.ppLayoutBlank;
            //var index = slide.SlideIndex;

            //slide.Delete();

            //_app.ActivePresentation.Slides.AddSlide(index, _app.ActivePresentation.SlideMaster.CustomLayouts[7]);

            //slide = _app.ActivePresentation.Slides[index];

            return slide;
        }


        internal static Shape CreateTextboxOn(Microsoft.Office.Interop.PowerPoint.Slide slide,
            float left, float top, float width, float height, string text, float fontSize, 
            Microsoft.Office.Interop.PowerPoint.PpParagraphAlignment alignment, out int index)
        {
            var textBox = slide.Shapes.AddTextbox(Microsoft.Office.Core.MsoTextOrientation.msoTextOrientationHorizontal, left, top, width, height);

            textBox.TextFrame.AutoSize = PpAutoSize.ppAutoSizeNone;
            textBox.TextFrame.WordWrap = Microsoft.Office.Core.MsoTriState.msoFalse;

            Microsoft.Office.Interop.PowerPoint.TextRange txtLabel = textBox.TextFrame.TextRange;

            txtLabel.Text = text;
            txtLabel.Font.Name = "Arial";
            txtLabel.Font.Size = fontSize;
            txtLabel.ParagraphFormat.Alignment = alignment;
            
            index = GetShapeIndex(slide, textBox);

            return textBox;
        }

        internal static Shape CreateButtonGetVotesOn(Microsoft.Office.Interop.PowerPoint.Slide slide, out int index, bool unCheck = false)
        {
            var myDocs = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            var di = Directory.CreateDirectory(myDocs + "\\CustomVoteTmp");

            Bitmap bmp = Properties.Resources.LogoOK;
            string imageFileName = di.FullName + "\\AnswerCheck.png";
            bmp.Save(imageFileName, System.Drawing.Imaging.ImageFormat.Png);

            Bitmap bmp2 = Properties.Resources.LogoCancel;
            string imageFileName2 = di.FullName + "\\AnswerUnCheck.png";
            bmp2.Save(imageFileName2, System.Drawing.Imaging.ImageFormat.Png);

            var image = slide.Shapes.AddPicture((unCheck ? imageFileName2 : imageFileName), Microsoft.Office.Core.MsoTriState.msoTrue, Microsoft.Office.Core.MsoTriState.msoTrue, 700, 0, 20, 20);

            
            Microsoft.Vbe.Interop.VBComponent oModule = Globals.ThisAddIn.Application.VBE.ActiveVBProject.VBComponents.Add(Microsoft.Vbe.Interop.vbext_ComponentType.vbext_ct_StdModule);

            string VBCode = "Private Declare Function GetAsyncKeyState Lib \"user32\" (ByVal vKey As Long) As Integer\n" +
                            "Dim activeNext As Boolean\n" +
                            "Sub CustomVoteRetrieveVotes()\n" +
                                "Dim addIn As COMAddIn\n" +
                                "Dim automationObject As Object\n" +
                                "Set addIn = Application.COMAddIns(\"CustomVote.AddIn.PowerPoint2010\")\n" +
                                "Set automationObject = addIn.Object\n" +
                                "automationObject.RetrieveVotes\n" +
                            "End Sub\n" +
                            "Sub OnSlideShowPageChange(ByVal Wn As SlideShowWindow)\n" +
                                    "If GetPressedKey = 83 OR GetPressedKey = 115 Then\n" +
                                    "ActivePresentation.SlideShowWindow.View.GotoSlide ActivePresentation.SlideShowWindow.View.Slide.SlideIndex - 1\n" +
                                    "CustomVoteRetrieveVotes\n" +
                                "End If\n" +
                            "End Sub\n" +
                            "Function GetPressedKey() As Integer\n" +
                                "For Cnt = 32 To 128\n" +
                                "'Get the keystate of a specified key\n" +
                                "If GetAsyncKeyState(Cnt) <> 0 Then\n" +
                                "'GetPressedKey = Chr$(Cnt)\n" +
                                "GetPressedKey = Cnt\n" +
                                "Exit For\n" +
                                "End If\n" +
                                "Next Cnt\n" +
                            "End Function\n";

            oModule.CodeModule.AddFromString(VBCode);
            
            image.ActionSettings[PpMouseActivation.ppMouseClick].Action = PpActionType.ppActionRunMacro;
            image.ActionSettings[PpMouseActivation.ppMouseClick].Run = "CustomVoteRetrieveVotes";

            index = GetShapeIndex(slide, image);
            
            return image;           
        }

        public static void AddNewSlide()
        {
            var index = _app.ActivePresentation.Slides.Count + 1;
            var slide = _app.ActivePresentation.Slides.AddSlide(index, _app.ActivePresentation.SlideMaster.CustomLayouts[7]);
            slide.Select();
        }

        internal static int GetWidthByPercent(int maxPercent, int percentValue)
        {
            var max = SlideWidth * maxPercent / 100;
            var width = max * percentValue / 100;

            return Convert.ToInt32(width);
        }
        internal static int GetLeftByPercent(int percent, int mult = 1)
        {
            var max = SlideWidth * percent / 100;
            return Convert.ToInt32(SlideWidth - (max * mult));
        }
        internal static Shape CreateShapeOn(Slide slide, int left, float top, int width, int height, out int index)
        {
            var shape = slide.Shapes.AddShape(Microsoft.Office.Core.MsoAutoShapeType.msoShapeRectangle, left, top, width, height);
            index = GetShapeIndex(slide, shape);
            return shape;
        }

        internal static Shape CreateChartOn(Slide slide, int left, float top, int width, int height, out int index)
        {
            var shape = slide.Shapes.AddChart(Microsoft.Office.Core.XlChartType.xlBarClustered, left, top, width, height);
            index = GetShapeIndex(slide, shape);
            return shape;
        }

        public static int GetShapeIndex(Slide slide, Shape shape)
        {
            for (int i = 1; i <= slide.Shapes.Count; i++)
            {
                if (slide.Shapes[i] == shape)
                    return i;
            }
            return -1;
        }

        internal static Slide FindSlideById(int slideId)
        {
            return _app.ActivePresentation.Slides.FindBySlideID(slideId);
        }

        internal static Shape FindShapeById(int slideId, int shapeIndex)
        {
            var slide = FindSlideById(slideId);
            var shape = slide.Shapes[shapeIndex];

            return shape;
        }

        internal static Shape CreateAnimatedStopTimerOn(Slide slide, out int index)
        {
            var myDocs = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            var di = Directory.CreateDirectory(myDocs + "\\CustomVoteTmp");

            Bitmap bmp = Properties.Resources.Crono0;
            string imageFileName = di.FullName + "\\Crono0.png";
            bmp.Save(imageFileName, System.Drawing.Imaging.ImageFormat.Png);

            var image = slide.Shapes.AddPicture(imageFileName, Microsoft.Office.Core.MsoTriState.msoTrue, Microsoft.Office.Core.MsoTriState.msoTrue, 645, 5, 40, 40);

            index = GetShapeIndex(slide, image);

            return image;   
        }

        internal static Shape CreateAnimatedTimerOn(Slide slide, Shape timerStopShape, int frame)
        {
            var myDocs = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            var di = Directory.CreateDirectory(myDocs + "\\CustomVoteTmp");

            //Bitmap bmp = Properties.Resources.Chronometer_1;
            Bitmap bmp = GetAnimationFrame(frame);
            string imageFileName = di.FullName + "\\Crono"+frame+".png";
            bmp.Save(imageFileName, System.Drawing.Imaging.ImageFormat.Png);

            var image = slide.Shapes.AddPicture(imageFileName, Microsoft.Office.Core.MsoTriState.msoTrue, Microsoft.Office.Core.MsoTriState.msoTrue, timerStopShape.Left, timerStopShape.Top, timerStopShape.Width, timerStopShape.Height);
            
            

            return image;
        }

        private static Bitmap GetAnimationFrame(int frame)
        {
            //var type = typeof(Properties.Resources);
            //var prop = type.GetProperty("Crono" + Crono.ToString(), BindingFlags.Public | BindingFlags.Static | BindingFlags.DeclaredOnly);
            //Bitmap image = (Bitmap)prop.GetValue(Resources, BindingFlags.Static, null, null, CultureInfo.CurrentCulture);

            //return image;
            switch (frame)
            {
                case 0:
                    return Properties.Resources.Crono0;break;
                case 1:
                    return Properties.Resources.Crono1;break;
                case 2:
                    return Properties.Resources.Crono2;break;
                case 3:
                    return Properties.Resources.Crono3;break;
                case 4:
                    return Properties.Resources.Crono4;break;
                case 5:
                    return Properties.Resources.Crono5;break;
                case 6:
                    return Properties.Resources.Crono6;break;
                case 7:
                    return Properties.Resources.Crono7;break;
                case 8:
                    return Properties.Resources.Crono8;break;
                case 9:
                    return Properties.Resources.Crono9;break;
                case 10:
                    return Properties.Resources.Crono10;break;
                case 11:
                    return Properties.Resources.Crono11;break;
                case 12:
                    return Properties.Resources.Crono12;break;
                case 13:
                    return Properties.Resources.Crono13;break;
                case 14:
                    return Properties.Resources.Crono14;break;
                case 15:
                    return Properties.Resources.Crono15;break;
                case 16:
                    return Properties.Resources.Crono16;break;
                case 17:
                    return Properties.Resources.Crono17;break;
                case 18:
                    return Properties.Resources.Crono18;break;
                case 19:
                    return Properties.Resources.Crono19;break;
                case 20:
                    return Properties.Resources.Crono20;break;
                case 21:
                    return Properties.Resources.Crono21;break;
                case 22:
                    return Properties.Resources.Crono22;break;
                case 23:
                    return Properties.Resources.Crono23;break;
                case 24:
                    return Properties.Resources.Crono24;break;
                case 25:
                    return Properties.Resources.Crono25;break;
                case 26:
                    return Properties.Resources.Crono26;break;
                case 27:
                    return Properties.Resources.Crono27;break;
                case 28:
                    return Properties.Resources.Crono28;break;
                case 29:
                    return Properties.Resources.Crono29;break;
                case 30:
                    return Properties.Resources.Crono30;break;
            }
            return Properties.Resources.Crono0;
        }
    }
}
