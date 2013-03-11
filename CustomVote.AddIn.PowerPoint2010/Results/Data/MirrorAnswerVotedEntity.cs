using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CustomVote.AddIn.PowerPoint2010.Helpers;

namespace CustomVote.AddIn.PowerPoint2010.Results.Data
{
    [Serializable]
    public class MirrorAnswerVotedEntity : NormalAnswerVotedEntity
    {

        public Questions.Data.AnswerEntity AnswerAssociated2 { get; set; }

        [NonSerialized]
        private Microsoft.Office.Interop.PowerPoint.Shape _AnswerChart2;

        public Microsoft.Office.Interop.PowerPoint.Shape AnswerChart2
        {
            get { return _AnswerChart2; }
            set { _AnswerChart2 = value; }
        }
        [NonSerialized]
        private Microsoft.Office.Interop.PowerPoint.Shape _AnswerChartValue2;

        public Microsoft.Office.Interop.PowerPoint.Shape AnswerChartValue2
        {
            get { return _AnswerChartValue2; }
            set { _AnswerChartValue2 = value; }
        }

        public int AnswerChart2Index { get; set; }

        public int AnswerChartValue2Index { get; set; }
    }
}
