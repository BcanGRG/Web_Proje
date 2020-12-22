using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web_Proje.Models
{
    public class Context : DbContext
    {
       protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server = .\\SQLEXPRESS; database = DbProje ; integrated security = true");
        }
        public DbSet <Food> Foods { get; set; }
        public DbSet <Category> Categories { get; set; }
    }

}
