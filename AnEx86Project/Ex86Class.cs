using System.Configuration;

namespace AnEx86Project
{
    public class Ex86Class
    {
        public string GetSettingCalledTestSetting()
        {
            var setting = ConfigurationManager.AppSettings["test-setting"];
            return setting;
        }
    }
}
