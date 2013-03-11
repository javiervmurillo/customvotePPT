using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using CustomVote.AddIn.PowerPoint2010.Hardware;


namespace CustomVote.AddIn.PowerPoint2010.Helpers
{
    [ComVisible(true)]
    public interface IAddInUtilities
    {
        void RetrieveVotes();
    }

    [ComVisible(true)]
    [ClassInterface(ClassInterfaceType.None)]
    public class CustomVoteLib : IAddInUtilities
    {
        public void RetrieveVotes()
        {
            if (Globals.ThisAddIn.Session.CurrentRetrieveVotesForm == null)
                RetrieveNewVotes();
            else
            {
                //string msg = "La preguta: \"" + Globals.ThisAddIn.Session.CurrentRetrieveVotesForm.QuestionAssociated.QuetionTitle + " \" está en votación\r\n\r\n¿Desea cerrarla?";
                //var result = MessageBox.Show(msg, "Votación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                //if (result == DialogResult.Yes)
                //{
                    Globals.ThisAddIn.Session.CurrentRetrieveVotesForm.StopVotation();
                    Globals.ThisAddIn.Session.CurrentRetrieveVotesForm.SaveVotes();
                    Globals.ThisAddIn.Session.CurrentRetrieveVotesForm = null;
                //}
            }
            
        }

        private void RetrieveNewVotes()
        {
            var slideId = Globals.ThisAddIn.Application.SlideShowWindows[1].View.Slide.SlideID;

            var q = Globals.ThisAddIn.Session.GetQuestionSlideConfiguration(slideId);

            //if (q.HasVotes)
            //{
            //    var res = MessageBox.Show("La pregunta esta cerrada, ¿desea volver a votar?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            //    if (res == DialogResult.No)
            //        return;
            //}

            var form = new RetrieveVotesForm(q);

            Globals.ThisAddIn.Session.CurrentRetrieveVotesForm = form;
            form.ShowDialog();
        }
    }
}
