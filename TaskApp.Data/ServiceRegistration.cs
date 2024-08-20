using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TaskApp.Data.Interface;
using TaskApp.Data.Model;
using TaskApp.Data.Repository;

namespace TaskApp.Data
{
    public static class ServiceRegistration
    {
        public static void AddDataRegistration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<TaskDbContext>(opt => opt.UseSqlServer(configuration.GetConnectionString("TaskDbConnection")));
            services.AddScoped<ICityRepository, CityRepository>();
            //services.AddSingleton(provider => new TaskDbContext(configuration.GetConnectionString("TaskDbConnection")));
        }
    }
}