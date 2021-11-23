using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace UCP1_PAW_043_C.Models
{
    public partial class UCPCatatanContext : DbContext
    {
        public UCPCatatanContext()
        {
        }

        public UCPCatatanContext(DbContextOptions<UCPCatatanContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Admin> Admin { get; set; }
        public virtual DbSet<Catatan> Catatan { get; set; }
        public virtual DbSet<KategoriCatatan> KategoriCatatan { get; set; }
        public virtual DbSet<Laporan> Laporan { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Admin>(entity =>
            {
                entity.HasKey(e => e.IdAdmin);

                entity.Property(e => e.IdAdmin)
                    .HasColumnName("ID_Admin")
                    .ValueGeneratedNever();

                entity.Property(e => e.NamaAdmin)
                    .HasColumnName("Nama_Admin")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PasswordAdmin)
                    .HasColumnName("Password_Admin")
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Catatan>(entity =>
            {
                entity.HasKey(e => e.IdCat);

                entity.Property(e => e.IdCat)
                    .HasColumnName("ID_Cat")
                    .ValueGeneratedNever();

                entity.Property(e => e.HargaCat).HasColumnName("Harga_Cat");

                entity.Property(e => e.IdKategori).HasColumnName("ID_Kategori");

                entity.Property(e => e.KeteranganCat)
                    .HasColumnName("Keterangan_Cat")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Tanggal).HasColumnType("datetime");

                entity.HasOne(d => d.IdKategoriNavigation)
                    .WithMany(p => p.Catatan)
                    .HasForeignKey(d => d.IdKategori)
                    .HasConstraintName("FK_Catatan_Kategori_Catatan");
            });

            modelBuilder.Entity<KategoriCatatan>(entity =>
            {
                entity.HasKey(e => e.IdKategori);

                entity.ToTable("Kategori_Catatan");

                entity.Property(e => e.IdKategori)
                    .HasColumnName("ID_Kategori")
                    .ValueGeneratedNever();

                entity.Property(e => e.NamaKategori)
                    .HasColumnName("Nama_Kategori")
                    .HasMaxLength(15)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Laporan>(entity =>
            {
                entity.HasKey(e => e.IdLaporan);

                entity.Property(e => e.IdLaporan)
                    .HasColumnName("ID_Laporan")
                    .ValueGeneratedNever();

                entity.Property(e => e.IdAdmin).HasColumnName("ID_Admin");

                entity.Property(e => e.IdCat).HasColumnName("ID_Cat");

                entity.Property(e => e.TotalPem).HasColumnName("Total_Pem");

                entity.Property(e => e.TotalPen).HasColumnName("Total_Pen");

                entity.HasOne(d => d.IdAdminNavigation)
                    .WithMany(p => p.Laporan)
                    .HasForeignKey(d => d.IdAdmin)
                    .HasConstraintName("FK_Laporan_Admin");

                entity.HasOne(d => d.IdCatNavigation)
                    .WithMany(p => p.Laporan)
                    .HasForeignKey(d => d.IdCat)
                    .HasConstraintName("FK_Laporan_Catatan");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
