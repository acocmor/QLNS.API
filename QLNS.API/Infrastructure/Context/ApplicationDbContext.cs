using Microsoft.EntityFrameworkCore;
using QLNS.Domain.Entities;

namespace QLNS.Infrastructure.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<NhanVien> NhanViens { get; set; }
        public DbSet<QueQuan> QueQuans { get; set; }
        public DbSet<PhongBan> PhongBans { get; set; }
        public DbSet<ChucVu> ChucVus { get; set; }
        public DbSet<HopDongLaoDong> HopDongLaoDongs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ChucVu>()
                .HasMany(p => p.DanhSachNhanVien)
                .WithOne(t => t.ChucVu)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<PhongBan>()
                .HasMany(p => p.DanhSachNhanVien)
                .WithOne(t => t.PhongBan)
                .OnDelete(DeleteBehavior.SetNull);
        }

    }
}
