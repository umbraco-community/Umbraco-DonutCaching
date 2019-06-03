namespace Our.Umbraco.DonutCaching.TestSite.Common.Controllers.Render
{
    using System.Web.Mvc;
    using global::Umbraco.Web.Models;
    using global::Umbraco.Web.Mvc;
    public class ProductsController : RenderMvcController
    {
        public override ActionResult Index(ContentModel model)
        {
            // Do nothing, this controller doesn't implement Donut caching
            return base.Index(model);
        }
    }
}
