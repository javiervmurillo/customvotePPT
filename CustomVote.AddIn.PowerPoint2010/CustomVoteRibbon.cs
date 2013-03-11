using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Office.Tools.Ribbon;
using CustomVote.AddIn.PowerPoint2010.Results;
using CustomVote.AddIn.PowerPoint2010.Hardware;

namespace CustomVote.AddIn.PowerPoint2010
{
    public partial class CustomVoteRibbon
    {
        private void CustomVoteRibbon_Load(object sender, RibbonUIEventArgs e)
        {

        }

        private void btnAddQuestion_Click(object sender, RibbonControlEventArgs e)
        {
            Questions.CreateQuestionView f = new Questions.CreateQuestionView();
            f.ShowDialog();
        }

        private void btnBlanckSlide_Click(object sender, RibbonControlEventArgs e)
        {
            Helpers.PowerPointHelper.AddNewSlide();
        }

        private void btnCtrlConfig_Click(object sender, RibbonControlEventArgs e)
        {
            //Hardware.HardwareTest form = new Hardware.HardwareTest();
            Hardware.Configuration form = new Hardware.Configuration();
            form.ShowDialog();
        }

        private void btnAddResult_Click(object sender, RibbonControlEventArgs e)
        {
            var result = new CreateResultView();
            result.ShowDialog();
        }

        private void btnClearVotes_Click(object sender, RibbonControlEventArgs e)
        {
            Globals.ThisAddIn.Session.ClearAllVotes();
            Globals.ThisAddIn.Session.UpdateResultsCharts();
        }

        private void btnKeyPadsPowerOff_Click(object sender, RibbonControlEventArgs e)
        {
            Helpers.SunVoteHelper.KeypadsPowerOff();
        }
    }
}
