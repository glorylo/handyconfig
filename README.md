![#](https://img.shields.io/nuget/v/handyconfig.svg?style=flat)</div>
<br/>


#Introduction

HandyConfig is a lightweight library to load application configuration settings into a dictionary.  It simplifies reading values from a string, apply parsing, then do type conversion.

Would you rather write:  

```csharp
var installApp = Convert.ToBoolean(ConfigurationManager.AppSettings["InstallApp"])
var timeOutSecs = Convert.ToInt32(ConfigurationManager.AppSettings["TimeoutSecs"]);
var expiryDate = Convert.ToDateTime(ConfigurationManager.AppSettings["ExpiryDate"]);
```

Or in your App.config

```xml
 <handyconfig>
    <add name="InstallApp" value="true" type="System.Boolean" /> 
    <add name="TimeoutSecs" value="30" type="System.Int32"/>
    <add name="ExpiryDate" value="Dec 31, 2015" type="System.DateTime" />
    ...
</handyconfig>
```

```csharp   

var bundler = new ConfigBundler();
bundler.Bundle(HandyConfigSection.Settings);

// installApp == true
bool installApp = bundler.Get<bool>("InstallApp");

// timeoutSecs == 30
int timeoutSecs = bundler.Get<int>("TimeoutSecs");

// expiryDate is 2015/12/31
DateTime expiryDate = bundler.Get<DateTime>("ExpiryDate");

// get back all the configuration settings
IDictionary<string, object> configs = bundler.GetConfigs();

```


# Installation

Using Nuget Package Manager Console:

```
PM> Install-Package HandyConfig
```

Add the following section to your App.Config:

```xml
  <configSections>
    <section name="handyconfig" type="HandyConfig.Configuration.HandyConfigSection, HandyConfig"/>
  </configSections>
```

Then add your settings under the handyconfig section.  Here is an entire template App.config:

```xml
<?xml version="1.0" encoding="utf-8" ?>
<configuration>
  <configSections>
    <section name="handyconfig" type="HandyConfig.Configuration.HandyConfigSection, HandyConfig"/>
  </configSections>

  <handyconfig>
    <add name="InstallApp" value="true" type="System.Boolean" /> 
    <add name="TimeoutSecs" value="30" type="System.Int32"/>
    <add name="ExpiryDate" value="Dec 31, 2015" type="System.DateTime" />
  </handyconfig>
</configuration>

```
# Making use of HandyConfig for custom configurations

You can make use of HandyConfig for your own customizations.   For example:

```xml
<machine name="test">
   <add name="description" value="This is a test machine" />
   <add name="ip" value="10.10.1.100" />
   <add name="archive-count" value="5" type="System.Int32" />
   <add name="clean-install" value="true" type="System.Boolean" />
   <add name="backup-date" value="May 1, 2015" type="System.DateTime" />
</machine>

```

```csharp
    public class MachineElement : HandyConfigElement
    {
        [ConfigurationProperty("name", IsRequired = true, IsKey = true)]
        public string Name
        {
            get { return this["name"] as string; }
            set { this["name"] = value; }
        }
    }
```

Have fun,


Glory Lo


