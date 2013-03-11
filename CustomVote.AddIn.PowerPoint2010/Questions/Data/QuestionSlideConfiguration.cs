using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Office.Interop.PowerPoint;
using System.Runtime.InteropServices;
using CustomVote.AddIn.PowerPoint2010.Helpers;
using CustomVote.AddIn.PowerPoint2010.Results.Data;

namespace CustomVote.AddIn.PowerPoint2010.Questions.Data
{
    [Serializable]
    public class QuestionSlideConfiguration
    {
        public int SlideId { get; set; }
        public string QuetionTitle { get; set; }
        public List<AnswerEntity> Answers { get; set; }
        public bool IsNew { get; set; }
        public AnswerComputation Computation { get; set; }
        public bool ShowCronometerAnimation { get; set; }
        public bool ShowCounterVotes { get; set; }
         

        [NonSerialized]
        public Microsoft.Office.Interop.PowerPoint.Slide _SlideAssociated;

        public Microsoft.Office.Interop.PowerPoint.Slide SlideAssociated
        {
            get { return _SlideAssociated; }
            set { _SlideAssociated = value; }
        }
        [NonSerialized]
        public Shape _QuetionTitleTextBox;
        

        

        public Shape QuetionTitleTextBox
        {
            get { return _QuetionTitleTextBox; }
            set { _QuetionTitleTextBox = value; }
        }

        internal static QuestionSlideConfiguration GenerateDefaultConfig(int slideId)
        {
            var config = new QuestionSlideConfiguration()
            {
                SlideId = slideId,
                //SlideAssociated = PowerPointHelper.FindSlideById(slideId),
                QuetionTitle = "Pregunta 1",
                Answers = new List<AnswerEntity>(),
                IsNew = true,
                Computation = new AnswerComputation()
            };

            config.Answers.Add(new AnswerEntity(config) { Id = 1, Points = 0, Text = "Respuesta A", VotesCount = 0, Time=0});
            config.Answers.Add(new AnswerEntity(config) { Id = 2, Points = 0, Text = "Respuesta B", VotesCount = 0, Time = 0 });
            config.Answers.Add(new AnswerEntity(config) { Id = 3, Points = 0, Text = "Respuesta C", VotesCount = 0, Time = 0 });
            config.Answers.Add(new AnswerEntity(config) { Id = 4, Points = 0, Text = "Respuesta D", VotesCount = 0, Time = 0 });

            return config;
        }

        internal void UpdateUserChanges()
        {
            if (this.QuetionTitleTextBox != null)
                this.QuetionTitle = this.QuetionTitleTextBox.TextFrame.TextRange.Text;
            var lstAnsToRemove = new List<AnswerEntity>();
            foreach (var ans in this.Answers)
            {
                if (ans.AnswerTextBox != null)
                {
                    try
                    {
                        ans.Text = ans.AnswerTextBox.TextFrame.TextRange.Text.Substring(4);
                    }
                    catch (COMException ex)
                    {
                        lstAnsToRemove.Add(ans);
                    }
                }
            }
            foreach (var r in lstAnsToRemove)
            {
                Answers.Remove(r);
            }
        }

        internal void UpdateAddinChanges()
        {
            if (this.QuetionTitleTextBox != null)
                this.QuetionTitleTextBox.TextFrame.TextRange.Text = this.QuetionTitle;
            
            foreach (var ans in this.Answers)
            {
                if (ans.AnswerTextBox != null)
                {
                    ans.AnswerTextBox.TextFrame.TextRange.Text = ans.TextToShow;
                }   
            }
        }

        internal int GetNextAnswerId()
        {
            var id = Answers.Select(x => x.Id).Max() + 1;
            return id;
        }

        internal void DeleteAnswer(AnswerEntity answer)
        {
            if (answer.AnswerTextBox != null)
                answer.AnswerTextBox.Delete();

            Answers.ForEach(x => DecrementId(x, answer.Id));

            Answers.Remove(answer);
        }
        private void DecrementId(AnswerEntity answer, int refId)
        {
            if (answer.Id > refId)
                answer.Id--;
        }

        public float TopLastQuestion { get; set; }

        internal int GetTotalNumvalues()
        {
            int totalNumValues = 0;
            foreach (var a in Answers)
            {
                int points = a.Points == 0 ? 1 : a.Points;
                totalNumValues += points * a.VotesCount;
            }
            return totalNumValues;
        }

        internal Shape CreateCheckButton(out int index)
        {
            var imageVotes = PowerPointHelper.CreateButtonGetVotesOn(this.SlideAssociated, out index,true);
            return imageVotes;
        }

        internal void ChangeCheckButonToUncheck()
        {
            this.CheckButtonShape.Delete();
            this.CheckButtonShape = null;

            int index;
            var uncheckImage = PowerPointHelper.CreateButtonGetVotesOn(this.SlideAssociated, out index, true);
            this.IndexForCheckButtonShape = index;
            this.CheckButtonShape = uncheckImage;

            this.IndexForTimer = PowerPointHelper.GetShapeIndex(this.SlideAssociated, this.TimerShape);
        }

