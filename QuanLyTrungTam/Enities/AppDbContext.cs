using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyTrungTam.Enities
{
    public class AppDbContext : DbContext
    {
        public DbSet<HocSinh> HocSinhs { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(@"Data Source=.;Initial Catalog=QuanLyHocVien;Integrated Security=True;TrustServerCertificate=True;");
        }
    }
}
