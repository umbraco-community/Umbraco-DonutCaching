using Our.Umbraco.DonutCaching.Web.Controllers;
using Umbraco.Core;
using Umbraco.Core.Composing;
using Umbraco.Web;

namespace Our.Umbraco.DonutCaching
{
    [RuntimeLevel(MinLevel = RuntimeLevel.Run)]
    public class DonutCachingComposer : IUserComposer
    {
        public void Compose(Composition composition)
        {
            composition.SetDefaultRenderMvcController(typeof(DefaultController));

            composition.Components().Append<DonutCachingComponent>();
        }
    }
}
