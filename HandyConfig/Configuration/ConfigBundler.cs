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
        private IDictionary<string, object> _configs;

        public ConfigBundler(IDictionary<string, object> configs)
        {
            _configs = configs;
        }

        private void UpsertSetting(string key, object value) 
        {
            if (_configs.ContainsKey(key))
                _configs[key] = value;
            else
                _configs.Add(key, value);
         }

        public IDictionary<string, object> GetConfigs()
        {
            return _configs;
        }

        public ConfigBundler Bundle(NameValueTypeElementCollection settings)
        {
            foreach (NameValueTypeElement s in settings)
            {
                var o = Convert.ChangeType(s.Value, Type.GetType(s.Type));
                UpsertSetting(s.Name, o);
                Debug.WriteLine("Name: " + s.Name);
                Debug.WriteLine("Value: " + o);
                Debug.WriteLine("Type: " + o.GetType());
            }

            return this;
        }

        public T GetSetting<T>(string key) 
        { 
            if (!_configs.ContainsKey(key))
                throw new KeyNotFoundException("Unable to find setting with key: " + key);

            return (T) _configs[key];
        }
    }
}
