using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CustomVote.AddIn.PowerPoint2010.Hardware;

namespace CustomVote.AddIn.PowerPoint2010.Helpers
{
    public class SunVoteHelper
    {
        public static bool CheckBaseStatus(int baseState)
        {
            switch (baseState)
            {
                case -4:
                    {
                        throw new Exception("The Baseconnection has been closed!");
                    }
                case -3:
                    {
                        throw new Exception("Port Error!");
                    }
                case -2:
                    {
                        throw new Exception("Can not find Base!");
                    }
                case -1:
                    {
                        throw new Exception("Can Not Support The ConnectType!");
                    }
                case 0:
                    {
                        return true;
                        //throw new Exception("Connect Base Failure or BaseConnection Close!");
                    }
                case 1:
                    {
                        //"  State:Connect Base Success!";
                        return true;
                    }
                default:
                    return false;
            }
        }

        internal static void KeypadsPowerOff()
        {
            if (!ConnectionManager.IsConected)
                return;
            if (ConnectionManager.IsTryingConnect)
                return;

            SunVoteARS.KeypadManage keypadM = new SunVoteARS.KeypadManage();
            keypadM.BaseConnection = ConnectionManager.GetConection();
            keypadM.RemoteOff(0);
        }
    }
}
