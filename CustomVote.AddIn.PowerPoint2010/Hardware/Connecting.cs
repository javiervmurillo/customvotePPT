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
    public partial class Connecting : Form
    {
        public Connecting()
        {
            InitializeComponent();
            this.Shown += new EventHandler(Connecting_Shown);
        }

        void Connecting_Shown(object sender, EventArgs e)
        {
            if (ConnectionManager.IsConected)
            {
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }

            ConnectionManager.ConnectEvent += new ConnectionManager.ConnectEventHandler(ConnectionManager_ConnectEvent);
            var conn = ConnectionManager.GetConection();
        }

        

        void ConnectionManager_ConnectEvent(int BaseID, int BaseState)
        {
            if (BaseState == 1)
            {
                //MessageBox.Show(BaseID.ToString());
                ConnectionManager.ConnectEvent -= ConnectionManager_ConnectEvent;
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
        }
    }
}
