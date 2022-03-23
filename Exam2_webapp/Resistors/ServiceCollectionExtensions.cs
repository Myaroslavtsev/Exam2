using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Model;
using Model.Resistors;
using MongoDB.Driver;

namespace Exam2_webapp.Resistors
{
    internal static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddResistors(this IServiceCollection services)
        {
            services.AddSingleton(provider =>
            {
                var configuration = provider.GetRequiredService<IConfiguration>();
                var connectionString = configuration["ConnectionString"];
                var client = new MongoClient(connectionString);
                var database = client.GetDatabase("Components");
                var collection = database.GetCollection<Resistor>("Resistors");
                return collection;
            });
            services.AddSingleton<IResistorsRepository, ResistorsRepository>();
            services.AddSingleton<ResistorsService>();

            return services;
        }
    }
}
