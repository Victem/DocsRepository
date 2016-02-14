using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BicycleAuth
{
    public class BicycleAuthContext : DbContext
    {
        public BicycleAuthContext() : base("UsersStore")
        { }

        public DbSet<User> Users { get; set; }
    }
}
