using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CustomVote.AddIn.PowerPoint2010.Helpers;

namespace CustomVote.AddIn.PowerPoint2010.Results.Data
{
    [Serializable]
    public class SelectedQuetions
    {
        public ItemList QuestionRelation { get; set; }
        public List<NormalAnswerVotedEntity> AnswersVoted { get; set; }

        public List<MirrorAnswerVotedEntity> MirrorAnswersVoted { get; set; }
    }
}
