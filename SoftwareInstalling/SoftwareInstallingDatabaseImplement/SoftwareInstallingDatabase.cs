using Microsoft.EntityFrameworkCore;
using SoftwareInstallingDatabaseImplement.Models;

namespace SoftwareInstallingDatabaseImplement
{
    public class SoftwareInstallingDatabase : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured == false)
            {
                optionsBuilder.UseSqlServer(@"Data Source=LAPTOP-8LRKNM5V;Initial Catalog= SoftwareInstallingDatabase;Integrated Security=True;MultipleActiveResultSets=True;");
            }
            base.OnConfiguring(optionsBuilder);
        }
        public virtual DbSet<Component> Components { set; get; }

        public virtual DbSet<Package> Packages { set; get; }

        public virtual DbSet<PackageComponent> PackageComponents { set; get; }

        public virtual DbSet<Order> Orders { set; get; }

        public virtual DbSet<Client> Clients { set; get; }
    }
}
