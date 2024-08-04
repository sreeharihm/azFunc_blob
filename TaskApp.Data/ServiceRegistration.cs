using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskApp.Data.Model;

namespace TaskApp.Data
{
    public static class ServiceRegistration
    {
        public static void AddDataRegistration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<TaskAppContext>(opt => opt.UseSqlServer(configuration.GetConnectionString("TaskDbConnection")));
        }
    }
}