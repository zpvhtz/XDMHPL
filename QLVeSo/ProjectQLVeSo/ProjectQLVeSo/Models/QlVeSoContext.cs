using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ProjectQLVeSo.Models
{
    public partial class QlVeSoContext : DbContext
    {
        public QlVeSoContext()
        {
        }

        public QlVeSoContext(DbContextOptions<QlVeSoContext> options)
            : base(options)
        {
        }

        public virtual DbSet<DaiLy> DaiLy { get; set; }
        public virtual DbSet<DangKy> DangKy { get; set; }
        public virtual DbSet<LoaiVeSo> LoaiVeSo { get; set; }
        public virtual DbSet<PhanPhoi> PhanPhoi { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=HEOBAUMAU;Database=QlVeSo;Integrated Security=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DaiLy>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.DiaChi).HasMaxLength(200);

                entity.Property(e => e.DienThoai)
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.Ma)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Ten).HasMaxLength(100);

                entity.Property(e => e.TinhTrang).HasMaxLength(20);
            });

            modelBuilder.Entity<DangKy>(entity =>
            {
                entity.HasKey(e => new { e.IdDaiLy, e.IdVeSo });

                entity.Property(e => e.NgayDangKy).HasColumnType("date");

                entity.HasOne(d => d.IdDaiLyNavigation)
                    .WithMany(p => p.DangKy)
                    .HasForeignKey(d => d.IdDaiLy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DangKy_DaiLy_MaDaiLy");

                entity.HasOne(d => d.IdVeSoNavigation)
                    .WithMany(p => p.DangKy)
                    .HasForeignKey(d => d.IdVeSo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DangKy_LoaiVeSo_MaVeSo");
            });

            modelBuilder.Entity<LoaiVeSo>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Ma)
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
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PhanPhoi_DaiLy_MaDaiLy");

                entity.HasOne(d => d.IdVeSoNavigation)
                    .WithMany(p => p.PhanPhoi)
                    .HasForeignKey(d => d.IdVeSo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PhanPhoi_LoaiVeSo_MaVeSo");
            });
        }
    }
}
