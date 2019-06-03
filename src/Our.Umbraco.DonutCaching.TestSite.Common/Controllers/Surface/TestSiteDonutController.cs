namespace Our.Umbraco.DonutCaching.TestSite.Common.Controllers.Surface
{
    using System.Web.Mvc;
    using global::Umbraco.Web.Mvc;
    public class TestSiteDonutController : SurfaceController
    {
        public ActionResult Index()
        {
            return PartialView("~/Views/Partials/TestTicksAction.cshtml");
        }
    }
}
