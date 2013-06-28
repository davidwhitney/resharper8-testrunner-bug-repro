using System.Configuration;

namespace ReSharper8TestRunnerBugRepro
{
    public class Class1
    {
        public MobileGivingIndexViewModel GetSetting()
        {
            var factory = new MobileGivingIndexViewModelFactory();
            return factory.CreateModel();
        }

        public string GetSettingCalledTestSetting()
        {
            var setting = ConfigurationManager.AppSettings["test-setting"];
            return setting;
        }
    }

    public class MobileGivingIndexViewModelFactory :
     EnvironmentSensitiveViewModelFactory<MobileGivingIndexViewModel>
    {
        public static string LogOffUri = "/charities/account/logoff";
        
        private MobileGivingIndexViewModel CreateModel()
        {
            return new MobileGivingIndexViewModel();
        }

        protected override MobileGivingIndexViewModel CreateModelForLocal()
        {
            return CreateModel();
        }

        protected override MobileGivingIndexViewModel CreateModelForTeamServer()
        {
            return CreateModel();
        }

        protected override MobileGivingIndexViewModel CreateModelForQAPreview()
        {
            return CreateModel();
        }

        protected override MobileGivingIndexViewModel CreateModelForStaging()
        {
            return CreateModel();
        }

        protected override MobileGivingIndexViewModel CreateModelForRelease()
        {
            return CreateModel();
        }
    }

    public class MobileGivingIndexViewModel : IIocContainerCreatedViewModel
    {
    }

    public interface IViewModel { }
    public interface IIocContainerCreatedViewModel : IViewModel { }
    public interface IViewModelFactory<out TModel> where TModel : IIocContainerCreatedViewModel, new()
    {
        TModel CreateModel(params object[] arguments);
    } 
    public abstract class EnvironmentSensitiveViewModelFactory<TModel> :
        IViewModelFactory<TModel> where TModel : IIocContainerCreatedViewModel, new()
    {
        private const string EnvironmentNameAppSettingsKey = "EnvironmentName";
        private const string LocalEnvironmentAppSettingsValue = "Local";
        private const string QAPreviewEnvironmentAppSettingsValue = "QAPreview";
        private const string TeamServerEnvironmentAppSettingsValue = "TeamServer";
        private const string StagingEnvironmentAppSettingsValue = "Staging";
        private const string ReleaseEnvironmentAppSettingsValue = "Release";

        /// <summary>
        ///   Performs invocation of the method corresponding to the 
        ///   current deployment environment.
        /// </summary>
        public TModel CreateModel(params object[] arguments)
        {
            switch (ConfigurationManager.AppSettings[EnvironmentNameAppSettingsKey])
            {
                case LocalEnvironmentAppSettingsValue:
                    return CreateModelForLocal();
                case TeamServerEnvironmentAppSettingsValue:
                    return CreateModelForTeamServer();
                case QAPreviewEnvironmentAppSettingsValue:
                    return CreateModelForQAPreview();
                case StagingEnvironmentAppSettingsValue:
                    return CreateModelForStaging();
                case ReleaseEnvironmentAppSettingsValue:
                    return CreateModelForRelease();
                default:
                    throw new ConfigurationErrorsException(EnvironmentNameAppSettingsKey);
            }
        }

        protected abstract TModel CreateModelForLocal();
        protected abstract TModel CreateModelForTeamServer();
        protected abstract TModel CreateModelForQAPreview();
        protected abstract TModel CreateModelForStaging();
        protected abstract TModel CreateModelForRelease();
    }
}
