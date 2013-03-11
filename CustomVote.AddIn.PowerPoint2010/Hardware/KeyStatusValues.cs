using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CustomVote.AddIn.PowerPoint2010.Hardware
{
    public class KeyStatusValues
    {
        /// <summary>
        /// Dictionary key == KeyID
        /// </summary>
        private Dictionary<int, KeyStatusValue> Values;
        public KeyStatusValues()
        {
            Values = new Dictionary<int, KeyStatusValue>();
        }

        public Dictionary<int, KeyStatusValue> GetValues()
        {
            return Values;
        }

        public void Addvalue(int keyId, KeyStatusValue value)
        {
            if (Globals.ThisAddIn.Session.HardwareConfiguration.TakeOnlyKeypadsConfigurated)
            {
                if (Globals.ThisAddIn.Session.HardwareConfiguration.ExistKeypadConfigurated(keyId))
                {
                    AddOrUpdateKayValue(keyId, value);
                }
            }
            else
            {
                AddOrUpdateKayValue(keyId, value);
            }
        }

        private void AddOrUpdateKayValue(int keyId, KeyStatusValue value)
        {
            if (Values.ContainsKey(keyId))
                Values[keyId] = value;
            else
                Values.Add(keyId, value);
        }

        public void Remove(int keyId)
        {
            Values.Remove(keyId);
        }

        public void Clear()
        {
            Values.Clear();
        }

        public List<string> ToListString()
        {
            List<string> lst = new List<string>();
            foreach (var item in Values)
            {
                string line = string.Format("Key Id:{0}, Value:{1}, Time:{2} s.", item.Key, item.Value.KeyValue, item.Value.Keytime);
                lst.Add(line);
            }
            return lst;
        }
    }
    
    [Serializable]
    public class KeyStatusValue
    {
        public string KeyValue { get; set; }
        public string Basetag { get; set; }
        public double Keytime { get; set; }
    }

    [Serializable]
    public class VotesFlat : KeyStatusValue
    {
        public VotesFlat(KeyValuePair<int, KeyStatusValue> vote)
        {
            KeyId = vote.Key;
            Basetag = vote.Value.Basetag;
            KeyValue = vote.Value.KeyValue;
            Keytime = vote.Value.Keytime;
        }
        public int KeyId { get; set; }

        
    }
}
