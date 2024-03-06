using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCSBO
{
    public class HCStoreManagementContext : DbContext
    {
        public HCStoreManagementContext()
        {
            
        }

        public HCStoreManagementContext(DbContextOptions<HCStoreManagementContext> options)
            : base(options) 
        {
            
        }

        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Handicraft> Handicrafts { get; set;}
        public virtual DbSet<HandicraftCategory> HandicraftCategories { get; set;}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if(!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(GetConnectionString());
            }
        }

        private string GetConnectionString()
        {
            IConfiguration config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", true, true)
                .Build();

            var conStr = config.GetConnectionString("HCStore");
            return conStr;
        }
    }
}
