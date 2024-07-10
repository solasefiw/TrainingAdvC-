using LINQ.Model;
using Microsoft.EntityFrameworkCore;

namespace LINQ.DBContext
{
    public class SMSDBContext : DbContext
    {
        public SMSDBContext(DbContextOptions<SMSDBContext> options) : base(options)
        {
        }
        public DbSet<Shareholders> Shareholders { get; set; }
        public DbSet<Subscriptions> Subscriptions { get; set; }
        public DbSet<Parvalues> Parvalues { get; set; }
    }
}
