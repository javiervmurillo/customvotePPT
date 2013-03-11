using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CustomVote.AddIn.PowerPoint2010.Interfaces;
using CustomVote.AddIn.PowerPoint2010.Results.Data;

namespace CustomVote.AddIn.PowerPoint2010.Results
{
    public partial class NormalConfigView : UserControl, IResultView
    {
        public NormalConfigView()
        {
            InitializeComponent();
        }

        private NormalConfig _config;
        public void Init(NormalConfig config)
        {
            _config = config;
            chkKeepTogetherResult.Checked = _config.KeepTogetherResult;
            chkCopyQuetionShapesFormat.Checked = _config.CopyQuestionShpapesFormat;
        }
        public void Save()
        {
            _config.CopyQuestionShpapesFormat = chkCopyQuetionShapesFormat.Checked;
            _config.KeepTogetherResult = chkKeepTogetherResult.Checked;
        }
    }
}
