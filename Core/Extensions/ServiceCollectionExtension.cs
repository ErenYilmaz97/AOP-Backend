using Core.Utilities.IOC;
using Microsoft.Extensions.DependencyInjection;

namespace Core.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddDependencyResolvers
            (this IServiceCollection serviceCollection, ICoreModule[] modules)
        {
            foreach (var module in modules)
            {
                //TÜM MODÜLLERİ DOLAŞ. MODÜLLER ÜZERİNDEKİ DEPENDENCYLERİ SERVICECOLLECTİONA EKLE.
                module.Load(serviceCollection);
            }

            return ServiceTool.Create(serviceCollection);
        }

    }
}