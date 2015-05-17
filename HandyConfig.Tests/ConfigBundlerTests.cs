using NUnit.Framework;
using System;
using HandyConfig.Configuration;
using System.Collections.Generic;

namespace HandyConfig.Tests
{
    [TestFixture]
    public class ConfigBundlerTests
    {
        public NameValueTypeElementCollection Settings;
        public ConfigurationBundler Bundler { get; set; }

        [SetUp]
        public void Setup()
        {
            Settings = HandyConfigSection.Settings;
            Bundler = new ConfigurationBundler(new Dictionary<string, object>(), Settings);
        }

        [Test]
        public void LoadSettings()
        {
            


            Assert.Fail("test");
        }
    }
}
