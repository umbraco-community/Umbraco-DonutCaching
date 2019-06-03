namespace Our.Umbraco.DonutCaching.Web.ControllerAttributes
{
    using System.Web.Configuration;
    using System.Web.Mvc;
    using System.Web.UI;
    using DevTrends.MvcDonutCaching;
    using global::Umbraco.Web;
    using Current = global::Umbraco.Web.Composing.Current;

    /// <summary>
    /// Extends the default DonutOutputCache, ensuring that all URLs are uniquely cached, with the duration specified in the web.config (if enabled)
    /// </summary>
    public class DonutCacheAttribute : DonutOutputCacheAttribute
    {

        private readonly bool _enableDonutCaching;

        /// <summary>
        /// Initialises a new instance of the <see cref="DonutCacheAttribute"/> class
        /// </summary>
        public DonutCacheAttribute(bool enableDonutCaching = true)
        {
            this._enableDonutCaching = enableDonutCaching;

            this.Duration = this.Duration.Equals(0) ? 0 : int.Parse(WebConfigurationManager.AppSettings["DonutCacheDuration"]);
            this.VaryByCustom = "url";
            this.Location = OutputCacheLocation.Server;
        }

        /// <summary>
        /// Prevents donut output caching when in preview mode
        /// </summary>
        /// <param name="filterContext">The filter context</param>
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (this._enableDonutCaching)
            {
                filterContext.HttpContext.Items["DonutCache"] = true;

                if (this.Duration > 0)
                {
                    bool previewMode = Current.UmbracoContext.InPreviewMode;
                    bool debugMode = filterContext.HttpContext.IsDebuggingEnabled;
                    bool umbDebugMode;

                    var isDtgePreview = filterContext.HttpContext.Request.QueryString["dtgePreview"] == "1";

                    if (!bool.TryParse(filterContext.HttpContext.Request.QueryString["umbDebug"], out umbDebugMode))
                    {
                        umbDebugMode = false;
                    }

                    if (((!previewMode && !umbDebugMode) || (!debugMode && umbDebugMode)) && !isDtgePreview)
                    {
                        base.OnActionExecuting(filterContext);
                    }
                }
            }
        }
    }
}
