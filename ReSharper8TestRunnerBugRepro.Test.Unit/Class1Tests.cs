using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace ReSharper8TestRunnerBugRepro.Test.Unit
{
    [TestFixture]
    [Category("Fast")]
    public class Class1Tests
    {
        [Test]
        public void Test1()
        {
            var classs = new Class1();

            var setting = classs.GetSetting();

            Assert.That(setting, Is.Not.Null);
        }

        [Test]
        public void Test2()
        {
            var classs = new Class1();

            var setting = classs.GetSettingCalledTestSetting();

            Assert.That(setting, Is.EqualTo("value"));
        }

    }
}
