using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ProjectQLVeSo.Models
{
    public partial class QLVeSoContext : DbContext
    {
        public QLVeSoContext()
        {
        }

        public QLVeSoContext(DbContextOptions<QLVeSoContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CongNo> CongNo { get; set; }
        public virtual DbSet<DaiLy> DaiLy { get; set; }
        public virtual DbSet<DangKy> DangKy { get; set; }
        public virtual DbSet<Giai> Giai { get; set; }
        public virtual DbSet<KetQuaXoSo> KetQuaXoSo { get; set; }
        public virtual DbSet<LoaiVeSo> LoaiVeSo { get; set; }
        public virtual DbSet<PhanPhoi> PhanPhoi { get; set; }
        public virtual DbSet<PhieuThu> PhieuThu { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=HEOBAYMAU;Database=QLVeSo;Integrated Security=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CongNo>(entity =>
            {
                entity.HasIndex(e => e.MaCongNo)
                    .HasName("UQ__CongNo__E452A01F861F5B06")
                    .IsUnique();

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.MaCongNo)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Ngay).HasColumnType("datetime");

                entity.HasOne(d => d.IdDaiLyNavigation)
                    .WithMany(p => p.CongNo)
                    .HasForeignKey(d => d.IdDaiLy)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<DaiLy>(entity =>
            {
                entity.HasIndex(e => e.MaDaiLy)
                    .HasName("UQ__DaiLy__069B00B2F0A19C78")
                    .IsUnique();

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.DiaChi).HasMaxLength(200);

                entity.Property(e => e.DienThoai)
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.MaDaiLy)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Ten).HasMaxLength(100);

                entity.Property(e => e.TinhTrang).HasMaxLength(20);
            });

            modelBuilder.Entity<DangKy>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.NgayDangKy).HasColumnType("datetime");

                entity.HasOne(d => d.IdDaiLyNavigation)
                    .WithMany(p => p.DangKy)
                    .HasForeignKey(d => d.IdDaiLy)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.IdLoaiVeSoNavigation)
                    .WithMany(p => p.DangKy)
                    .HasForeignKey(d => d.IdLoaiVeSo)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Giai>(entity =>
            {
                entity.HasIndex(e => e.MaGiai)
                    .HasName("UQ__Giai__747065BF01D2AC26")
                    .IsUnique();

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.MaGiai)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.TenGiai).HasMaxLength(20);
            });

            modelBuilder.Entity<KetQuaXoSo>(entity =>
            {
                entity.HasIndex(e => e.MaKetQua)
                    .HasName("UQ__KetQuaXo__D5B3102BA70F75F9")
                    .IsUnique();

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.MaKetQua)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Ngay).HasColumnType("date");

                entity.Property(e => e.SoTrung)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdGiaiNavigation)
                    .WithMany(p => p.KetQuaXoSo)
                    .HasForeignKey(d => d.IdGiai)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.IdLoaiVeSoNavigation)
                    .WithMany(p => p.KetQuaXoSo)
                    .HasForeignKey(d => d.IdLoaiVeSo)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<LoaiVeSo>(entity =>
            {
                entity.HasIndex(e => e.MaLoaiVeSo)
                    .HasName("UQ__LoaiVeSo__4AFD9B5EC3366021")
                    .IsUnique();

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.MaLoaiVeSo)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Tinh).HasMaxLength(50);

                entity.Property(e => e.TinhTrang).HasMaxLength(20);
            });

            modelBuilder.Entity<PhanPhoi>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Ngay).HasColumnType("date");

                entity.HasOne(d => d.IdDaiLyNavigation)
                    .WithMany(p => p.PhanPhoi)
                    .HasForeignKey(d => d.IdDaiLy)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.IdLoaiVeSoNavigation)
                    .WithMany(p => p.PhanPhoi)
                    .HasForeignKey(d => d.IdLoaiVeSo)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<PhieuThu>(entity =>
            {
                entity.HasIndex(e => e.MaPhieuThu)
                    .HasName("UQ__PhieuThu__1D8B9C6810E88269")
                    .IsUnique();

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.MaPhieuThu)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Ngay).HasColumnType("datetime");

                entity.HasOne(d => d.IdDaiLyNavigation)
                    .WithMany(p => p.PhieuThu)
                    .HasForeignKey(d => d.IdDaiLy)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });
        }
    }
}
