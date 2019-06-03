namespace Our.Umbraco.DonutCaching
{
    using System;
    using DevTrends.MvcDonutCaching;
    using global::Umbraco.Core.Cache;
    using global::Umbraco.Core.Composing;
    using global::Umbraco.Core.Logging;
    using global::Umbraco.Web.Cache;
    using Current = global::Umbraco.Web.Composing.Current;

    public class DonutCachingComponent : IComponent
    {
        private readonly ILogger _logger;
        public DonutCachingComponent(ILogger logger)
        {
            _logger = logger;
        }
        public void Initialize()
        {
            _logger.Info<DonutCachingComponent>($"Component: DonutCachingComponent was initialized");

            ContentCacheRefresher.CacheUpdated += ContentCacheRefresher_CacheUpdated;
            MediaCacheRefresher.CacheUpdated += MediaCacheRefresher_CacheUpdated;
            DictionaryCacheRefresher.CacheUpdated += DictionaryCacheRefresher_CacheUpdated;
        }

        private void ContentCacheRefresher_CacheUpdated(ContentCacheRefresher sender, CacheRefresherEventArgs e)
        {
            _logger.Debug<DonutCachingComponent>($"ContentCacheRefresher.CacheUpdated : '{e.MessageType}'");
            ClearDonutOutputCache();
        }

        private void MediaCacheRefresher_CacheUpdated(MediaCacheRefresher sender, CacheRefresherEventArgs e)
        {
            _logger.Debug<DonutCachingComponent>($"MediaCacheRefresher.CacheUpdated : '{e.MessageType}'");
            ClearDonutOutputCache();
        }
        private void DictionaryCacheRefresher_CacheUpdated(DictionaryCacheRefresher sender, CacheRefresherEventArgs e)
        {
            _logger.Debug<DonutCachingComponent>($"DictionaryCacheRefresher.CacheUpdated : '{e.MessageType}'");
            ClearDonutOutputCache();
        }

        private void ClearDonutOutputCache()
        {
            var cacheManager = new OutputCacheManager();
            cacheManager.RemoveItems();
            _logger.Info<DonutCachingComponent>($"Donut Output Cache Cleared On Server:{Environment.MachineName} AppDomain:{AppDomain.CurrentDomain.FriendlyName} SiteName:{System.Web.Hosting.HostingEnvironment.SiteName}");
        }

        public void Terminate()
        {
            _logger.Info<DonutCachingComponent>($"Component: DonutCachingComponent was terminated");
        }
    }
}
