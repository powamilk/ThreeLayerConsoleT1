using Microsoft.EntityFrameworkCore;
using ThreeLayerConsoleT1.DAL.Entities;

namespace ThreeLayerConsoleT1.DAL
{
    public partial class AppDbContext : DbContext
    {
        public AppDbContext()
        {
        }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<BuoiTroGiang> BuoiTroGiangs { get; set; } = null!;
        public virtual DbSet<GiangVien> GiangViens { get; set; } = null!;
        public virtual DbSet<MonHoc> MonHocs { get; set; } = null!;
        public virtual DbSet<TroGiang> TroGiangs { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=POWWA;Database=ThreeLayerDB_1;Trusted_Connection=True;TrustServerCertificate=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BuoiTroGiang>(entity =>
            {
                entity.HasKey(e => e.MaBtg)
                    .HasName("PK__BuoiTroG__3520F5FB3066A02C");

                entity.ToTable("BuoiTroGiang");

                entity.Property(e => e.MaBtg)
                    .ValueGeneratedNever()
                    .HasColumnName("MaBTG");

                entity.Property(e => e.MaMh).HasColumnName("MaMH");

                entity.Property(e => e.MaTg).HasColumnName("MaTG");

                entity.HasOne(d => d.MaMhNavigation)
                    .WithMany(p => p.BuoiTroGiangs)
                    .HasForeignKey(d => d.MaMh)
                    .HasConstraintName("FK__BuoiTroGia__MaMH__3E52440B");

                entity.HasOne(d => d.MaTgNavigation)
                    .WithMany(p => p.BuoiTroGiangs)
                    .HasForeignKey(d => d.MaTg)
                    .HasConstraintName("FK__BuoiTroGia__MaTG__3F466844");
            });

            modelBuilder.Entity<GiangVien>(entity =>
            {
                entity.HasKey(e => e.MaGv)
                    .HasName("PK__GiangVie__2725AEF3D59F5749");

                entity.ToTable("GiangVien");

                entity.Property(e => e.MaGv)
                    .ValueGeneratedNever()
                    .HasColumnName("MaGV");

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.SoDienThoai)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.TenGv)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("TenGV");
            });

            modelBuilder.Entity<MonHoc>(entity =>
            {
                entity.HasKey(e => e.MaMh)
                    .HasName("PK__MonHoc__2725DFD9372CAC8F");

                entity.ToTable("MonHoc");

                entity.Property(e => e.MaMh)
                    .ValueGeneratedNever()
                    .HasColumnName("MaMH");

                entity.Property(e => e.MaGv).HasColumnName("MaGV");

                entity.Property(e => e.TenMh)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("TenMH");

                entity.HasOne(d => d.MaGvNavigation)
                    .WithMany(p => p.MonHocs)
                    .HasForeignKey(d => d.MaGv)
                    .HasConstraintName("FK__MonHoc__MaGV__398D8EEE");
            });

            modelBuilder.Entity<TroGiang>(entity =>
            {
                entity.HasKey(e => e.MaTg)
                    .HasName("PK__TroGiang__2725007458945165");

                entity.ToTable("TroGiang");

                entity.Property(e => e.MaTg)
                    .ValueGeneratedNever()
                    .HasColumnName("MaTG");

                entity.Property(e => e.DiaChi)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.NgaySinh).HasColumnType("date");

                entity.Property(e => e.TenTg)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("TenTG");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
