using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CustomVote.AddIn.PowerPoint2010.Results.Data;
using CustomVote.AddIn.PowerPoint2010.Interfaces;

namespace CustomVote.AddIn.PowerPoint2010.Results
{
    public partial class RankingConfigView : UserControl, IResultView
    {
        public RankingConfigView()
        {
            InitializeComponent();
        }
        private RankingConfig _config;
        public void Init(RankingConfig config)
        {
            _config = config;
            rnkTopResults.Value = config.TopRanking;
            chkShowTime.Checked = _config.ShowTime;
            if (_config.ShowPointsAcum)
                rdbCantPuntos.Checked = _config.ShowPointsAcum;
            else
                rdbPregAcertadas.Checked = true;
        }

        public void Save()
        {
            _config.TopRanking = Convert.ToInt32(rnkTopResults.Value);
            _config.ShowTime = chkShowTime.Checked;
            _config.ShowPointsAcum = rdbCantPuntos.Checked;

            this.rnkTopResults.Enabled = false;
        }
    }
}
