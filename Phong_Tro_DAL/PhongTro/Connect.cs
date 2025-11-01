using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Phong_Tro_DAL.Phong_Tro
{
    public partial class Connect : DbContext
    {
        public Connect()
            : base("name=Connect")
        {
        }

        public virtual DbSet<ChiTietHoaDon> ChiTietHoaDons { get; set; }
        public virtual DbSet<ChiTietTienIch> ChiTietTienIches { get; set; }
        public virtual DbSet<ChuTro> ChuTro{ get; set; }
        public virtual DbSet<DichVu> DichVus { get; set; }
        public virtual DbSet<HoaDon> HoaDons { get; set; }
        public virtual DbSet<HopDong> HopDongs { get; set; }
        public virtual DbSet<KhachThue> KhachThues { get; set; }
        public virtual DbSet<Phong> Phongs { get; set; }
        public virtual DbSet<TaiKhoan> TaiKhoans { get; set; }
        public virtual DbSet<ThongBao> ThongBaos { get; set; }
        public virtual DbSet<TienIch> TienIches { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ChiTietHoaDon>()
                .Property(e => e.MaHD)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<ChiTietHoaDon>()
                .Property(e => e.MaDV)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<ChiTietTienIch>()
                .Property(e => e.MaPhong)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<ChiTietTienIch>()
                .Property(e => e.Gia)
                .HasPrecision(12, 2);

            modelBuilder.Entity<ChuTro>()
                .HasMany(e => e.Phongs)
                .WithRequired(e => e.ChuNha)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DichVu>()
                .Property(e => e.MaDV)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<DichVu>()
                .HasMany(e => e.ChiTietHoaDons)
                .WithRequired(e => e.DichVu)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<HoaDon>()
                .Property(e => e.MaHD)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<HoaDon>()
                .HasMany(e => e.ChiTietHoaDons)
                .WithRequired(e => e.HoaDon)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<HopDong>()
                .Property(e => e.MaPhong)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<HopDong>()
                .Property(e => e.TienCoc)
                .HasPrecision(12, 2);

            modelBuilder.Entity<HopDong>()
                .Property(e => e.TienThue)
                .HasPrecision(12, 2);

            modelBuilder.Entity<HopDong>()
                .HasMany(e => e.HoaDons)
                .WithRequired(e => e.HopDong)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<KhachThue>()
                .HasMany(e => e.HopDongs)
                .WithRequired(e => e.KhachThue)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Phong>()
                .Property(e => e.MaPhong)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Phong>()
                .Property(e => e.GiaThue)
                .HasPrecision(12, 2);

            modelBuilder.Entity<Phong>()
                .HasMany(e => e.ChiTietTienIches)
                .WithRequired(e => e.Phong)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Phong>()
                .HasMany(e => e.HopDongs)
                .WithRequired(e => e.Phong)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ThongBao>()
                .Property(e => e.MaPhong)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<TienIch>()
                .Property(e => e.DonGia)
                .HasPrecision(12, 2);

            modelBuilder.Entity<TienIch>()
                .HasMany(e => e.ChiTietTienIches)
                .WithRequired(e => e.TienIch)
                .WillCascadeOnDelete(false);
        }
    }
}
