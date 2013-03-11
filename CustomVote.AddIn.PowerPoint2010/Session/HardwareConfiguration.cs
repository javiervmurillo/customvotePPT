using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CustomVote.AddIn.PowerPoint2010.Session
{
    [Serializable]
    public class HardwareConfiguration
    {
        private int _baseId;

        public int BaseId
        {
            get { return _baseId; }
            set { _baseId = value; }
        }
        private bool _simulateMode;

        public bool SimulateMode
        {
            get { return _simulateMode; }
            set { _simulateMode = value; }
        }

        public bool ActivatePPTRemote { get; set; }

        public List<KeyPadList> KeyPads { get; set; }
        public bool TakeOnlyKeypadsConfigurated { get; set; }

        internal string GetFrienlyNameForKeyPad(int keyPadId)
        {
            if (KeyPads == null) return keyPadId.ToString();
            var keypad = KeyPads.Where(x => x.Id == keyPadId).FirstOrDefault();
            if (keypad == null) return keyPadId.ToString();

            return keypad.Nombre;
        }
        public FeatureConfig FeaturedConfig { get; set; }

        internal bool ExistKeypadConfigurated(int keyId)
        {
            foreach (var k in KeyPads)
            {
                if (k.Id == keyId)
                    return true;
            }
            return false;
        }
    }

    [Serializable]
    public class KeyPadList
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
    }
    [Serializable]
    public class FeatureConfig
    {
        /// <summary>
        /// =0, no report
        /// =1, report while standby,
        /// =2, report while voting,
        /// =3 report while standby or voting
        /// </summary>
        public int KeyReportMode { get; set; }
        /// <summary>
        /// range from 1 to 254 (Unite: minutes)
        /// 0 = hardware Default
        /// -1 = Do not shut down
        /// </summary>
        public int KeyOffTime { get; set; }
        /// <summary>
        /// 0 = when press OK button
        /// 1 = automatic commit
        /// </summary>
        public int CommitMode { get; set; }

        public int BackLightMode { get; set; }
        public int BuzzerMode { get; set; }
    }
}
