using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CustomVote.AddIn.PowerPoint2010.Helpers;

namespace CustomVote.AddIn.PowerPoint2010.Results.Data
{
    [Serializable]
    public class NormalAnswerVotedEntity : AnswerVotedEntityBase
    {

        public Questions.Data.AnswerEntity AnswerAssociated { get; set; }

        
    }
}
