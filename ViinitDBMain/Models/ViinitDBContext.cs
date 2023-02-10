using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ViinitDBMain.Models
{
    public partial class ViinitDBContext : DbContext
    {
        public ViinitDBContext()
        {
        }

        public ViinitDBContext(DbContextOptions<ViinitDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Viinit> Viinits { get; set; } = null!;
        public virtual DbSet<Viinityypit> Viinityypits { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=tcp:vinea.database.windows.net,1433;Initial Catalog=ViinitDB;Persist Security Info=False;User ID=amila;Password=Ominous787;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Viinit>(entity =>
            {
                entity.HasKey(e => e.ViiniId);

                entity.ToTable("Viinit");

                entity.Property(e => e.ViiniId).HasColumnName("ViiniID");

                entity.Property(e => e.Hinta).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.Kommentit).HasMaxLength(200);

                entity.Property(e => e.Nimi).HasMaxLength(50);

                entity.Property(e => e.TyyppiId).HasColumnName("TyyppiID");

                entity.HasOne(d => d.Tyyppi)
                    .WithMany(p => p.Viinits)
                    .HasForeignKey(d => d.TyyppiId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Viinit_Viinityypit");
            });

            modelBuilder.Entity<Viinityypit>(entity =>
            {
                entity.HasKey(e => e.TyyppiId);

                entity.ToTable("Viinityypit");

                entity.Property(e => e.TyyppiId).HasColumnName("TyyppiID");

                entity.Property(e => e.Viinityyppi).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
