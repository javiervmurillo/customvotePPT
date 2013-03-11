using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CustomVote.AddIn.PowerPoint2010.Helpers;
using CustomVote.AddIn.PowerPoint2010.Results.strategies;

namespace CustomVote.AddIn.PowerPoint2010.Results.Data
{
    [Serializable]
    public class ResultSlideConfiguration
    {
        public ResultSlideConfiguration()
        {
            IsNew = true;
        }
        public int SlideId { get; set; }
        [NonSerialized]
        public Microsoft.Office.Interop.PowerPoint.Slide _SlideAssociated;

        public Microsoft.Office.Interop.PowerPoint.Slide SlideAssociated
        {
            get { return _SlideAssociated; }
            set { _SlideAssociated = value; }
        }

        public decimal Decimals { get; set; }
        public ResultType ResultType { get; set; }
        public HistValueOrder ValueOrder { get; set; }
        public HistValueType Valuetype { get; set; }
        public RankingConfig RankingConfig { get; set; }
        public CrossComparizonConfig CrossCompConfig { get; set; }
        public NormalConfig NormalConfig { get; set; }


        IResultStrategy ResultStrategy 
        {
            get 
            {
                IResultStrategy strategy = null;
                switch (this.ResultType)
                {
                    case ResultType.Normal:
                        strategy =  new NormalStrategy();
                        break;
                    case ResultType.Ranking:
                        strategy = new RankingStrategy();
                        break;
                    case ResultType.Espejo:
                        strategy = new MirrorStrategy();
                        break;
                    case ResultType.Cruza:
                        strategy = new CrossComparisonStrategy();
                        break;
                }
                return strategy;
            }
        }

        public List<SelectedQuetions> SelectedQuestions { get; set; }

        public bool IsNew { get; set; }

        public int HistWidthPercent { get; set; }

        

        

        internal void CreateTitle()
        {
            this.ResultStrategy.CreateTitle(this);
        }

        internal void Ordering()
        {
            this.ResultStrategy.Ordering(this);
        }

        internal void ResizeCharts()
        {
            this.ResultStrategy.ResizeCharts(this);
        }

        internal void UpdateChartValues()
        {
            this.ResultStrategy.UpdateSlide(this);
        }

        internal void UdateChart()
        {
            UpdateChartValues();

            ResizeCharts();
            Ordering();
        }

        internal void DrawSlide(List<ItemList> lstQuestions)
        {
            this.ResultStrategy.DrawSlide(this, lstQuestions);
        }

    }
}
