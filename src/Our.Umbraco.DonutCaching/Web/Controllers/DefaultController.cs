namespace Our.Umbraco.DonutCaching.Web.Controllers
{
    using System;
    using System.Web.Mvc;
    using DevTrends.MvcDonutCaching;
    using global::Umbraco.Web.Models;
    using global::Umbraco.Web.Mvc;

    using ControllerAttributes;

    public class DefaultController : SurfaceController, IRenderMvcController
    {
        [DonutCache]
        public virtual ActionResult Index(ContentModel model)
        {
            return this.CurrentTemplate(model);
        }
        protected bool EnsurePhsyicalViewExists(string template)
        {
            try
            {
                var result = ViewEngines.Engines.FindView(ControllerContext, template, null);
                if (result.View == null)
                {
                    //LogHelper.Warn<DefaultController>("No physical template file was found for template " + template);
                    return false;
                }
            }
            catch (Exception ex)
            {

            }

            return true;
        }

        protected ActionResult CurrentTemplate<T>(T model)
        {
            var template = ControllerContext.RouteData.Values["action"].ToString();
            if (!this.EnsurePhsyicalViewExists(template))
            {
                return this.HttpNotFound();
            }

            return this.View(template, model);
        }

    }
}
