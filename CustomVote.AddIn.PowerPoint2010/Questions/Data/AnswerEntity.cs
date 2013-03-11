using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CustomVote.AddIn.PowerPoint2010.Hardware;

namespace CustomVote.AddIn.PowerPoint2010.Questions.Data
{
    [Serializable]
    public class AnswerEntity
    {
        public AnswerEntity(QuestionSlideConfiguration parent)
        {
            this.Parent = parent;
            Votes = new List<VotesFlat>();
        }
        public string TextToShow
        {
            get
            {
                if(Id < 10)
                    return " "+Id + ". " + Text;
                return Id + ". "+Text;
            }
        }
        public int Id { get; set; }
        public int Points { get; set; }
        public string Text { get; set; }
        public int VotesCount { get; set; }
        public double Time { get; set; }
        public List<VotesFlat> Votes { get; set; }

        [NonSerialized]
        public Microsoft.Office.Interop.PowerPoint.Shape _AnswerTextBox;

        public Microsoft.Office.Interop.PowerPoint.Shape AnswerTextBox
        {
            get { return _AnswerTextBox; }
            set { _AnswerTextBox = value; }
        }

        public QuestionSlideConfiguration Parent { get; private set; }

        internal double GetPercentValue(int cantDecimals)
        {
            try
            {
                int points = this.Points == 0 ? 1 : this.Points;
                int totalPoints = Parent.GetTotalNumvalues();
                int answerValue = points * VotesCount;

                var val = Math.Round(answerValue * 100.0 / totalPoints,cantDecimals);
                return double.IsNaN(val) ? 0 : val;
            }
            catch (DivideByZeroException)
            {
                return 0;
            }
            
        }
        internal double GetNumericValue(int cantDecimals)
        {
            try
            {
                int points = this.Points == 0 ? 1 : this.Points;
                double answerValue = points * VotesCount;

                return Math.Round(answerValue, cantDecimals);
            }
            catch (DivideByZeroException)
            {
                return 0;
            }

        }

        internal string GetValue(Results.Data.HistValueType histValueType, int cantDecimals)
        {
            string value = "";
            switch (histValueType)
            {
                case CustomVote.AddIn.PowerPoint2010.Results.Data.HistValueType.Porcentual:
                    var porcValue = GetPercentValue(cantDecimals);
                    if (double.IsNaN(porcValue))
                        porcValue = 0;
                    value = porcValue.ToString() + "%";
                    break;
                case CustomVote.AddIn.PowerPoint2010.Results.Data.HistValueType.Numérico:
                    var numValue = GetNumericValue(cantDecimals);
                    if (double.IsNaN(numValue))
                        numValue = 0;
                    value = numValue.ToString();
                    break;
                default:
                    break;
            }
            if (ShouldTakeTime())
                value += " (" + this.Time + " s)";
            return value;
        }



        internal float GetValueFontSize()
        {
            if (ShouldTakeTime())
                return 14;
            return 20;
        }

        private bool ShouldTakeTime()
        {
            if (Parent == null) 
                return false;
            return Parent.Computation.TakeTime;
        }

        internal double GetNumericValueForOrder(int cantDecimals)
        {
            var numvalue = GetNumericValue(cantDecimals);

            if(this.Parent.Computation.TakeTime)
                numvalue += this.Time;

            return numvalue;
        }

        public int AnswerTextBoxIndex { get; set; }

        internal double GetCoincidencesFor(AnswerEntity toCompare)
        {
            double count = 0;

            foreach (var local in this.Votes)
            {
                foreach (var item in toCompare.Votes)
                {
                    if (local.KeyId == item.KeyId)
                        count += 1;
                }
            }

            return count;
        }
    }
}
