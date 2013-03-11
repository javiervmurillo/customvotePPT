using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SunVoteARS;

namespace CustomVote.AddIn.PowerPoint2010.Hardware
{
    public partial class HardwareTest : Form
    {
        public HardwareTest()
        {
            InitializeComponent();
            InitConfig();
            //InitSunVoteDll();
            Shown += new EventHandler(HardwareTest_Shown);
            
        }

        void HardwareTest_Shown(object sender, EventArgs e)
        {
            InitSunVoteDll();
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            if (this.baseConn != null)
                this.baseConn.Close();
            base.OnClosing(e);
        }

        private void InitConfig()
        {
            chkSimulacion.Checked = Globals.ThisAddIn.Session.HardwareConfiguration.SimulateMode;
            txtBaseID.Text = Globals.ThisAddIn.Session.HardwareConfiguration.BaseId.ToString();
        }
        private BaseConnection baseConn;
        private SignIn signIn;
        private SunVoteARS.Number number;
        private SunVoteARS.Choices choices;

        private void InitSunVoteDll()
        {
            try
            {
                this.baseConn = new BaseConnection();
                this.signIn = new SignIn();
                this.number = new Number();
                this.choices = new Choices();

                signIn.BaseConnection = baseConn;
                number.BaseConnection = baseConn;
                choices.BaseConnection = baseConn;

                this.baseConn.BaseOnLine += new IBaseConnectionEvents_BaseOnLineEventHandler(this.baseConn_BaseOnLine);

                this.signIn.KeyStatus += new ISignInEvents_KeyStatusEventHandler(this.signIn_KeyStatus);
                this.number.KeyStatus += new INumberEvents_KeyStatusEventHandler(this.number_KeyStatus);
                this.choices.KeyStatus += new IChoicesEvents_KeyStatusEventHandler(this.choices_KeyStatus);
            }
            catch (System.Runtime.InteropServices.COMException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        void choices_KeyStatus(string BaseTag, int KeyID, string KeyValue, double KeyTime)
        {
            object[] str = new object[7];
            DateTime now = DateTime.Now;
            str[0] = now.ToString("HH:mm:ss fff");
            str[1] = " BaseTag: KeyID:";
            str[2] = KeyID;
            // str[3] = "  ValueType:";
            //str[4] = ValueType;
            str[5] = "  KeyValue:";
            str[6] = KeyValue;
            this.lstMsg.Items.Insert(0, string.Concat(str));
        }

        void number_KeyStatus(string BaseTag, int KeyID, string KeyValue, double KeyTime)
        {
            object[] str = new object[7];
            DateTime now = DateTime.Now;
            str[0] = now.ToString("HH:mm:ss fff");
            str[1] = " BaseTag: KeyID:";
            str[2] = KeyID;
           // str[3] = "  ValueType:";
            //str[4] = ValueType;
            str[5] = "  KeyValue:";
            str[6] = KeyValue;
            this.lstMsg.Items.Insert(0, string.Concat(str));
        }
        private void signIn_KeyStatus(string BaseTag, int KeyID, int ValueType, string KeyValue)
        {
            object[] str = new object[7];
            DateTime now = DateTime.Now;
            str[0] = now.ToString("HH:mm:ss fff");
            str[1] = " BaseTag: KeyID:";
            str[2] = KeyID;
            str[3] = "  ValueType:";
            str[4] = ValueType;
            str[5] = "  KeyValue:";
            str[6] = KeyValue;
            this.lstMsg.Items.Insert(0, string.Concat(str));
        }

        private void baseConn_BaseOnLine(int BaseID, int BaseState)
        {
            signIn.BaseConnection = baseConn;
            number.BaseConnection = baseConn;
            choices.BaseConnection = baseConn;

            object[] str;
            DateTime now;
            int baseState = BaseState;
            switch (baseState)
            {
                case -4:
                    {
                        str = new object[4];
                        now = DateTime.Now;
                        str[0] = now.ToString("HH:mm:ss fff");
                        str[1] = "  BaseID:";
                        str[2] = BaseID;
                        str[3] = "  State:The Baseconnection has been closed!";
                        this.lstMsg.Items.Insert(0, string.Concat(str));
                        break;
                    }
                case -3:
                    {
                        str = new object[4];
                        now = DateTime.Now;
                        str[0] = now.ToString("HH:mm:ss fff");
                        str[1] = "  BaseID:";
                        str[2] = BaseID;
                        str[3] = "  State:Port Error!";
                        this.lstMsg.Items.Insert(0, string.Concat(str));
                        break;
                    }
                case -2:
                    {
                        str = new object[4];
                        now = DateTime.Now;
                        str[0] = now.ToString("HH:mm:ss fff");
                        str[1] = "  BaseID:";
                        str[2] = BaseID;
                        str[3] = "  State:Can not find Base!";

                        this.lstMsg.Items.Insert(0, string.Concat(str));
                        break;
                    }
                case -1:
                    {
                        str = new object[4];
                        now = DateTime.Now;
                        str[0] = now.ToString("HH:mm:ss fff");
                        str[1] = "  BaseID:";
                        str[2] = BaseID;
                        str[3] = "  State:Can Not Support The ConnectType!";
                        this.lstMsg.Items.Insert(0, string.Concat(str));
                        break;
                    }
                case 0:
                    {
                        str = new object[4];
                        now = DateTime.Now;
                        str[0] = now.ToString("HH:mm:ss fff");
                        str[1] = "  BaseID:";
                        str[2] = BaseID;
                        str[3] = "  State:Connect Base Failure or BaseConnection Close!";
                        this.lstMsg.Items.Insert(0, string.Concat(str));
                        break;
                    }
                case 1:
                    {
                        str = new object[4];
                        now = DateTime.Now;
                        str[0] = now.ToString("HH:mm:ss fff");
                        str[1] = "  BaseID:";
                        str[2] = BaseID;
                        str[3] = "  State:Connect Base Success!";
                        this.lstMsg.Items.Insert(0, string.Concat(str));
                        break;
                    }
            }
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            this.baseConn.Open(1, this.txtBaseID.Text);
            
        }

        private void btnDisconnect_Click(object sender, EventArgs e)
        {
            this.baseConn.Close();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            this.signIn.Mode = 0;
            this.signIn.StartMode = 1;
            var res = this.signIn.Start();
            DateTime now = DateTime.Now;
            this.lstMsg.Items.Insert(0, string.Concat(now.ToString("HH:mm:ss fff"), "  Sign-in start", "Status:", res));
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            this.signIn.Stop();
            DateTime now = DateTime.Now;
            this.lstMsg.Items.Insert(0, string.Concat(now.ToString("HH:mm:ss fff"), "  Sign-in stop"));
        }

        private void btnStartNum_Click(object sender, EventArgs e)
        {
            DateTime now = DateTime.Now;
            this.number.Mode = Convert.ToInt32(txtNumberMode.Text);
            this.number.ModifyMode = Convert.ToInt32(txtNumberModifyMode.Text);
            this.number.SecrecyMode = Convert.ToInt32(txtNumberSecrecyMode.Text);
            this.number.Default = Convert.ToInt32(txtNumberDefault.Text);
            this.number.Min = Convert.ToInt32(txtNumberMin.Text);
            this.number.Max = Convert.ToInt32(txtNumberMax.Text);
            this.number.StartMode = Convert.ToInt32(txtNumberStartMode.Text);
            var res = this.number.Start();
            this.lstMsg.Items.Insert(0, string.Concat(now.ToString("HH:mm:ss fff"), "  number start", "Status:", res));

        }

        private void btnStopNum_Click(object sender, EventArgs e)
        {
            this.number.Stop();
            DateTime now = DateTime.Now;
            this.lstMsg.Items.Insert(0, string.Concat(now.ToString("HH:mm:ss fff"), "  number stop"));
        }

        private void btnStartChoice_Click(object sender, EventArgs e)
        {
            DateTime now = DateTime.Now;

            this.choices.OptionsMode = Convert.ToInt32(txtChoicesOptionsMode.Text);
            this.choices.ModifyMode = Convert.ToInt32(txtChoicesModifyMode.Text);
            this.choices.SecrecyMode = Convert.ToInt32(txtChoicesSecrecyMode.Text);
            this.choices.LessEnabled = Convert.ToInt32(txtChoicesLessEnabled.Text);
            this.choices.Options = Convert.ToInt32(txtChoicesOptions.Text);
            this.choices.OptionalN = Convert.ToInt32(txtChoicesOptionalN.Text);
            this.choices.StartMode = Convert.ToInt32(txtChoiceStartMode.Text);

            string  res = this.choices.Start();
            this.lstMsg.Items.Insert(0, string.Concat(now.ToString("HH:mm:ss fff"), "  choices start", "Status:", res));

        }

        private void btnStopChoice_Click(object sender, EventArgs e)
        {
            this.choices.Stop();
            DateTime now = DateTime.Now;
            this.lstMsg.Items.Insert(0, string.Concat(now.ToString("HH:mm:ss fff"), "  choice stop"));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Globals.ThisAddIn.Session.HardwareConfiguration.SimulateMode = chkSimulacion.Checked;
            Globals.ThisAddIn.Session.HardwareConfiguration.BaseId = Convert.ToInt32(txtBaseID.Text);
        }

        
    }
}
