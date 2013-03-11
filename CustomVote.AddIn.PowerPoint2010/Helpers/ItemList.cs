using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CustomVote.AddIn.PowerPoint2010.Helpers
{
    [Serializable]
    public class ItemList
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public override string ToString()
        {
            return Name;
        }
    }
}
