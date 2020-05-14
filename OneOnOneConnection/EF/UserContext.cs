using EF.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF
{
    public class UserContext : DbContext
    {
        public UserContext() : base("name=UserConnection")
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<UserData> UsersData { get; set; }
    }
}
