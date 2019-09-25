using Domain.Entity;
using System.Data.Entity;

namespace Infra.Data.Context
{
    public class Context : DbContext
    {
        public Context() : base("ConnDB")
        {
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer<Context>(null);
            base.OnModelCreating(modelBuilder);
        }

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Organization> Organizations { get; set; }
        public virtual DbSet<Contact> Contacts { get; set; }
        public virtual DbSet<Model> Models { get; set; }
        public virtual DbSet<Brand> Brands { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
    }
}
