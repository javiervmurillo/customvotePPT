using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LumenWorks.Framework.IO.Csv;
using System.IO;
using CustomVote.AddIn.PowerPoint2010.Session;
using SunVoteARS;

namespace CustomVote.AddIn.PowerPoint2010.Hardware
{
    public partial class Configuration : Form
    {

        public Configuration()
        {
            InitializeComponent();
            Load += new EventHandler(Configuration_Load);
        }

        void Configuration_Load(object sender, EventArgs e)
        {
            InitializeOpenFileDialog();
            InitSavedConfig();
        }

        private void InitSavedConfig()
        {
            var hardwareConf = Globals.ThisAddIn.Session.HardwareConfiguration;
            if (hardwareConf == null)
                return;

            if (hardwareConf.BaseId != 0)
                txtConfigBaseId.Text = hardwareConf.BaseId.ToString();
            chkSimulateMode.Checked = hardwareConf.SimulateMode;
            if (hardwareConf.KeyPads != null)
                gridKeyPads.DataSource = hardwareConf.KeyPads;
            chkOnlyThisKeypads.Checked = hardwareConf.TakeOnlyKeypadsConfigurated;
            FeaturedFromConfToView(hardwareConf.FeaturedConfig);
            chkPPtRemote.Checked = hardwareConf.ActivatePPTRemote;

        }

        private FeatureConfig GetFeatureConfigFromView()
        {
            FeatureConfig conf = new FeatureConfig();
            if (rbNorReport.Checked) conf.KeyReportMode = 0;
            if (rbReportOnStandby.Checked) conf.KeyReportMode = 1;
            if (rbReportOnVoting.Checked) conf.KeyReportMode = 2;
            if (rbReportOnStandbyOrVoting.Checked) conf.KeyReportMode = 3;

            if (chkDoNotOffKeypad.Checked) conf.KeyOffTime = -1;
            else conf.KeyOffTime = Convert.ToInt32(numTimeToOffKeyPad.Value);

            if (rbCommitOnOK.Checked) conf.CommitMode = 0;
            if (rbCommitAuto.Checked) conf.CommitMode = 1;

            return conf;

        }

        private void FeaturedFromConfToView(FeatureConfig FeaturedConfig)
        {
           
                if (FeaturedConfig != null)
                {
                    switch (FeaturedConfig.KeyReportMode)
                    {
                        case 0:
                            rbNorReport.Checked = true;
                            break;
                        case 1:
                            rbReportOnStandby.Checked = true;
                            break;
                        case 2:
                            rbReportOnVoting.Checked = true;
                            break;
                        case 3:
                            rbReportOnStandbyOrVoting.Checked = true;
                            break;
                        default:
                            break;
                    }
                    switch (FeaturedConfig.KeyOffTime)
                    {
                        case -1:
                            chkDoNotOffKeypad.Checked = true;
                            numTimeToOffKeyPad.Enabled = false;
                            break;
                        default:
                            chkDoNotOffKeypad.Checked = false;
                            numTimeToOffKeyPad.Enabled = true;
                            numTimeToOffKeyPad.Value = FeaturedConfig.KeyOffTime;
                            break;
                    }
                    switch (FeaturedConfig.CommitMode)
                    {
                        case 0:
                            rbCommitOnOK.Checked = true;
                            break;
                        case 1:
                            rbCommitAuto.Checked = true;
                            break;
                        default:
                            break;
                    }
                }
        }

        private void InitializeOpenFileDialog()
        {
            // Set the file dialog to filter for graphics files.
            this.openFileDialog1.Filter =
                "CSV (*.csv;*.txt)|*.csv;*.txt|" +
                "All files (*.*)|*.*";

            //  Allow the user to select multiple images.
            this.openFileDialog1.Multiselect = false;
            //                   ^  ^  ^  ^  ^  ^  ^

            this.openFileDialog1.Title = "Archivo CSV";
        }

