using Microsoft.EntityFrameworkCore;
using System;

namespace WebApiApp.Data
{
    public class MyDBContext :DbContext
    {
        public MyDBContext(DbContextOptions options) : base(options) { }

        #region DbSet 
        public DbSet<HangHoa> HangHoas { get; set; }
        public DbSet<LoaiHH> LoaiHHs { get; set; }
        public DbSet<DonHang> DonHangs { get; set; }
        public DbSet<DonHangChiTiet> DonHangChiTiets { get; set; }
        #endregion
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Fluent
            modelBuilder.Entity<DonHang>(e =>
            {
                e.ToTable("DonHang");
                e.HasKey(dh => dh.MaDonHang);
                e.Property(dh => dh.NgayDat).HasDefaultValueSql("GETUTCDATE()");
                e.Property(it => it.NguoiNhanHang).IsRequired().HasMaxLength(100);
            });
            modelBuilder.Entity<DonHangChiTiet>(e =>
            {
                e.ToTable("DonHangChiTiet");
                e.HasKey(it => new { it.MaHH, it.MaDonHang });
                e.HasOne(it => it.DonHang).WithMany(it => it.DonHangChiTiets)
                .HasForeignKey(it => it.MaDonHang)
                .HasConstraintName("FK_DonHangChiTiet_DonHang");

                e.HasOne(it => it.HangHoa).WithMany(it => it.DonHangChiTiets)
               .HasForeignKey(it => it.MaHH)
               .HasConstraintName("FK_DonHangChiTiet_HangHoa");
            });
        }
    }
}
