using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity
{
    public class Usuario
    {
        public long ID { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
    }
}
