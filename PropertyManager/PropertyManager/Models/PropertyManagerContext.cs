using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using PropertyManager.Models.PropertyModels;

namespace PropertyManager.Models
{
  

    public class PropertyManagerContext : IdentityDbContext
    {
        public PropertyManagerContext()
            : base("DefaultConnection")
        {
        }

        public static PropertyManagerContext Create()
        {
            return new PropertyManagerContext();
        }

        public DbSet<Property> Properties { get; set; }
        public DbSet<PropertyPhoto> PropertyPhotos { get; set; }
        public DbSet<PropertyType> PropertyTypes { get; set; }
        public DbSet<TransactionType> TransactionTypes { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        }
    }
}