        internal void ChangeUnCheckButonToCheck()
        {
            this.CheckButtonShape.Delete();
            this.CheckButtonShape = null;

            int index;
            var checkImage = PowerPointHelper.CreateButtonGetVotesOn(this.SlideAssociated, out index);
            this.IndexForCheckButtonShape = index;
            this.CheckButtonShape = checkImage;
            
            this.IndexForTimer = PowerPointHelper.GetShapeIndex(this.SlideAssociated, this.TimerShape);
            this.IndexCountVotes = PowerPointHelper.GetShapeIndex(this.SlideAssociated, this.CountVotesShape);
        }

        internal List<Hardware.VotesFlat> GetVotesFromCorrectAnswer(out AnswerEntity correctAnswer)
        {
            correctAnswer = this.Answers.OrderByDescending(x => x.Points).FirstOrDefault();
            if (correctAnswer == null)
                return new List<Hardware.VotesFlat>();

            return correctAnswer.Votes;
        }

        public int QuetionTitleTextBoxIndex { get; set; }

        public bool HasVotes { get; set; }

        [NonSerialized]
        private Shape _checkButtonShape;
        

        public Shape CheckButtonShape
        {
            get { return _checkButtonShape; }
            set { _checkButtonShape = value; }
        }

        public int IndexForCheckButtonShape { get; set; }

        [NonSerialized]
        private Shape _timerShape;
        public Shape TimerShape
        {
            get { return _timerShape; }
            set { _timerShape = value; }
        }
        public int IndexForTimer { get; set; }

        [NonSerialized] 
        private Shape _CountVotesShape;
        public Shape CountVotesShape
        {
            get { return _CountVotesShape; }
            set { _CountVotesShape = value; }
        }

        public int IndexCountVotes { get; set; }

        [NonSerialized]
        private Shape _animatedTimerShape;
        public Shape AnimatedTimerShape
        {
            get { return _animatedTimerShape; }
            set { _animatedTimerShape = value; }
        }
        public int IndexForAnimatedTimer { get; set; }


        internal Shape CreateTimerShape(out int indexTimer)
        {
            int timer = 0;
            string defaultText =  this.ShowCronometerAnimation?string.Empty:"00:00:00\r\n";
            var timerShape = PowerPointHelper.CreateTextboxOn(this.SlideAssociated, 620, 23, 90, 20, defaultText, 14, PpParagraphAlignment.ppAlignCenter, out timer);
            //if (this.ShowCronometerAnimation)
            //{
            //    timerShape.Width = 0;
            //    timerShape.Height = 0;
            //}
            indexTimer = timer;
            return timerShape;
        }

        internal Shape CreateCountVotesShape(out int indexCountVotes)
        {
            string defaultText = ShowCounterVotes? "0 Votos":string.Empty;
            //float width = ShowCounterVotes ? 90 : 0;
            //float heigth = ShowCounterVotes ? 20 : 0;
            var votesShape = PowerPointHelper.CreateTextboxOn(this.SlideAssociated, 620, 43, 90, 20, defaultText, 14, PpParagraphAlignment.ppAlignCenter, out indexCountVotes);

            return votesShape;
        }

        internal Shape CreateAnimatedTimerShape(out int index)
        {
            Shape imageVotes = PowerPointHelper.CreateAnimatedStopTimerOn(this.SlideAssociated, out index);
            return imageVotes;
        }

        internal void ShowTimeOnShape(string time, int votes)
        {
            if (this.TimerShape != null)
            {
                if (!this.ShowCronometerAnimation)
                {
                    this.TimerShape.TextFrame.TextRange.Text = time;// +"\r\n" + votes + " Votos";
                    this.TimerShape.Width = 90;
                    this.TimerShape.Height = 20;

                    if(this.AnimatedTimerShape!=null)
                    {
                        this.AnimatedTimerShape.Width = 0;
                        this.AnimatedTimerShape.Height = 0;
                    }
                }
                else
                {
                    if (this.AnimatedTimerShape == null)
                    {
                        int indexAnimatedTimer;
                        this.AnimatedTimerShape = this.CreateAnimatedTimerShape(out indexAnimatedTimer);
                        this.IndexForAnimatedTimer = indexAnimatedTimer;
                    }
                    else
                    {
                        this.AnimatedTimerShape.Width = 40;
                        this.AnimatedTimerShape.Height = 40;
                    }
                    this.TimerShape.TextFrame.TextRange.Text = string.Empty;//"\r\n" + votes + " Votos";
                    
                    //this.TimerShape.Width = 0;
                    //this.TimerShape.Height = 0;
                }
            }
            RefreshCounterVotes(votes);
        }

        private void RefreshCounterVotes(int votes)
        {
            this.CountVotesShape.TextFrame.TextRange.Text = this.ShowCounterVotes ? (votes + " Votos") : string.Empty;
            //this.CountVotesShape.Width = this.ShowCounterVotes ? 90 : 0;
            //this.CountVotesShape.Height = this.ShowCounterVotes ? 20 : 0;
        }

        internal Shape AnimatingTimer(int frame)
        {
            var shape = PowerPointHelper.CreateAnimatedTimerOn(this.SlideAssociated, this.AnimatedTimerShape, frame);
            return shape;
        }

        
    }
}
