using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace HandyConfig.Configuration
{
    public class HandyConfigSection: ConfigurationSection
    {
        public static NameValueTypeElementCollection Settings =
            ((HandyConfigSection) ConfigurationManager
              .GetSection("handyconfig")).NameValueTypes;

        [ConfigurationProperty("", IsDefaultCollection = true)]
        [ConfigurationCollection(typeof(NameValueTypeElementCollection), AddItemName = "add")]
        public NameValueTypeElementCollection NameValueTypes
        {
            get  { return (NameValueTypeElementCollection) this[""];  }
            set  { this[""] = value;  }
        }
    }
}
