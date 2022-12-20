using Microsoft.EntityFrameworkCore;
using SC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SC.Context
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions<MyContext> dbContext) : base(dbContext)
        {

        }
        public DbSet<Campus> Campuses { get; set; }
        
        public DbSet<Keluhan> Keluhans { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<ResponKeluhan> ResponKeluhans { get; set; }

    }
}
