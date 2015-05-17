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
        private IDictionary<string, object> _bundle;
        private NameValueTypeElementCollection _settings;

        public ConfigBundler(IDictionary<string, object> bundle, NameValueTypeElementCollection settings)
        {
            _bundle = bundle;
            _settings = settings;
        }

        private void UpsertSetting(string key, object value) {
            if (_bundle.ContainsKey(key))
                _bundle[key] = value;
            else
                _bundle.Add(key, value);
         }

        public IDictionary<string, object> Bundle()
        {
            foreach (NameValueTypeElement s in _settings)
            {
                var o = Convert.ChangeType(s.Value, Type.GetType(s.Type));
                UpsertSetting(s.Name, o);
                Debug.WriteLine("Name: " + s.Name);
                Debug.WriteLine("Value: " + s.Value);
                Debug.WriteLine("Type: " + s.Type);
            }

            return _bundle;

        }
    }
}
