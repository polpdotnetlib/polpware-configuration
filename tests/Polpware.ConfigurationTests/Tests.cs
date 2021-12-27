using NUnit.Framework;
using Polpware.Configuration.Json;
using System.IO;
using Polpware.Configuration.Binder;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;

namespace Polpware.ConfigurationTests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestProvider()
        {
            var path = Path.GetDirectoryName(Path.GetDirectoryName(TestContext.CurrentContext.TestDirectory));

            var file = System.IO.Path.Combine(path, "../data/appsettings.json");
            var provider = new JsonSettingsProvider();
            provider.Build(file);

            var s = provider.ReadAsString();

            Assert.IsNotNull(s);

            Assert.Pass();
        }

        [Test]
        public void TestExtensions()
        {
            var path = Path.GetDirectoryName(Path.GetDirectoryName(TestContext.CurrentContext.TestDirectory));

            var file = System.IO.Path.Combine(path, "../data/appsettings.json");
            var provider = new JsonSettingsProvider();
            provider.Build(file);

            var s = provider.ReadAs(x => JObject.Parse(x));

            var t = s.ToTypeSafeObject<SettingsClassSample, Newtonsoft.Json.Linq.JToken>();

            Assert.AreEqual(t.username, "hello");

            Assert.Pass();

        }

    }
}