namespace Our.Umbraco.DonutCaching
{
    using System.Web;
    using global::Umbraco.Web;
    public class Global : UmbracoApplication
    {
        /// <summary>
        /// <![CDATA[http://www.abstractmethod.co.uk/blog/2015/8/optimize-your-mvc-umbraco-site/]]>
        /// </summary>
        /// <param name="context">the http context</param>
        /// <param name="custom">custom string identifier</param>
        /// <returns>the full Umbraco url if varying by url</returns>
        public override string GetVaryByCustomString(HttpContext context, string custom)
        {
            if (custom.ToLower() == "url")
            {
                return "url=" + context.Request.Url.AbsoluteUri;
            }

            return base.GetVaryByCustomString(context, custom);
        }
    }
}
