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
            var configs = Bundler.Bundle(Settings).GetConfigs();
            Assert.IsTrue(configs.Count == 7);
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
            var configs = Bundler.Bundle(Settings).GetConfigs();
            var check = Compare(configs["longstring"], "a long string");
            Assert.IsTrue(check);
        }

        [Test]
        public void IntValueTest()
        {
            var configs = Bundler.Bundle(Settings).GetConfigs();
            var check = Compare(configs["fiftythree"], 53);
            Assert.IsTrue(check);
        }

        [Test]
        public void TrueValueTest()
        {
            var configs = Bundler.Bundle(Settings).GetConfigs();
            var check = Compare(configs["booltrue"], true);
            Assert.IsTrue(check);
        }

        [Test]
        public void FalseValueTest()
        {
            var configs = Bundler.Bundle(Settings).GetConfigs();
            var check = Compare(configs["boolfalse"], false);
            Assert.IsTrue(check);
        }

        [Test]
        public void DateTest()
        {
            var configs = Bundler.Bundle(Settings).GetConfigs();
            var dec25 = new DateTime(1950, 12, 25);
            var check = Compare(configs["date"], dec25);
            Assert.IsTrue(check);
        }

        [Test]
        public void DoubleTest()
        {
            var configs = Bundler.Bundle(Settings).GetConfigs();
            var aDouble = 100.99;
            var check = Compare(configs["double"], aDouble);
            Assert.IsTrue(check);
        }

        [Test]
        public void GetIntSettingTest()
        {
            Bundler.Bundle(Settings);
            int aInt = 53;
            int actual = Bundler.Get<int>("fiftythree");
            var check = Compare(actual, aInt);
            Assert.IsTrue(actual == aInt);
        }

        [Test]
        public void GetFalseBoolTest()
        {
            Bundler.Bundle(Settings);
            var aBool = false;
            bool actual = Bundler.Get<bool>("boolfalse");
            var check = Compare(actual, aBool);
            Assert.IsTrue(actual == aBool);
        }

        [Test]
        public void GetTrueBoolTest()
        {
            Bundler.Bundle(Settings);
            var aBool = true;
            bool actual = Bundler.Get<bool>("booltrue");
            var check = Compare(actual, aBool);
            Assert.IsTrue(actual == aBool);
        }

        [Test]
        public void GetDoubleSettingTest()
        {
            Bundler.Bundle(Settings);
            var aDouble = 100.99;
            double actual = Bundler.Get<double>("double");
            var check = Compare(actual, aDouble);
            Assert.IsTrue(actual == aDouble);
        }

        [Test]
        public void GetStringSettingTest()
        {
            Bundler.Bundle(Settings);
            var aString = "a long string" ;
            string actual = Bundler.Get<string>("longstring");
            var check = Compare(actual, aString);
            Assert.IsTrue(actual == aString);
        }

        [Test]
        public void GetDateTimeSettingTest()
        {
            Bundler.Bundle(Settings);
            var dec25 = new DateTime(1950, 12, 25);
            DateTime actual = Bundler.Get<DateTime>("date");
            var check = Compare(actual, dec25);
            Assert.IsTrue(actual == dec25);
        }

        [Test]
        public void GetUnknownSettingTest()
        {
            Bundler.Bundle(Settings);
            TestDelegate getUnknown = () =>  Bundler.Get<DateTime>("does not exist"); ;
            Assert.Throws(typeof(KeyNotFoundException), getUnknown);
        }

        [Test]
        public void GetCaseInsensitiveDoubleTest()
        {
            Bundler.Bundle(Settings);
            var aDouble = 500.00;
            var actual = Bundler.Get<double>("caseinsensitive");
            var check = Compare(actual, aDouble);
            Assert.IsTrue(Math.Abs(actual - aDouble) < 0.01);
        }
    }
}
