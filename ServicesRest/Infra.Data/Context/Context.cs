using Domain.Entity;
using System.Data.Entity;

namespace Infra.Data.Context
{
    class Context : DbContext
    {
        public Context() : base("ConnDB")
        {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Organization> Organizations { get; set; }
        public DbSet<Contact> Contacts { get; set; }
    }
}
