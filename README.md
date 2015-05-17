![#](https://img.shields.io/nuget/v/handyconfig.svg?style=flat)</div>
<br/>


#Introduction

HandyConfig is a lightweight library to load application configuration settings into a dictionary.  It simplifies reading values from a string, apply parsing, then do type conversion.

Would you rather write:  

```csharp
var installApp = Convert.ToBoolean(ConfigurationManager.AppSettings["InstallApp"])
```

Or in your App.config

```xml
 <handyconfig>
    <add name="InstallApp" value="true" type="System.Boolean" /> 
    ...
</handyconfig>
```

```csharp     
var bundler = new ConfigBundler(new Dictionary<string, object>(), HandyConfigSection.Settings);

var configs = bundler.Bundle();

var installApp = configs["InstallApp"];

// installApp == true
```

Other examples with date time, integers, doubles and more:
```xml
<handyconfig>
    <add name="longstring" value="a long string" />
    <add name="fiftythree" value="53" type="System.Int32"/>
    <add name="booltrue" value="true" type="System.Boolean" />
    <add name="boolfalse" value="false" type="System.Boolean" />
    <add name="date" value="Dec 25, 1950" type="System.DateTime" />
    <add name="double" value="100.99" type="System.Double" />
</handyconfig>
```
# Installation

Using Nuget Package Manager Console:

```
PM> Install-Package HandyConfig
```


Have fun,


Glory Lo


