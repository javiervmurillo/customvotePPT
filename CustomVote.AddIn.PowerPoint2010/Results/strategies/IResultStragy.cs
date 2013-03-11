using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CustomVote.AddIn.PowerPoint2010.Results.Data;
using CustomVote.AddIn.PowerPoint2010.Helpers;

namespace CustomVote.AddIn.PowerPoint2010.Results.strategies
{
    interface IResultStrategy
    {
        void DrawSlide(ResultSlideConfiguration resultConfig, List<ItemList> lstQuestions);
        void UpdateSlide(ResultSlideConfiguration resultConfig);
        void CreateTitle(ResultSlideConfiguration resultConfig);
        void Ordering(ResultSlideConfiguration resultConfig);
        void ResizeCharts(ResultSlideConfiguration resultConfig);
    }
}
