using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace PropertyWebManager.Models.PropertyModels
{
    public class PropertiesEntities : DbContext
    {
        public PropertiesEntities()
            : base("name=PropertiesEntities")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }

        public DbSet<Property> Properties { get; set; }
        public DbSet<PropertyPhoto> PropertiesPhotos { get; set; }
        public DbSet<PropertyType> PropertiesTypes { get; set; }
        public DbSet<TransactionType> TransactionTypes { get; set; }
        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<WebPagesRoles> WebPagesRoles { get; set; }
        public DbSet<WebPagesOAuthMembership> WebPagesOAuthMemberships { get; set; }
        public DbSet<WebPagesMembership> WebPagesMemberships { get; set; }
    }
}