using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration.Install;
using System.Linq;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Windows.Forms;


namespace CustomVote.Setup.CustomActions
{
    [RunInstaller(true)]
    public partial class CustomVoteInstaller : System.Configuration.Install.Installer
    {
        public CustomVoteInstaller()
        {
            InitializeComponent();
        }
        protected override void OnBeforeInstall(IDictionary savedState)
        {
            base.OnBeforeInstall(savedState);
        }

        public override void Commit(IDictionary savedState)
        {
            base.Commit(savedState);

            //System.Text.StringBuilder keys = new System.Text.StringBuilder() ;
            //foreach (var item in Context.Parameters.Keys)
            //{
            //    keys.Append(item.ToString()+"--");
            //}
            //MessageBox.Show("Keys:" +keys.ToString());

            //InstallLib(Context.Parameters["DP_targetPath"].ToString() + "lib/o2010pia.msi");
            //InstallLib(Context.Parameters["DP_targetPath"].ToString() + "lib/vstor30.exe");

            //if (!this.IsDllRegistered("SunVoteARS.dll"))
            //{
            Register_Dll(Context.Parameters["DP_targetPath"].ToString() + "lib/MSCOMM32.OCX");
            Register_Dll(Context.Parameters["DP_targetPath"].ToString() + "lib/SunVoteARS.dll");
            Register_Dll(Context.Parameters["DP_targetPath"].ToString() + "lib/SunVoteLPT.dll");

            //}
            System.EnterpriseServices.Internal.Publish pub = new System.EnterpriseServices.Internal.Publish();
            pub.GacInstall(Context.Parameters["DP_targetPath"].ToString() + "lib/Interop.SunVoteARS.dll");
            
        }

        public override void Install(IDictionary stateSaver)
        {
            base.Install(stateSaver);
            //InstallLib(stateSaver["Par_TARGETDIR"] + "lib/vstor30.exe");
        }
        public override void Uninstall(IDictionary savedState)
        {
            base.Uninstall(savedState);
            System.EnterpriseServices.Internal.Publish pub = new System.EnterpriseServices.Internal.Publish();
            pub.GacRemove(Context.Parameters["DP_targetPath"].ToString() + "lib/Interop.SunVoteARS.dll");
        }
        

        #region dll utils
        [DllImport("kernel32")]
        public extern static int LoadLibrary(string lpLibFileName);
        
        [DllImport("kernel32")]
        public extern static bool FreeLibrary(int hLibModule);



        private bool IsDllRegistered(string DllName)
        {
            int libId = LoadLibrary(DllName);
            if (libId > 0) FreeLibrary(libId);
            return (libId > 0);
        }

        public  void Register_Dll(string filePath)
        {
            try
            {
                //'/s' : Specifies regsvr32 to run silently and to not display any message boxes.
                string arg_fileinfo = "/s" + " " + "\"" + filePath + "\"";
                Process reg = new Process();
                //This file registers .dll files as command components in the registry.
                reg.StartInfo.FileName = "regsvr32.exe";
                reg.StartInfo.Arguments = arg_fileinfo;
                reg.StartInfo.UseShellExecute = false;
                reg.StartInfo.CreateNoWindow = true;
                reg.StartInfo.RedirectStandardOutput = true;
                reg.Start();
                reg.WaitForExit();
                reg.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("regDll:" + ex.Message + ": " + filePath);
            }
        }
        private void InstallLib(string filePath)
        {
            try
            {
                //'/s' : Specifies regsvr32 to run silently and to not display any message boxes.
                //string arg_fileinfo = "/s" + " " + "\"" + filePath + "\"";
                Process reg = new Process();
                //This file registers .dll files as command components in the registry.
                reg.StartInfo.FileName = filePath;
                //reg.StartInfo.Arguments = filePath;
                reg.StartInfo.UseShellExecute = false;
                reg.StartInfo.CreateNoWindow = true;
                reg.StartInfo.RedirectStandardOutput = true;
                reg.Start();
                reg.WaitForExit();
                reg.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("installLib"+ex.Message+": "+filePath);
            }
        }
        #endregion
    }


}
