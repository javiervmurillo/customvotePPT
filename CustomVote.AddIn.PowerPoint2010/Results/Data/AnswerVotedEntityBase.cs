using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CustomVote.AddIn.PowerPoint2010.Results.Data
{
    [Serializable]
    public class AnswerVotedEntityBase
    {
        [NonSerialized]
        private Microsoft.Office.Interop.PowerPoint.Shape _AnswerTextBox;

        public Microsoft.Office.Interop.PowerPoint.Shape AnswerTextBox
        {
            get { return _AnswerTextBox; }
            set { _AnswerTextBox = value; }
        }

        [NonSerialized]
        private Microsoft.Office.Interop.PowerPoint.Shape _AnswerChart;

        public Microsoft.Office.Interop.PowerPoint.Shape AnswerChart
        {
            get { return _AnswerChart; }
            set { _AnswerChart = value; }
        }
        [NonSerialized]
        private Microsoft.Office.Interop.PowerPoint.Shape _AnswerChartValue;

        public Microsoft.Office.Interop.PowerPoint.Shape AnswerChartValue
        {
            get { return _AnswerChartValue; }
            set { _AnswerChartValue = value; }
        }

        public int AnswerTextBoxIndex { get; set; }

        public int AnswerChartIndex { get; set; }

        public int AnswerChartValueIndex { get; set; }
    }
}
