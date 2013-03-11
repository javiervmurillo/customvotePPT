using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CustomVote.AddIn.PowerPoint2010.Results.Data
{
    [Serializable]
    public class RankingConfig
    {
        public RankingConfig()
        {
            TopRanking = 5;
            ShowTime = false;
            RankigVotedShapes = new List<RankingAnswerVotedEntity>();
        }
        public int TopRanking { get; set; }
        public bool ShowTime { get; set; }
        public bool ShowPointsAcum { get; set; }

        public List<RankingAnswerVotedEntity> RankigVotedShapes { get; set; }

        internal void ResetValues()
        {
            foreach (var item in RankigVotedShapes)
            {
                item.AnswerTextBox.TextFrame.TextRange.Text = "#";
                item.AnswerChartValue.TextFrame.TextRange.Text = "0";

                item.AnswerChart.Width = 0;
            }
        }



    }
}
