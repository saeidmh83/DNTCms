using System.Web.Mvc;
using DNTCms.Web.Services.BrowserConfig;
using DNTCms.Web.Services.Cache;
using DNTCms.Web.Services.Feed;
using DNTCms.Web.Services.Logging;
using DNTCms.Web.Services.Manifest;
using DNTCms.Web.Services.OpenSearch;
using DNTCms.Web.Services.Robots;
using DNTCms.Web.Services.Sitemap;
using DNTCms.Web.Services.SitemapPinger;
using StructureMap.Configuration.DSL;
using StructureMap.Web;

namespace DNTCms.Web.IocConfig
{
    public class LocalRegistery : Registry
    {
        public LocalRegistery()
        {
            For<IBrowserConfigService>().HybridHttpOrThreadLocalScoped().Use<BrowserConfigService>();
            For<ICacheService>().HybridHttpOrThreadLocalScoped().Use<CacheService>();
            For<IFeedService>().HybridHttpOrThreadLocalScoped().Use<FeedService>();
            For<ILoggingService>().HybridHttpOrThreadLocalScoped().Use<LoggingService>();
            For<IManifestService>().HybridHttpOrThreadLocalScoped().Use<ManifestService>();
            For<IOpenSearchService>().HybridHttpOrThreadLocalScoped().Use<OpenSearchService>();
            For<IRobotsService>().HybridHttpOrThreadLocalScoped().Use<RobotsService>();
            For<ISitemapService>().HybridHttpOrThreadLocalScoped().Use<SitemapService>();
            For<ISitemapPingerService>().HybridHttpOrThreadLocalScoped().Use<SitemapPingerService>();
            For<UrlHelper>().HybridHttpOrThreadLocalScoped().Use<UrlHelper>();
        }
    }
}