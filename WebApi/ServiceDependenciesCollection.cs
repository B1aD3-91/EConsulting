
using EConsulting.Repository;

using EConsulting.Data;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using EConsulting.Service;
using Microsoft.Extensions.Configuration;

namespace EConsulting
{
    public static class ServiceDependenciesCollection
    {
        public static void AddDomainServiceCollection(this IServiceCollection collection, IConfiguration configuration)
        {
            var connectioString = configuration.GetConnectionString("MSDBConnection");
            collection.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(connectioString);
               // options.UseInMemoryDatabase("InMem");
            });
            collection.AddScoped<IRepository, RepositoryImpl>();
            collection.AddScoped<ITimeRangeService, TimeRangeServiceImpl>();
            collection.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        }
    }
}
