using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CustomVote.AddIn.PowerPoint2010.Results.Data
{
    [Serializable]
    public class CrossComparizonConfig
    {
        [NonSerialized]
        private Microsoft.Office.Interop.PowerPoint.Shape _charShape;

        public Microsoft.Office.Interop.PowerPoint.Shape ChartShape
        {
            get { return _charShape; }
            set { _charShape = value; }
        }

        public int ChartShapeIndex { get; set; }
    }
}
