using NUnit.Framework;
using System;
using HandyConfig.Configuration;
using System.Collections.Generic;
using System.Diagnostics;

namespace HandyConfig.Tests
{
    [TestFixture]
    public class ConfigBundlerTests
    {
        public NameValueTypeElementCollection Settings;
        public ConfigBundler Bundler { get; set; }

        [SetUp]
        public void Setup()
        {
            Settings = HandyConfigSection.Settings;
            Bundler = new ConfigBundler(new Dictionary<string, object>());
        }

        [Test]
        public void CountTest()
        {
            var configs = Bundler.Bundle(Settings).Configs;
            Assert.IsTrue(configs.Count == 6);
        }

        private bool Compare<T>(object actual, T expected)
        {
            Trace.WriteLine("Expected: " + expected);
            Trace.WriteLine("Actual: " + actual);
            return actual.Equals(expected);
        }

        [Test]
        public void StringTypeTest()
        {
            var configs = Bundler.Bundle(Settings).Configs;
            var check = Compare(configs["longstring"], "a long string");
            Assert.IsTrue(check);
        }

        [Test]
        public void IntValueTest()
        {
            var configs = Bundler.Bundle(Settings).Configs;
            var check = Compare(configs["fiftythree"], 53);
            Assert.IsTrue(check);
        }

        [Test]
        public void TrueValueTest()
        {
            var configs = Bundler.Bundle(Settings).Configs;
            var check = Compare(configs["booltrue"], true);
            Assert.IsTrue(check);
        }

        [Test]
        public void FalseValueTest()
        {
            var configs = Bundler.Bundle(Settings).Configs;
            var check = Compare(configs["boolfalse"], false);
            Assert.IsTrue(check);
        }

        [Test]
        public void DateTest()
        {
            var configs = Bundler.Bundle(Settings).Configs;
            var dec25 = new DateTime(1950, 12, 25);
            var check = Compare(configs["date"], dec25);
            Assert.IsTrue(check);
        }

        [Test]
        public void DoubleTest()
        {
            var configs = Bundler.Bundle(Settings).Configs;
            var aDouble = 100.99;
            var check = Compare(configs["double"], aDouble);
            Assert.IsTrue(check);
        }

        [Test]
        public void GetDoubleSettingTest()
        {
            Bundler.Bundle(Settings);
            var aDouble = 100.99;
            double actual = Bundler.GetSetting<double>("double");
            var check = Compare(actual, aDouble);
            Assert.IsTrue(check);
        }
    }
}
