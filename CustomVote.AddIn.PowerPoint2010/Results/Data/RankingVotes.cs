using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CustomVote.AddIn.PowerPoint2010.Results.Data
{
    public class RankingVotes
    {

        public RankingVotes(int keyId, double timeSum, int pointsSum)
        {
            KeyId = keyId;
            CorrectAnswerCount = 1;
            TimeSum = timeSum;
            this.PointsSum = pointsSum;
        }
        public int KeyId { get; set; }
        public int CorrectAnswerCount { get; set; }
        public double TimeSum { get; set; }
        public int PointsSum { get; set; }


        internal double GetPercentValueFrom(List<RankingVotes> rvotes, int decimals)
        {
            if (!rvotes.Contains(this))
                return 0;
            var sum = rvotes.Sum(x => x.CorrectAnswerCount);
            var percent = Math.Round(this.CorrectAnswerCount * 100.0 / sum, decimals);

            return percent;
        }

        internal double GetPercentValueByPointsFrom(List<RankingVotes> rvotes, int decimals)
        {
            if (!rvotes.Contains(this))
                return 0;
            var sum = rvotes.Sum(x => x.PointsSum);
            var percent = Math.Round(this.PointsSum * 100.0 / sum, decimals);

            return percent;
        }

    }
}
