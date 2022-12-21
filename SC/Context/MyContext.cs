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

        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }

        public DbSet<ProfileMahasiswa> ProfileMahasiswas { get; set; }
        public DbSet<Keluhan> Keluhans { get; set; }

        public DbSet<Respon> Respons { get; set; }

    }
}
