using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Configuration;

namespace Spotter.Cloud.Service.Entities
{
    public class RecipeDBContext : DbContext
    {
        static RecipeDBContext()
        {
            Database.SetInitializer<RecipeDBContext>(null);
        }
        public RecipeDBContext()
            : base("Data Source=localhost\SQLEXPRESS;Initial Catalog=SpotterDB;Password=rtecdb; User=sa")
        {
            this.Configuration.LazyLoadingEnabled = true;
            this.Configuration.ProxyCreationEnabled = true;

        }

        public RecipeDBContext(string connectionString)
            : base(connectionString)
        {
            this.Configuration.LazyLoadingEnabled = true;
            this.Configuration.ProxyCreationEnabled = true;
        }

        public DbSet<DriverDetails> DriverDetails { get; set; }
        public DbSet<LocationDetails> LocationDetails { get; set; }
        public DbSet<RouteCheckPoints> RouteCheckPoints { get; set; }
        public DbSet<RouteDetails> RouteDetails { get; set; }
        public DbSet<TripDetails> TripDetails { get; set; }
        public DbSet<VehicleDetails> VehicleDetails { get; set; }
    }
}
