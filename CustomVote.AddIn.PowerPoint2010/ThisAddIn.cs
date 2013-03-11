using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using SunVoteARS;
using PowerPoint = Microsoft.Office.Interop.PowerPoint;
using Office = Microsoft.Office.Core;
using CustomVote.AddIn.PowerPoint2010.Session;
using CustomVote.AddIn.PowerPoint2010.Helpers;
using CustomVote.AddIn.PowerPoint2010.Hardware;
using System.Windows.Forms;

namespace CustomVote.AddIn.PowerPoint2010
{
    public partial class ThisAddIn
    {
        Timer timer;
        public SessionManager Session { get; private set; }
        private void ThisAddIn_Startup(object sender, System.EventArgs e)
        {
            Session = new SessionManager();
            Globals.ThisAddIn.Application.PresentationSave += new PowerPoint.EApplication_PresentationSaveEventHandler(Application_PresentationSave);
            Globals.ThisAddIn.Application.AfterPresentationOpen += new Microsoft.Office.Interop.PowerPoint.EApplication_AfterPresentationOpenEventHandler(Application_AfterPresentationOpen);
            Globals.ThisAddIn.Application.SlideShowEnd += new PowerPoint.EApplication_SlideShowEndEventHandler(Application_SlideShowEnd);
            Globals.ThisAddIn.Application.PresentationCloseFinal += new PowerPoint.EApplication_PresentationCloseFinalEventHandler(Application_PresentationCloseFinal);
            Globals.ThisAddIn.Application.SlideShowBegin += new PowerPoint.EApplication_SlideShowBeginEventHandler(Application_SlideShowBegin);
            Globals.ThisAddIn.Application.WindowActivate += new PowerPoint.EApplication_WindowActivateEventHandler(Application_WindowActivate);
            Globals.ThisAddIn.Application.WindowDeactivate += new PowerPoint.EApplication_WindowDeactivateEventHandler(Application_WindowDeactivate);
        }

        void Application_WindowDeactivate(PowerPoint.Presentation Pres, PowerPoint.DocumentWindow Wn)
        {
            //MessageBox.Show("deactivate " + Pres.FullName);
            //Helpers.Serializer.Serialize(this.Session, Pres.FullName + ".dat");
        }

        void Application_WindowActivate(PowerPoint.Presentation Pres, PowerPoint.DocumentWindow Wn)
        {
            //MessageBox.Show("activate " + Pres.FullName);
            //Session = Helpers.Serializer.Deserealize<SessionManager>(Pres.FullName + ".dat");
            //Session.ReBuildReferences();
        }

        void Application_SlideShowBegin(PowerPoint.SlideShowWindow Wn)
        {
            timer = new Timer();
            timer.Tick += new EventHandler(timer_Tick);
            timer.Enabled = true;
           // Cursor.Hide();
            InitPPTRemote();
        }

        private SunVoteARS.Request request;
        private void InitPPTRemote()
        {
            if (!Globals.ThisAddIn.Session.HardwareConfiguration.SimulateMode)
            {
                if (Globals.ThisAddIn.Session.HardwareConfiguration.ActivatePPTRemote)
                {
                    //baseConn.Open(1, Globals.ThisAddIn.Session.HardwareConfiguration.BaseId.ToString());
                    var connectingDialog = new Connecting();
                    var result = connectingDialog.ShowDialog();
                    if (result != System.Windows.Forms.DialogResult.OK)
                        return;

                    request = new Request();
                    request.BaseConnection = ConnectionManager.GetConection();
                    request.Enabled = true;
                    request.ChairControl += new IRequestEvents_ChairControlEventHandler(request_ChairControl);
                }
            }
        }

        

        void request_ChairControl(string BaseTag, int KeyID, int ReqType, string ReqInfo)
        {
            switch (ReqInfo)
            {
                case "2":
                    //back
                    var index = Globals.ThisAddIn.Application.SlideShowWindows[1].View.Slide.SlideIndex;
                    if(index > 1)
                        Globals.ThisAddIn.Application.SlideShowWindows[1].View.GotoSlide(index-1);
                    break;
                case "8":
                    Globals.ThisAddIn.Application.SlideShowWindows[1].View.Next();
                    break;
                case "10":
                    var slideIdInit = Globals.ThisAddIn.Application.SlideShowWindows[1].View.Slide.SlideID;
                    if (Globals.ThisAddIn.Session.IsQuestionSlide(slideIdInit))
                        customVoteLib.RetrieveVotes();
                    break;
                case "12":
                    var slideIdStop = Globals.ThisAddIn.Application.SlideShowWindows[1].View.Slide.SlideID;
                    if (Globals.ThisAddIn.Session.IsQuestionSlide(slideIdStop))
                        if (Globals.ThisAddIn.Session.CurrentRetrieveVotesForm != null)
                            Globals.ThisAddIn.Session.CurrentRetrieveVotesForm.TerminateVotation();
                    break;
                default:
                    break;
            }
        }

        void timer_Tick(object sender, EventArgs e)
        {
            //Cursor.Hide();
        }

        void Application_PresentationCloseFinal(PowerPoint.Presentation Pres)
        {
            Helpers.SunVoteHelper.KeypadsPowerOff();
            if (ConnectionManager.IsConected)
            {
                ConnectionManager.Disconect();
            }
        }

        void Application_SlideShowEnd(PowerPoint.Presentation Pres)
        {
            SunVoteHelper.KeypadsPowerOff();
            if (this.Session.CurrentRetrieveVotesForm != null)
            {
                if (!this.Session.HardwareConfiguration.SimulateMode)
                {
                    this.Session.CurrentRetrieveVotesForm.StopVotation();
                    this.Session.CurrentRetrieveVotesForm.SaveVotes();
                    this.Session.CurrentRetrieveVotesForm = null;
                    SunVoteHelper.KeypadsPowerOff();
                }
                else
                {
                    this.Session.CurrentRetrieveVotesForm.Close();
                }
            }
            this.timer.Enabled = false;
            this.timer.Dispose();
            this.Session.ExportData();
        }

        void Application_PresentationSave(PowerPoint.Presentation Pres)
        {
            Helpers.Serializer.Serialize(this.Session, Pres.FullName + ".dat");
        }

        void Application_AfterPresentationOpen(Microsoft.Office.Interop.PowerPoint.Presentation Pres)
        {
            Session = Helpers.Serializer.Deserealize<SessionManager>(Pres.FullName + ".dat");
            Session.ReBuildReferences();
        }

        private void ThisAddIn_Shutdown(object sender, System.EventArgs e)
        {
        }

        #region VSTO generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InternalStartup()
        {
            this.Startup += new System.EventHandler(ThisAddIn_Startup);
            this.Shutdown += new System.EventHandler(ThisAddIn_Shutdown);
        }
        
        #endregion

        internal void ClearSession()
        {
            Session = new SessionManager();
        }

        private CustomVoteLib customVoteLib;
        protected override object RequestComAddInAutomationService()
        {
            if (customVoteLib == null)
                customVoteLib = new CustomVoteLib();
            return customVoteLib;
            //return base.RequestComAddInAutomationService();
        }
    }
}
