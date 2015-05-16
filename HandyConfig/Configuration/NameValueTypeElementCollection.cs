using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HandyConfig.Configuration
{
    public class NameValueTypeElementCollection : ConfigurationElementCollection
    {
        protected override ConfigurationElement CreateNewElement()
        {
            return new NameValueTypeElement();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((NameValueTypeElement)element).Name;
        }
    }
}
