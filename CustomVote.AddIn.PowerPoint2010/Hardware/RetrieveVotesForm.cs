using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SunVoteARS;
using CustomVote.AddIn.PowerPoint2010.Questions.Data;
using CustomVote.AddIn.PowerPoint2010.Helpers;
using Microsoft.Office.Interop.PowerPoint;
using System.Runtime.InteropServices;

[Flags()]
public enum MouseEventFlags
{
    LEFTDOWN = 0x00000002,
    LEFTUP = 0x00000004,
    MIDDLEDOWN = 0x00000020,
    MIDDLEUP = 0x00000040,
    MOVE = 0x00000001,
    ABSOLUTE = 0x00008000,
    RIGHTDOWN = 0x00000008,
    RIGHTUP = 0x00000010
}
public enum VirtualKeyCodes
{
    VK_ESCAPE = 0x1B, //ESC key
}        

namespace CustomVote.AddIn.PowerPoint2010.Hardware
{
    public partial class RetrieveVotesForm : Form
    {
        [DllImport("user32.dll")]
        static extern void mouse_event(int dwFlags, int dx, int dy, int dwData, int dwExtraInfo);
        [DllImport("user32.dll", EntryPoint = "keybd_event", CharSet = CharSet.Auto, ExactSpelling = true)]
        public static extern void Keybd_event(byte vk, byte scan, int flags, int extrainfo);
        
        
        
        //private BaseConnection baseConn;
        private SunVoteARS.Choices choices;
        private KeyStatusValues _keyStatusValues;
        public QuestionSlideConfiguration QuestionAssociated{get;set;}
        private Shape _currentAnimatedTimer = null;
        private int _frameAnimation = 0;
        private int _countTick = 0;

        public RetrieveVotesForm(QuestionSlideConfiguration question)
        {
            InitializeComponent();
            ClearVotes();
            InitCronometer();
            
            _keyStatusValues = new KeyStatusValues();
            QuestionAssociated = question;
            Load += new EventHandler(RetrieveVotesForm_Load);
        }

        void RetrieveVotesForm_Load(object sender, EventArgs e)
        {
            KeyDown += new KeyEventHandler(RetrieveVotesForm_KeyDown);
            FormClosed += new FormClosedEventHandler(RetrieveVotesForm_FormClosed);
        }

        void RetrieveVotesForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            //Globals.ThisAddIn.Application.ActivePresentation.SlideShowWindow.Activate();
            //Globals.ThisAddIn.Application.ActivePresentation.SlideShowWindow.View.GotoSlide(Globals.ThisAddIn.Application.ActivePresentation.SlideShowWindow.View.Slide.SlideIndex);
            
            Globals.ThisAddIn.Application.ActivePresentation.SlideShowWindow.Activate();
            Globals.ThisAddIn.Application.SlideShowWindows[1].Activate();
            //Globals.ThisAddIn.Application.SlideShowWindows[1].View.Slide.Select();
            Globals.ThisAddIn.Application.SlideShowWindows[1].View.State = Microsoft.Office.Interop.PowerPoint.PpSlideShowState.ppSlideShowRunning;
            Globals.ThisAddIn.Application.Activate();
            //Globals.ThisAddIn.Session.CurrentRetrieveVotesForm = null;
        }

