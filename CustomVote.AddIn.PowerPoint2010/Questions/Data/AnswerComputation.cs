using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CustomVote.AddIn.PowerPoint2010.Questions.Data
{
    [Serializable]
    public class AnswerComputation
    {
        public ComputationType Type { get; set; }
        public bool TakeTime { get; set; }

        public AnswerComputation()
        {
            Type = ComputationType.CollectAnswerPoints;
            TakeTime = false;
        }

        public int GetIntType()
        {
            return (int)Type;
        }
    }
}
