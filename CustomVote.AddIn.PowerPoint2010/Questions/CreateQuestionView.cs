using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CustomVote.AddIn.PowerPoint2010.Properties;
using CustomVote.AddIn.PowerPoint2010.Questions.Data;
using CustomVote.AddIn.PowerPoint2010.Helpers;

namespace CustomVote.AddIn.PowerPoint2010.Questions
{
    public partial class CreateQuestionView : Form
    {
        Microsoft.Office.Interop.PowerPoint.Application _app;
        QuestionSlideConfiguration _currentConfiguration;
        public CreateQuestionView()
        {
            InitializeComponent();
            grdQuestions.AutoGenerateColumns = false;
            _app = Globals.ThisAddIn.Application;
            InitQuestionSlide();
        }

        private void InitQuestionSlide()
        {
            try
            {
                ValidateSlide();
                _app.PresentationBeforeClose += new Microsoft.Office.Interop.PowerPoint.EApplication_PresentationBeforeCloseEventHandler(_app_PresentationBeforeClose);
                
                var slideId = ((Microsoft.Office.Interop.PowerPoint.Slide)_app.ActiveWindow.View.Slide).SlideID;
                if (!IsQuestionSlide(slideId))
                {
                    MessageBox.Show(Resources.ResourceManager.GetString("Msg_IsNotQuestionSlide"),"Error", MessageBoxButtons.OK,MessageBoxIcon.Error);
                    throw new Exception(Resources.ResourceManager.GetString("Msg_IsNotQuestionSlide"));
                }

                var config = Globals.ThisAddIn.Session.GetQuestionSlideConfiguration(slideId);

                SetConfiguration(config);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        void _app_PresentationBeforeClose(Microsoft.Office.Interop.PowerPoint.Presentation Pres, ref bool Cancel)
        {
            Globals.ThisAddIn.ClearSession();
        }

        private void SetConfiguration(Data.QuestionSlideConfiguration config)
        {
            this.grdQuestions.DataSource = config.Answers;
            this.txtQuestionTitle.Text = config.QuetionTitle;
            this.cboPuntCalc.SelectedIndex = config.Computation.GetIntType();
            this.chkAcumTimePoints.Checked = config.Computation.TakeTime;
            this.rdbCronoAnimacion.Checked = config.ShowCronometerAnimation;
            this.chkVotesCounter.Checked = config.IsNew ? true : config.ShowCounterVotes;
            _currentConfiguration = config;
        }

        private bool IsQuestionSlide(int slideId)
        {
            return Globals.ThisAddIn.Session.IsQuestionSlide(slideId);
        }

        private void ValidateSlide()
        {
            var presentacion = _app.ActivePresentation;
            var slidesCounts = _app.ActivePresentation.Slides.Count;
            if (slidesCounts == 0)
            {
                MessageBox.Show("Agregue una nueva diapositiva", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                throw new Exception("Slides empty");
            }
        }

        private void btnQueationApply_Click(object sender, EventArgs e)
        {
            if (_currentConfiguration.IsNew)
                CreateNewQuestionSlide();
            else
                SavequestionChanges();
        }

        private void SavequestionChanges()
        {
            _currentConfiguration.QuetionTitle = txtQuestionTitle.Text;
            _currentConfiguration.Computation.Type = (ComputationType)cboPuntCalc.SelectedIndex;
            _currentConfiguration.Computation.TakeTime = chkAcumTimePoints.Checked;
            _currentConfiguration.ShowCronometerAnimation = rdbCronoAnimacion.Checked;
            _currentConfiguration.ShowCounterVotes = chkVotesCounter.Checked;
            _currentConfiguration.ShowTimeOnShape("00:00:00", 0);
            
            _currentConfiguration.UpdateAddinChanges();
        }

        private void CreateNewQuestionSlide()
        {
            _currentConfiguration.QuetionTitle = txtQuestionTitle.Text;
            var slide = PowerPointHelper.CreateSlideOn(_currentConfiguration.SlideId);
            int questionTitleIndex;
            var questionTitle = PowerPointHelper.CreateTextboxOn(slide, 50, 20, 600, 50,
                                            _currentConfiguration.QuetionTitle, 36,
                                            Microsoft.Office.Interop.PowerPoint.PpParagraphAlignment.ppAlignCenter, out questionTitleIndex);
            _currentConfiguration.SlideAssociated = slide;

            _currentConfiguration.QuetionTitleTextBoxIndex = questionTitleIndex;
            _currentConfiguration.QuetionTitleTextBox = questionTitle;

            float initialTop = 110;
            foreach (var answer in _currentConfiguration.Answers)
            {
                int index;
                var ansObj = PowerPointHelper.CreateTextboxOn(slide, 50, initialTop, 600, 35,
                                            answer.TextToShow, 24,
                                            Microsoft.Office.Interop.PowerPoint.PpParagraphAlignment.ppAlignLeft, out index);
                initialTop += 50;
                answer.AnswerTextBoxIndex = index;
                answer.AnswerTextBox = ansObj;
            }
            _currentConfiguration.TopLastQuestion = initialTop;

            //checkbuton
            int indexForCheckButton;
            _currentConfiguration.CheckButtonShape = _currentConfiguration.CreateCheckButton(out indexForCheckButton);
            _currentConfiguration.IndexForCheckButtonShape = indexForCheckButton;

            //timer
            _currentConfiguration.ShowCronometerAnimation = rdbCronoAnimacion.Checked;
            int indexTimer;
            _currentConfiguration.TimerShape  = _currentConfiguration.CreateTimerShape(out indexTimer);
            _currentConfiguration.IndexForTimer = indexTimer;

            //votes counter
            _currentConfiguration.ShowCounterVotes = chkVotesCounter.Checked;
            int indexCountVotes;
            _currentConfiguration.CountVotesShape = _currentConfiguration.CreateCountVotesShape(out indexCountVotes);
            _currentConfiguration.IndexCountVotes = indexCountVotes;


            if (_currentConfiguration.ShowCronometerAnimation)
            {
                int indexAnimatedTimer;
                _currentConfiguration.AnimatedTimerShape = _currentConfiguration.CreateAnimatedTimerShape(out indexAnimatedTimer);
                _currentConfiguration.IndexForAnimatedTimer = indexAnimatedTimer;
            }

            //computation
            _currentConfiguration.Computation.Type = (ComputationType)cboPuntCalc.SelectedIndex;
            _currentConfiguration.Computation.TakeTime = chkAcumTimePoints.Checked;

            Globals.ThisAddIn.Session.SaveQuestionConfiguration(_currentConfiguration);
        }

        private void btnQuestionCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnEditAnswer_Click(object sender, EventArgs e)
        {
            EditAnswer();
        }
        private void grdQuestions_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            EditAnswer();
        }

        private void EditAnswer()
        {
            var answer = grdQuestions.SelectedRows[0].DataBoundItem;
            var EditView = new AnswerView(answer as AnswerEntity);
            var dialogResult = EditView.ShowDialog();
            if (dialogResult == System.Windows.Forms.DialogResult.OK)
            {
                grdQuestions.DataSource = null;
                _currentConfiguration.UpdateAddinChanges();
                grdQuestions.DataSource = _currentConfiguration.Answers;
            }
        }

        private void btnNewAnswer_Click(object sender, EventArgs e)
        {
            var answer = new AnswerEntity(_currentConfiguration);
            answer.Id = _currentConfiguration.GetNextAnswerId();
            var EditView = new AnswerView(answer);
            var dialogResult = EditView.ShowDialog();
            if (dialogResult == System.Windows.Forms.DialogResult.OK)
            {
                var slide = _currentConfiguration.SlideAssociated;
                var top = _currentConfiguration.TopLastQuestion;

                if (!_currentConfiguration.IsNew)
                {
                    int index;
                    var ansObj = PowerPointHelper.CreateTextboxOn(slide, 50, top, 600, 35,
                                                answer.TextToShow, 24,
                                                Microsoft.Office.Interop.PowerPoint.PpParagraphAlignment.ppAlignLeft, out index);
                    answer.AnswerTextBox = ansObj;
                    answer.AnswerTextBoxIndex = index;
                }

                _currentConfiguration.TopLastQuestion += 50;
                grdQuestions.DataSource = null;
                _currentConfiguration.Answers.Add(answer);
                grdQuestions.DataSource = _currentConfiguration.Answers;
            }
        }

        private void btnDeleteAnswer_Click(object sender, EventArgs e)
        {
            var dialogResult = MessageBox.Show("¿Desea eliminar la respuesta seleccionada?", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == System.Windows.Forms.DialogResult.Yes)
            {
                var answer = grdQuestions.SelectedRows[0].DataBoundItem as AnswerEntity;

                this.grdQuestions.DataSource = null;
                _currentConfiguration.DeleteAnswer(answer);
                this.grdQuestions.DataSource = _currentConfiguration.Answers;
                _currentConfiguration.UpdateAddinChanges();
            }
        }

        

        
    }
}
