using EConsulting.Model;

using Microsoft.EntityFrameworkCore;

namespace EConsulting.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        { 
            Database.EnsureCreated();
        }

        public DbSet<TimeRangeModel> TimeRangeModels { get; set; }
        public DbSet<LoggingModel> loggingModels { get; set; }
    }
}
