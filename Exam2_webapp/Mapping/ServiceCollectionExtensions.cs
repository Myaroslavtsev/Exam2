using AutoMapper;
using Microsoft.Extensions.DependencyInjection;

namespace Exam2_webapp.Mapping
{
    internal static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddMapping(this IServiceCollection services)
        {
            var mappingConfig = new MapperConfiguration(it => it.AddProfile(new MappingProfile()));
            services.AddSingleton(mappingConfig.CreateMapper());

            return services;
        }
    }
}
