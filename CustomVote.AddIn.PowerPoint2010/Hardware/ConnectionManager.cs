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
    public class ConnectionManager
    {
        public static bool IsConected { get; set; }
        public static bool IsTryingConnect { get; set; }
        private static BaseConnection _BaseConnection;
        public static int BaseId { get; set; }

        public static BaseConnection GetConection()
        {
            if (_BaseConnection != null)
                return _BaseConnection;

            _BaseConnection = new BaseConnection();
            _BaseConnection.BaseOnLine+=new IBaseConnectionEvents_BaseOnLineEventHandler(_BaseConnection_BaseOnLine);
            IsTryingConnect = true;
            IsConected = false;
            _BaseConnection.Open(1, "1-8");

            return _BaseConnection;
        }

        static void _BaseConnection_BaseOnLine(int BaseID, int BaseState)
        {
            if (BaseState == 1)
            {
                IsTryingConnect = false;
                IsConected = true;
                BaseId = BaseID;
                Globals.ThisAddIn.Session.HardwareConfiguration.BaseId = BaseID;
                _BaseConnection.BaseOnLine -= _BaseConnection_BaseOnLine;
            }
            if (ConnectEvent != null)
                ConnectEvent(BaseID, BaseState);
        }

        public delegate void ConnectEventHandler(int BaseID, int BaseState);
        public static event ConnectEventHandler ConnectEvent;

        internal static void Disconect()
        {
            _BaseConnection.Close();
        }
    }
}
