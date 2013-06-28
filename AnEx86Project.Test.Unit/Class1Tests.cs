using NUnit.Framework;

namespace AnEx86Project.Test.Unit
{
    [TestFixture]
    [Category("Fast")]
    public class Ex86ClassTests
    {
        [Test]
        public void Test2()
        {
            var classs = new Ex86Class();

            var setting = classs.GetSettingCalledTestSetting();

            Assert.That(setting, Is.EqualTo("value"));
        }

    }
}