        void RetrieveVotesForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.X)
            {
                TerminateVotation();
                
            }
        }

        public void TerminateVotation()
        {
            Globals.ThisAddIn.Session.CurrentRetrieveVotesForm = null;
            StopVotation();
            SaveVotes();
        }

        

        private void ClearVotes()
        {
            var slideId = Globals.ThisAddIn.Application.SlideShowWindows[1].View.Slide.SlideID;

            //_keyStatusValues.Clear();
            Globals.ThisAddIn.Session.ClearVotes(slideId);
        }

        private void InitSunVoteComponents()
        {
            if (Globals.ThisAddIn.Session.HardwareConfiguration.SimulateMode)
                return;
           
            this.choices = new Choices();

            this.choices.KeyStatus += new IChoicesEvents_KeyStatusEventHandler(choices_KeyStatus);

            InitChoices();
        }
        void InitChoices()
        {
            try
            {
                //Helpers.SunVoteHelper.CheckBaseStatus(BaseState);
                choices.BaseConnection = ConnectionManager.GetConection();
                this.choices.OptionsMode = 1;
                this.choices.ModifyMode = 0;
                this.choices.SecrecyMode = 0;
                this.choices.LessEnabled = 0;
                //this.choices.Options = 10;
                this.choices.Options = this.QuestionAssociated.Answers.Count;
                this.choices.OptionalN = 1;
                this.choices.StartMode = 1;
                this.choices.Start();

            }
            catch (Exception ex)
            {
                timer.Enabled = false;
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        void choices_KeyStatus(string baseTag, int keyID, string keyValue, double keyTime)
        {
            _keyStatusValues.Addvalue(keyID, new KeyStatusValue()
                    {
                        Basetag = baseTag,
                        Keytime = keyTime,
                        KeyValue = keyValue
                    });            
        }

        private void InitCronometer()
        {
            Hora = 0;
            Minuto = 0;
            Segundo = 0;
            MiliSegundo = 0;

            timer = new Timer();
            timer.Interval = 100;
            timer.Tick += new EventHandler(timer_Tick);

            this.Shown += new EventHandler(RetrieveVotesForm_Shown);
        }

        void RetrieveVotesForm_Shown(object sender, EventArgs e)
        {
            if (!Globals.ThisAddIn.Session.HardwareConfiguration.SimulateMode)
            {
                //baseConn.Open(1, Globals.ThisAddIn.Session.HardwareConfiguration.BaseId.ToString());
                var connectingDialog = new Connecting();
                var result = connectingDialog.ShowDialog();
                if (result != System.Windows.Forms.DialogResult.OK)
                    return;
                InitSunVoteComponents();
                //Cursor.Hide();
            }
            var slideId = Globals.ThisAddIn.Application.SlideShowWindows[1].View.Slide.SlideID;

            var qConf = Globals.ThisAddIn.Session.GetQuestionSlideConfiguration(slideId);

            _currentAnimatedTimer = null;
            _frameAnimation = 0;
            qConf.ChangeUnCheckButonToCheck();

            EnabledTimer();
        }

        private void EnabledTimer()
        {
            //System.Threading.Thread.Sleep(1000);// espera mientras se prenden los mandos
            _countTick = 0;
            timer.Enabled = true;
        }

        void timer_Tick(object sender, EventArgs e)
        {
            _countTick++;
            //Cursor.Hide();
            MiliSegundo += 1;
            if( MiliSegundo == 9)
            {
                MiliSegundo = 0;
                Segundo += 1;
                if(Segundo == 59)
                {
                    Segundo = 0;
                    Minuto += 1;
                    if(Minuto == 59)
                    {
                        Minuto = 0;
                        Hora += 1;
                    }
                }
            }
            ShowTime();

        }

        public int Hora { get; set; }
        public int Minuto { get; set; }
        public int Segundo { get; set; }
        public int MiliSegundo { get; set; }

        Timer timer;

        public void ShowTime()
        {
            lblCronometer.Text =
                //Hora.ToString().PadLeft(2, '0') + ":" +
                Minuto.ToString().PadLeft(2, '0') + ":" +
                Segundo.ToString().PadLeft(2, '0') +":" +
                MiliSegundo.ToString().PadLeft(1, '0');

            var slideId = Globals.ThisAddIn.Application.SlideShowWindows[1].View.Slide.SlideID;

            var qConf = Globals.ThisAddIn.Session.GetQuestionSlideConfiguration(slideId);

            if (qConf.ShowCronometerAnimation && (_countTick % 10 == 0))
            {
                if (_currentAnimatedTimer != null)
                {
                    _currentAnimatedTimer.Delete();
                    _currentAnimatedTimer = null;
                }

                if (_frameAnimation == 30)
                    _frameAnimation = 0;
                else
                    _frameAnimation++;
                _currentAnimatedTimer = qConf.AnimatingTimer(_frameAnimation);
                Globals.ThisAddIn.Application.SlideShowWindows[1].View.State = PpSlideShowState.ppSlideShowRunning;
            }

            qConf.ShowTimeOnShape(lblCronometer.Text , _keyStatusValues.GetValues().Count());
            
        }

        private void btbVotesStop_Click(object sender, EventArgs e)
        {
            StopVotation();
            
        }

        public void StopVotation()
        {
            SunVoteHelper.KeypadsPowerOff();

            if (choices != null)
                choices.Stop();
            timer.Enabled = false;
            btnVotesPreview.Enabled = true;
            btnVotesSave.Enabled = true;
            if (Globals.ThisAddIn.Session.HardwareConfiguration.SimulateMode)
            {
                GenerateSimulatedVotes();
                return;
            }

            var slideId = Globals.ThisAddIn.Application.SlideShowWindows[1].View.Slide.SlideID;
            var qConf = Globals.ThisAddIn.Session.GetQuestionSlideConfiguration(slideId);

            //if(qConf.ShowCronometerAnimation)
            //    if(_currentAnimatedTimer!= null)
            //    {
            //        _currentAnimatedTimer.Delete();
            //        _currentAnimatedTimer = null;
            //    }
            
                
                
            //baseConn.Close();
        }

        private void GenerateSimulatedVotes()
        {
            _keyStatusValues.Clear();
            _keyStatusValues.Addvalue(1, new KeyStatusValue() { KeyValue = "A", Keytime = 15 });
            _keyStatusValues.Addvalue(2, new KeyStatusValue() { KeyValue = "A", Keytime = 5 });
            _keyStatusValues.Addvalue(3, new KeyStatusValue() { KeyValue = "A", Keytime = 5 });
            _keyStatusValues.Addvalue(4, new KeyStatusValue() { KeyValue = "A", Keytime = 5 });
            _keyStatusValues.Addvalue(5, new KeyStatusValue() { KeyValue = "B", Keytime = 25 });
            _keyStatusValues.Addvalue(6, new KeyStatusValue() { KeyValue = "B", Keytime = 5 });
            _keyStatusValues.Addvalue(7, new KeyStatusValue() { KeyValue = "B", Keytime = 5 });
            _keyStatusValues.Addvalue(8, new KeyStatusValue() { KeyValue = "B", Keytime = 100 });
        }

        private void btnVotesPreview_Click(object sender, EventArgs e)
        {
            var preview = new PreviewVotes(_keyStatusValues.ToListString());
            preview.ShowDialog();
        }

        private void btnVotesSave_Click(object sender, EventArgs e)
        {
            SaveVotes();
            
        }

        public void SaveVotes()
        {
            var slideId = Globals.ThisAddIn.Application.SlideShowWindows[1].View.Slide.SlideID;

            var qConf = Globals.ThisAddIn.Session.GetQuestionSlideConfiguration(slideId);

            qConf.ChangeCheckButonToUncheck();

            Globals.ThisAddIn.Session.SaveVotes(_keyStatusValues, slideId);

            RightClick(10000, 10000);
            PressKey(VirtualKeyCodes.VK_ESCAPE);

            this.Close();
        }

        public static void RightClick(int x, int y)
        {
            Cursor.Position = new System.Drawing.Point(x, y);
            mouse_event((int)(MouseEventFlags.RIGHTDOWN), 0, 0, 0, 0);
            mouse_event((int)(MouseEventFlags.RIGHTUP), 0, 0, 0, 0);
        }

        public static void LeftClick(int x, int y)
        {
            Cursor.Position = new System.Drawing.Point(x, y);
            mouse_event((int)(MouseEventFlags.LEFTDOWN), 0, 0, 0, 0);
            mouse_event((int)(MouseEventFlags.LEFTUP), 0, 0, 0, 0);
        }
        public static void MidleClick(int x, int y)
        {
            Cursor.Position = new System.Drawing.Point(x, y);
            mouse_event((int)(MouseEventFlags.MIDDLEDOWN), 0, 0, 0, 0);
            mouse_event((int)(MouseEventFlags.MIDDLEUP), 0, 0, 0, 0);
        }
        public static void PressKey(VirtualKeyCodes keyCode)
        {
            const int KEYEVENTF_EXTENDEDKEY = 0x1;
            const int KEYEVENTF_KEYUP = 0x2;
            const int KEYEVENTF_KEYDOWN = 0x0;

            byte KeyCode = (byte)keyCode;

            Keybd_event(KeyCode, 0x45, KEYEVENTF_KEYDOWN | KEYEVENTF_EXTENDEDKEY, 0);
            Keybd_event(KeyCode, 0x45, KEYEVENTF_EXTENDEDKEY | KEYEVENTF_KEYUP, 0);

        }
    }
}