        private void btnConfigMandosImportFromCSV_Click(object sender, EventArgs e)
        {
            DialogResult dr = this.openFileDialog1.ShowDialog();
            if (dr == System.Windows.Forms.DialogResult.OK)
            {
                try
                {
                    string file = openFileDialog1.FileName;
                    List<KeyPadList> lst = new List<KeyPadList>();
                    
                    using (CsvReader csv = new CsvReader(new StreamReader(file), true, txtCsvDelimiter.Text.ToCharArray().First()))
                    {
                        string[] headers = csv.GetFieldHeaders();
                        while (csv.ReadNextRecord())
                        {
                            KeyPadList field = new KeyPadList();
                            field.Id = Convert.ToInt32( csv[0]);
                            field.Nombre = csv[1];
                            lst.Add(field);
                        }
                    }
                    gridKeyPads.AutoGenerateColumns = true;
                    gridKeyPads.DataSource = lst;
                }
                catch (ArgumentOutOfRangeException outOfRange)
                {
                    MessageBox.Show("Archivo CSV con formato incorrecto", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }

        private void btnConfigSave_Click(object sender, EventArgs e)
        {
            Globals.ThisAddIn.Session.HardwareConfiguration.SimulateMode = chkSimulateMode.Checked;
            if (!string.IsNullOrEmpty(txtConfigBaseId.Text) && !string.IsNullOrWhiteSpace(txtConfigBaseId.Text))
                Globals.ThisAddIn.Session.HardwareConfiguration.BaseId = Convert.ToInt32(txtConfigBaseId.Text);
            if (gridKeyPads.DataSource as List<KeyPadList> != null)
                Globals.ThisAddIn.Session.HardwareConfiguration.KeyPads = gridKeyPads.DataSource as List<KeyPadList>;
            Globals.ThisAddIn.Session.HardwareConfiguration.TakeOnlyKeypadsConfigurated = chkOnlyThisKeypads.Checked;
            Globals.ThisAddIn.Session.HardwareConfiguration.FeaturedConfig = GetFeatureConfigFromView();
            if (!Globals.ThisAddIn.Session.HardwareConfiguration.SimulateMode)
                SetFeaturedConfig();
            Globals.ThisAddIn.Session.HardwareConfiguration.ActivatePPTRemote = chkPPtRemote.Checked;

            //this.Close();
        }

        private void EnableButtons(bool enable)
        {
            tabControl1.Enabled = enable;
            btnConfigCerrar.Enabled = enable;
            btnDescBase2.Enabled = enable;
            btnConfigSave.Enabled = enable;
        }

        private void TryBaseConnect(BaseConnection baseConn, int baseId)
        {
            baseConn.Open(1, baseId.ToString());
            //baseConn.Open(1, "1-8");
        }

        

        private void btnConfigCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDescBase2_Click(object sender, EventArgs e)
        {
            DescubrirBase();

            
        }

        private void DescubrirBase()
        {
            progressBar1.Value = 0;
            EnableButtons(false);

            if (ConnectionManager.IsConected /*|| ConnectionManager.IsTryingConnect*/)
            {
                txtConfigBaseId.Text = ConnectionManager.BaseId.ToString();
                progressBar1.Value = 8;
                EnableButtons(true);
                return;
            }

            ConnectionManager.ConnectEvent += new ConnectionManager.ConnectEventHandler(ConnectionManager_ConnectEvent);
            var conn = ConnectionManager.GetConection();
        }

        void ConnectionManager_ConnectEvent(int BaseID, int BaseState)
        {
            if (progressBar1.Value == 8)
                progressBar1.Value = 0;
            progressBar1.Value +=1;
            if (BaseState == 1)
            {
                lblConectStatus.Text = "Base Id = " + BaseID.ToString() ;
                
                
                txtConfigBaseId.Text = BaseID.ToString();

                progressBar1.Value = 8;
                EnableButtons(true);
                var result = MessageBox.Show("Se conectó satisfactoriamente al receptor " + BaseID.ToString(), "Receptor", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (result == System.Windows.Forms.DialogResult.OK)
                {
                    
                    
                }
            }
        }

        #region baseManage
        SunVoteARS.BaseManage _BaseManage;
        private void btnGetFeatureConfig_Click(object sender, EventArgs e)
        {
            GetFeatureConfig();
            
            
        }

        private void GetFeatureConfig()
        {
            if (string.IsNullOrEmpty(txtConfigBaseId.Text) || string.IsNullOrWhiteSpace(txtConfigBaseId.Text))
                return;
            if (!ConnectionManager.IsConected)
                return;

            _BaseManage = new BaseManage();
            _BaseManage.BaseConnection = ConnectionManager.GetConection();
            _BaseManage.BasicFeature += new IBaseManageEvents_BasicFeatureEventHandler(_BaseManage_BasicFeature);
            _BaseManage.GetBasicFeature(Convert.ToInt32(txtConfigBaseId.Text));
        }
        
        FeatureConfig current_featureConfg;
        void _BaseManage_BasicFeature(int BaseID, int KeyReportMode, int KeyOffTime, int BackLightMode, int BuzzerMode, int CommitMode)
        {
            current_featureConfg = new FeatureConfig();
            current_featureConfg.KeyReportMode = KeyReportMode;
            current_featureConfg.KeyOffTime = KeyOffTime;
            current_featureConfg.BackLightMode = BackLightMode;
            current_featureConfg.BuzzerMode = BuzzerMode;
            current_featureConfg.CommitMode = CommitMode;

            FeaturedFromConfToView(current_featureConfg);
        }
        

        private void btnSetFeaturedConfig_Click(object sender, EventArgs e)
        {
            SetFeaturedConfig();
        }

        private void SetFeaturedConfig()
        {
            if (string.IsNullOrEmpty(txtConfigBaseId.Text) || string.IsNullOrWhiteSpace(txtConfigBaseId.Text))
                return;

            if (!ConnectionManager.IsConected)
                return;


            _BaseManage = new BaseManage();
            _BaseManage.BaseConnection = ConnectionManager.GetConection();
            _BaseManage.BasicFeature += new IBaseManageEvents_BasicFeatureEventHandler(_BaseManage_SetBasicFeature);

            FeatureConfig fconf = GetFeatureConfigFromView();
            _BaseManage.SetBasicFeature(Convert.ToInt32(txtConfigBaseId.Text), fconf.KeyReportMode, fconf.KeyOffTime, fconf.BackLightMode, fconf.BuzzerMode, fconf.CommitMode);
            Globals.ThisAddIn.Session.HardwareConfiguration.FeaturedConfig = fconf;
        }
       

        void _BaseManage_SetBasicFeature(int BaseID, int KeyReportMode, int KeyOffTime, int BackLightMode, int BuzzerMode, int CommitMode)
        {
            _BaseManage.BasicFeature -=_BaseManage_SetBasicFeature;
            MessageBox.Show("La configuración se envió correctamente", "Configuración",MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }

        
        #endregion

        private void tabReceptor_Enter(object sender, EventArgs e)
        {
            if (!Globals.ThisAddIn.Session.HardwareConfiguration.SimulateMode)
            {
                if (!ConnectionManager.IsConected)
                {
                    ConnectionManager.ConnectEvent += new ConnectionManager.ConnectEventHandler(ConnectionManager_ConnectEventForConfig);
                    DescubrirBase();
                    return;
                }

                GetFeatureConfig();
            }
        }
        void ConnectionManager_ConnectEventForConfig(int BaseID, int BaseState)
        {
            if (BaseState == 1)
            {
                ConnectionManager.ConnectEvent -= ConnectionManager_ConnectEventForConfig;
                GetFeatureConfig();
            }
        }

        private void chkSimulateMode_CheckedChanged(object sender, EventArgs e)
        {
            Globals.ThisAddIn.Session.HardwareConfiguration.SimulateMode = chkSimulateMode.Checked;
        }

        private void btnDescubrirMandos_Click(object sender, EventArgs e)
        {
            if (!Globals.ThisAddIn.Session.HardwareConfiguration.SimulateMode)
            {
                if (!ConnectionManager.IsConected)
                {
                    ConnectionManager.ConnectEvent +=
                        new ConnectionManager.ConnectEventHandler(ConnectionManager_ConnectEventForPairing);
                    DescubrirBase();
                    return;
                }
                ShowPairingWindow();
            }
        }
        void ConnectionManager_ConnectEventForPairing(int BaseID, int BaseState)
        {
            if (BaseState == 1)
            {
                ConnectionManager.ConnectEvent -= ConnectionManager_ConnectEventForPairing;
                ShowPairingWindow();
            }
        }

        private void ShowPairingWindow()
        {
            var form = new KeypadPairing();
            form.ShowDialog();
        }

        private void chkOnlyThisKeypads_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
