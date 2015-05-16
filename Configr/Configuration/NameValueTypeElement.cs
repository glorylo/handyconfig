﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Configr.Configuration
{
    public class NameValueTypeElement : ConfigurationElement
    {
        [ConfigurationProperty("name", IsKey = true, IsRequired = true)]
        public string Name
        {
            get { return (string)this["name"]; }
            set { this["name"] = value; }
        }

        [ConfigurationProperty("value", IsRequired = true)]
        public string Value
        {
            get
            {
                return (string)this["value"];
            }
            set { this["value"] = value; }
        }
        [ConfigurationProperty("type", DefaultValue = "System.String")]
        public string Type
        {
            get { return (string) this["type"] ?? "System.String"; }
            set { this["type"] = value; }
        }
    }
}
