using System.Web.Mvc;
using DNTCms.Common.Controller;

namespace DNTCms.Web.Controllers
{
    #region namespaces

    

    #endregion

    public partial class HomeController : BaseController
    {
        #region Fields

        //private readonly IBrowserConfigService _browserConfigService;
        //private readonly IFeedService _feedService;
        //private readonly IManifestService _manifestService;
        //private readonly IOpenSearchService _openSearchService;
        //private readonly IRobotsService _robotsService;
        //private readonly ISitemapService _sitemapService;

        #endregion

        #region Ctor

        //public HomeController(
        //    IBrowserConfigService browserConfigService,
        //    IFeedService feedService,
        //    IManifestService manifestService,
        //    IOpenSearchService openSearchService,
        //    IRobotsService robotsService,
        //    ISitemapService sitemapService)
        //{
        //    _browserConfigService = browserConfigService;
        //    _feedService = feedService;
        //    _manifestService = manifestService;
        //    _openSearchService = openSearchService;
        //    _robotsService = robotsService;
        //    _sitemapService = sitemapService;
        //}

        #endregion

        #region Index
        [Route("")]
        public virtual ActionResult Index()
        {
            return View();
        }
        #endregion
        
        #region About
        [Route("about")]
        public virtual ActionResult About()
        {
            return View();
        }
        #endregion
        
        #region Contact
        [Route("contact")]
        public virtual ActionResult Contact()
        {
            return View();
        }

        #endregion
        
        //#region Feed
        //[OutputCache(CacheProfile = CacheProfileName.Feed)]
        //[Route("feed")]
        //public virtual async Task<ActionResult> Feed()
        //{
        //    // A CancellationToken signifying if the request is cancelled. See
        //    // http://www.davepaquette.com/archive/2015/07/19/cancelling-long-running-queries-in-asp-net-mvc-and-web-api.aspx
        //    var cancellationToken = Response.ClientDisconnectedToken;
        //    return new AtomActionResult(await _feedService.GetFeed(cancellationToken));
        //}

        //#endregion
        
        //#region Search
        //[Route("search")]
        //public virtual ActionResult Search(string query)
        //{
        //    return Redirect(
        //        $"https://www.google.co.uk/?q=site:{Url.AbsoluteRouteUrl("")} {query}");
        //}
        //#endregion

        //#region BrowserConfigXml
        ///// <summary>
        ///// Gets the browserconfig XML for the current site. This allows you to customize the tile, when a user pins 
        ///// the site to their Windows 8/10 start screen. See http://www.buildmypinnedsite.com and 
        ///// https://msdn.microsoft.com/en-us/library/dn320426%28v=vs.85%29.aspx
        ///// </summary>
        ///// <returns>The browserconfig XML for the current site.</returns>
        //[NoTrailingSlash]
        //[OutputCache(CacheProfile = CacheProfileName.BrowserConfigXml)]
        //[Route("browserconfig.xml")]
        //public virtual ContentResult BrowserConfigXml()
        //{
        //    Trace.WriteLine($"browserconfig.xml requested. User Agent:<{Request.Headers.Get("User-Agent")}>.");
        //    var content = _browserConfigService.GetBrowserConfigXml();
        //    return Content(content, ContentType.Xml, Encoding.UTF8);
        //}

        //#endregion

        //#region ManifestJson
        ///// <summary>
        ///// Gets the manifest JSON for the current site. This allows you to customize the icon and other browser 
        ///// settings for Chrome/Android and FireFox (FireFox support is coming). See https://w3c.github.io/manifest/
        ///// for the official W3C specification. See http://html5doctor.com/web-manifest-specification/ for more 
        ///// information. See https://developer.chrome.com/multidevice/android/installtohomescreen for Chrome's 
        ///// implementation.
        ///// </summary>
        ///// <returns>The manifest JSON for the current site.</returns>
        //[NoTrailingSlash]
        //[OutputCache(CacheProfile = CacheProfileName.ManifestJson)]
        //[Route("manifest.json")]
        //public virtual ContentResult ManifestJson()
        //{
        //    Trace.WriteLine($"manifest.jsonrequested. User Agent:<{Request.Headers.Get("User-Agent")}>.");
        //    var content = _manifestService.GetManifestJson();
        //    return Content(content, ContentType.Json, Encoding.UTF8);
        //}
        //#endregion

        //#region OpenSearchXml
        ///// <summary>
        ///// Gets the Open Search XML for the current site. You can customize the contents of this XML here. The open 
        ///// search action is cached for one day, adjust this time to whatever you require. See
        ///// http://www.hanselman.com/blog/CommentView.aspx?guid=50cc95b1-c043-451f-9bc2-696dc564766d
        ///// http://www.opensearch.org
        ///// </summary>
        ///// <returns>The Open Search XML for the current site.</returns>
        //[NoTrailingSlash]
        //[OutputCache(CacheProfile = CacheProfileName.OpenSearchXml)]
        //[Route("opensearch.xml")]
        //public virtual ContentResult OpenSearchXml()
        //{
        //    Trace.WriteLine($"opensearch.xml requested. User Agent:<{Request.Headers.Get("User-Agent")}>.");
        //    var content = _openSearchService.GetOpenSearchXml();
        //    return Content(content, ContentType.Xml, Encoding.UTF8);
        //}
        //#endregion

        //#region RobotsText
        ///// <summary>
        ///// Tells search engines (or robots) how to index your site. 
        ///// The reason for dynamically generating this code is to enable generation of the full absolute sitemap URL
        ///// and also to give you added flexibility in case you want to disallow search engines from certain paths. The 
        ///// sitemap is cached for one day, adjust this time to whatever you require. See
        ///// http://rehansaeed.com/dynamically-generating-robots-txt-using-asp-net-mvc/
        ///// </summary>
        ///// <returns>The robots text for the current site.</returns>
        //[NoTrailingSlash]
        //[OutputCache(CacheProfile = CacheProfileName.RobotsText)]
        //[Route("robots.txt")]
        //public virtual ContentResult RobotsText()
        //{
        //    Trace.WriteLine($"robots.txt requested. User Agent:<{Request.Headers.Get("User-Agent")}>.");
        //    var content = _robotsService.GetRobotsText();
        //    return Content(content, ContentType.Text, Encoding.UTF8);
        //}
        //#endregion

        //#region SitemapXml
        ///// <summary>
        ///// Gets the sitemap XML for the current site. You can customize the contents of this XML from the 
        ///// <see cref="SitemapService"/>. The sitemap is cached for one day, adjust this time to whatever you require.
        ///// http://www.sitemaps.org/protocol.html
        ///// </summary>
        ///// <param name="index">The index of the sitemap to retrieve. <c>null</c> if you want to retrieve the root 
        ///// sitemap file, which may be a sitemap index file.</param>
        ///// <returns>The sitemap XML for the current site.</returns>
        //[NoTrailingSlash]
        //[Route("sitemap.xml")]
        //public virtual ActionResult SitemapXml(int? index = null)
        //{
        //    var content = _sitemapService.GetSitemapXml(index);

        //    if (content == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "Sitemap index is out of range.");
        //    }

        //    return Content(content, ContentType.Xml, Encoding.UTF8);
        //}
        //#endregion

    }
}