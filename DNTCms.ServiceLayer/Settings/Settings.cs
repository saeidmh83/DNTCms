using System;
using DNTCms.DataLayer.Context;

namespace DNTCms.ServiceLayer.Settings
{
    public class Settings : ISettings
    {
        #region Fields
        private readonly IUnitOfWork _unitOfWork;
        private readonly Lazy<GeneralSettings> _lazyGeneralSettings;
        private readonly Lazy<SeoSettings> _lazySeoSettings;
        private readonly Lazy<UserSettings> _lazyUserSettings;
        private readonly Lazy<SocialSetting> _lazySocialSettings;
        #endregion
        #region Ctor

        public Settings(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            //_lazyUserSettings = new Lazy<UserSettings>(CreateSettings<UserSettings>);
            //_lazySeoSettings = new Lazy<SeoSettings>(CreateSettings<SeoSettings>);
        }
        #endregion
        public SeoSettings Seo => _lazySeoSettings.Value;

        public GeneralSettings General
        {
            get { throw new NotImplementedException(); }
        }

        public SocialSetting Social
        {
            get { throw new NotImplementedException(); }
        }

        public UserSettings User
        {
            get { throw new NotImplementedException(); }
        }

        #region Private
        private static T CreateSettings<T>() where T : SettingsBase, new()
        {
            var settings = new T();
            //settings.Load();
            return settings;
        }
        #endregion
    }
}
