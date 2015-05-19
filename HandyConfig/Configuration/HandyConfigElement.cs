using System.Configuration;

namespace HandyConfig.Configuration
{
    public class HandyConfigElement : ConfigurationElement
    {
        [ConfigurationProperty("", IsDefaultCollection = true)]
        [ConfigurationCollection(typeof(NameValueTypeElementCollection), AddItemName = "add")]
        public NameValueTypeElementCollection NameValueTypes
        {
            get { return (NameValueTypeElementCollection)this[""]; }
            set { this[""] = value; }
        }
    } 
    
    
}
