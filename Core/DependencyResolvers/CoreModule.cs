using System.Diagnostics;
using Core.CrossCuttingConcerns.Caching;
using Core.CrossCuttingConcerns.Caching.Microsoft;
using Core.CrossCuttingConcerns.Logging.Serilog;
using Core.Utilities.IOC;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace Core.DependencyResolvers
{
    public class CoreModule : ICoreModule
    {
        //TÜM PROJELERDE KULLANILABİLECEK INJECTİONLAR
        public void Load(IServiceCollection serviceCollection)
        {
            //BU MODÜL LOAD EDİLDİĞİNDE, AŞAĞIDAKİ DEPENDENCY'LERİ SERVİSE EKLE
            serviceCollection.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            serviceCollection.AddSingleton<Stopwatch>();
            serviceCollection.AddMemoryCache();
            serviceCollection.AddSingleton<ICacheManager, MemoryCacheManager>();
            //serviceCollection.AddSingleton<ICacheManager, RedisCacheManager>();

        }
    }
}