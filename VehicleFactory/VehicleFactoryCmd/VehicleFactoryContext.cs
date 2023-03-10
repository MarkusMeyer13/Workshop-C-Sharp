using Microsoft.EntityFrameworkCore;
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
            optionsBuilder.UseSqlServer(@"Server=tcp:workshop-csharp.database.windows.net,1433;Initial Catalog=markusm;Persist Security Info=False;User ID=workshop;Password=kveOxZEL!gzSWJoItmex;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
        }
    }
}
