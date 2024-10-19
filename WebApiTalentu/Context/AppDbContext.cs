using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiTalentu.Models;

namespace WebApiTalentu.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) 
        {
        
        }

        public DbSet<Users> Users { get; set; }
        public DbSet<Activities> Activities { get; set; }
        public DbSet<Categories> Categories { get; set; }
        public DbSet<Times> Times { get; set; }
    }
}
