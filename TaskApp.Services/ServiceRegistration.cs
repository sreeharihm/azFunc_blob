using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TaskApp.Services.Interface;
using TaskApp.Services.Services;

namespace TaskApp.Services
{
    public static class ServiceRegistration
    {
        public static void AddServiceRegistration(this IServiceCollection services)
        {
            services.AddTransient<IBlobService, BlobService>();
            services.AddTransient<ITableService, TableService>();
        }
    }
}
