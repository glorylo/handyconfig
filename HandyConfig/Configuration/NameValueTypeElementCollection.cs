using System.Configuration;

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
