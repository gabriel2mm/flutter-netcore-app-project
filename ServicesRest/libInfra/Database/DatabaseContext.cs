using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Text;

namespace libInfra.Database
{
    class DatabaseContext : DbContext
    {
        public DatabaseContext() : base("")
        {

        }
    }
}
