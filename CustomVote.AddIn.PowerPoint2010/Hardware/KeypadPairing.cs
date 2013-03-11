using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CustomVote.AddIn.PowerPoint2010.Session;
using SunVoteARS;

namespace CustomVote.AddIn.PowerPoint2010.Hardware
{
    public partial class KeypadPairing : Form
    {
        private SunVoteARS.BaseManage _baseManage;
        private List<KeyPadList> _keyPadList = new List<KeyPadList>();
        public KeypadPairing()
        {
            InitializeComponent();
            _baseManage = new BaseManage();
            grdKeyPadsMath.DataSource = _keyPadList;
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            var conn = ConnectionManager.GetConection();
            _baseManage.BaseConnection = conn;
            _baseManage.MatchStatus += new IBaseManageEvents_MatchStatusEventHandler(baseManage_MatchStatus);
            _baseManage.StartMatch(ConnectionManager.BaseId);
        }

        void baseManage_MatchStatus(int KeyID, int HModel, int HVer, int SVer, string HSerial)
        {
            _keyPadList.Add(new KeyPadList() {Id = KeyID, Nombre = "mando " + KeyID});
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            _baseManage.MatchStatus -= baseManage_MatchStatus;

        }
    }
}
