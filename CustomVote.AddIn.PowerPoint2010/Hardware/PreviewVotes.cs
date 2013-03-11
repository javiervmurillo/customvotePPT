using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CustomVote.AddIn.PowerPoint2010.Hardware
{
    public partial class PreviewVotes : Form
    {
        public PreviewVotes(List<string> votes)
        {
            InitializeComponent();

            foreach (var item in votes)
            {
                lstVotesPreview.Items.Add(item);
            }
        }
    }
}
