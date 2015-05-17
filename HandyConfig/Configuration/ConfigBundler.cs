using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HandyConfig.Configuration
{
    public class ConfigBundler
    {
        public IDictionary<string, object> Configs { get; private set; }

        public ConfigBundler(IDictionary<string, object> configs)
        {
            Configs = configs;
        }

        private void UpsertSetting(string key, object value) 
        {
            if (Configs.ContainsKey(key))
                Configs[key] = value;
            else
                Configs.Add(key, value);
         }

        public ConfigBundler Bundle(NameValueTypeElementCollection settings)
        {
            foreach (NameValueTypeElement s in settings)
            {
                var o = Convert.ChangeType(s.Value, Type.GetType(s.Type));
                UpsertSetting(s.Name, o);
                Debug.WriteLine("Name: " + s.Name);
                Debug.WriteLine("Value: " + s.Value);
                Debug.WriteLine("Type: " + s.Type);
            }

            return this;
        }
    }
}
