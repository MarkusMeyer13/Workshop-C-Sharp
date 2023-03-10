using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleFactory;

namespace VehicleFactoryCmd
{
    public class VehicleFactoryContext : DbContext
    {

        public DbSet<Manufacturer> Manufacturer { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            IConfiguration config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();
            var connectionString = config.GetConnectionString("vehicleDb");

            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}
