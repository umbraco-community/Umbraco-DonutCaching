namespace Our.Umbraco.DonutCaching.Extensions.HtmlHelperExtensions
{
    using System.Web;
    using System.Web.Mvc;
    using System.Web.Mvc.Html;
    using DevTrends.MvcDonutCaching;
    /// <summary>
    /// Extension methods for <see cref="System.Web.Mvc.HtmlHelper"/>
    /// </summary>
    public static class HtmlHelperExtensions
    {
        /// <summary>
        /// Punches a hole though the default site-wide donut caching of each page
        /// Wrapper method that calls an Action method supplying the name of a partial to render
        /// IMPORTANT: all partials will be supplied with the current page model as calculated in the action method,
        /// and will NOT have access to ViewData / TempData / ViewBag - this is to prevent having to pass complex objects (which might not be serializable) into the routing parameters
        /// </summary>
        /// <param name="htmlHelper">this HtmlHelper</param>
        /// <param name="partialView">the name of the partial view to render</param>
        /// <param name="cacheByPage">The parameter is not used.</param>
        /// <param name="cacheByMember">The parameter is not used.</param>
        /// <returns>a rendered partial</returns>
        public static MvcHtmlString NoDonutCachePartial(this HtmlHelper htmlHelper, string partialView, bool cacheByPage = false, bool cacheByMember = false)
        {
            // get controller, and see if it has the [DonutCache]
            bool? donutCache = HttpContext.Current.Items["DonutCache"] as bool?;

            if (donutCache.HasValue && donutCache.Value)
            {
                return htmlHelper.Action(
                    "NoDonutCachePartial",
                    "DonutCacheHelperSurface",
                    new
                    {
                        partialView = partialView,
                        cacheByPage = cacheByPage,
                        cacheByMember = cacheByMember
                    },
                    true
                );
            }
            else
            {
                return htmlHelper.Action(
                    "NoDonutCachePartial",
                    "DonutCacheHelperSurface",
                    new
                    {
                        partialView = partialView,
                        cacheByPage = cacheByPage,
                        cacheByMember = cacheByMember
                    }
                );

            }
        }
    }
}
