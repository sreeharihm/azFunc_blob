using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskApp.Data.Model
{
    public class TaskAppContext : DbContext
    {
        public TaskAppContext(DbContextOptions options) : base(options)
        {            
        }

        public DbSet<City> Cities { get; set; }
    }
}
