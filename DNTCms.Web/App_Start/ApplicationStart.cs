using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure.Interception;
using System.Linq;
using System.Web.Mvc;
using System.Xml;
using CaptchaMvc.Infrastructure;
using DNTCms.Common.Controller;
using DNTCms.Common.Json;
using DNTCms.DataLayer.Context;
using DNTCms.ServiceLayer.Contracts.Common;
using DNTCms.Web.IocConfig;
using ElmahEFLogger.CustomElmahLogger;
using Microsoft.AspNet.SignalR;

namespace DNTCms.Web
{
    public static class ApplicationStart
    {
        #region Config
        public static void Config()
        {
            // disable response header for protection  attak
            MvcHandler.DisableMvcResponseHeader = true;

            // change captcha provider for using cookie
            CaptchaUtils.CaptchaManager.StorageProvider = new CookieStorageProvider();

            //Set current Controller factory as StructureMapControllerFactory
            ControllerBuilder.Current.SetControllerFactory(new StructureMapControllerFactory());

            //set current Filter factory as StructureMapFitlerProvider
            var filterProider = FilterProviders.Providers.Single(p => p is FilterAttributeFilterProvider);
            FilterProviders.Providers.Remove(filterProider);
            FilterProviders.Providers.Add(ProjectObjectFactory.Container.GetInstance<StructureMapFilterProvider>());


            var defaultJsonFactory = ValueProviderFactories.Factories
                .OfType<JsonValueProviderFactory>().FirstOrDefault();
            var index = ValueProviderFactories.Factories.IndexOf(defaultJsonFactory);
            ValueProviderFactories.Factories.Remove(defaultJsonFactory);
            ValueProviderFactories.Factories.Insert(index, new JsonNetValueProviderFactory());

            foreach (var task in ProjectObjectFactory.Container.GetAllInstances<IRunAtInit>())
            {
                task.Execute();
            }

            GlobalHost.DependencyResolver = ProjectObjectFactory.Container.GetInstance<Microsoft.AspNet.SignalR.IDependencyResolver>();
            ModelBinders.Binders.Add(typeof(DateTime), new PersianDateModelBinder());
            ModelBinders.Binders.Add(typeof(DateTime?), new PersianDateModelBinder());
            ModelBinders.Binders.Add(typeof(decimal), new DecimalModelBinder());
            ModelBinders.Binders.Add(typeof(decimal?), new DecimalModelBinder());

            // DataAnnotationsModelValidatorProvider.AddImplicitRequiredAttributeForValueTypes = false;
            ConfigEf();
        }

        #endregion

        #region Dbconfig

        static void ConfigEf()
        {
            //Database.SetInitializer<ApplicationDbContext>(null);
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ApplicationDbContext, DataLayer.Migrations.Configuration>());
            //ProjectObjectFactory.Container.GetInstance<IUnitOfWork>().ForceDatabaseInitialize();
            DbInterception.Add(new ElmahEfInterceptor());

            using (var db = new ApplicationDbContext())
            {
                ExportMappings(db, @"E:\mappings.edmx");
            }
        }
        static void ExportMappings(DbContext context, string edmxFile)
        {
            var settings = new XmlWriterSettings { Indent = true };
            using (var writer = XmlWriter.Create(edmxFile, settings))
            {
                System.Data.Entity.Infrastructure.EdmxWriter.WriteEdmx(context, writer);
            }
        }
        #endregion

    }
}