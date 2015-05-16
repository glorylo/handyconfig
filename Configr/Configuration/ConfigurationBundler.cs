using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Configr.Configuration
{
    public class ConfigurationBundler
    {
        private IDictionary<string, object> _bundle;
        private NameValueTypeElementCollection _settings;

        public ConfigurationBundler(IDictionary<string, object> bundle, NameValueTypeElementCollection settings)
        {
            _bundle = bundle;
            _settings = settings;
        }

        public IDictionary<string, object> GatherSettings()
        {
            foreach (NameValueTypeElement s in _settings)
            {
                var o = Convert.ChangeType(s.Value, Type.GetType(s.Type));
                _bundle.Add(s.Name, o);
                Debug.WriteLine("Name: " + s.Name);
                Debug.WriteLine("Value: " + s.Value);
                Debug.WriteLine("Type: " + s.Type);
            }

            return _bundle;

        }
    }
}
