using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete
{
    public class Context : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=LAPTOP-7F45BKQF;Initial Catalog=KutuphaneDB; integrated security=false;TrustServerCertificate=true; Trusted_Connection=true;");
        }

        public DbSet<Personnel> Personnel { get; set; }
        public DbSet<Books> Books { get; set; }
        public DbSet<Status> Status { get; set; }
        public DbSet<Users> Users { get; set; }
    }
}
