namespace Our.Umbraco.DonutCaching.Web.Controllers
{
    using System.Web.Mvc;
    using global::Umbraco.Web.Mvc;

    /// <summary>
    /// Helper controller to support the Html.NoDonutCachePartial helper method
    /// By default all pages are set to use donut caching, varied by url
    /// </summary>
    public class DonutCacheHelperSurfaceController : SurfaceController
    {
        /// <summary>
        /// Returns a partial view with the model for the current page
        /// IMPORTANT: ViewData, ViewBag and TempData will NOT be available
        /// </summary>
        /// <param name="partialView">The partial view to render</param>
        /// <param name="cacheByPage">The parameter is not used.</param>
        /// <param name="cacheByMember">The parameter is not used.</param>
        /// <returns>an empty result or a partial view</returns>
        [ChildActionOnly]
        public ActionResult NoDonutCachePartial(string partialView, bool cacheByPage, bool cacheByMember)
        {
            if (!string.IsNullOrWhiteSpace(partialView))
            {
                return this.PartialView(partialView, this.CurrentPage);
            }

            return new EmptyResult();
        }
    }
}
