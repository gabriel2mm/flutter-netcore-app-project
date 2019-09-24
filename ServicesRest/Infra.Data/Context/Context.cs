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

        public DbSet<User> Users { get; set; }
        public DbSet<Organization> Organizations { get; set; }
        public DbSet<Contact> Contacts { get; set; }
    }
}
