using CertificateOrderingApp.Models.DataModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CertificateOrderingApp.Services.DatabaseContext
{
    public partial class CertificateOrderingContext : DbContext
    {
        public CertificateOrderingContext()
        {

        }

        public CertificateOrderingContext(DbContextOptions<CertificateOrderingContext> options) : base(options)
        {

        }

        public  DbSet<Certificate> Certificates { get; set; }
        public  DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => 
            optionsBuilder.UseMySql("server=127.0.0.1;database=certificate_ordering;user id=root", Microsoft.EntityFrameworkCore.ServerVersion.Parse("10.4.28-mariadb"));

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("utf8mb4_unicode_520_ci").HasCharSet("utf8mb4");

            modelBuilder.Entity<Certificate>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PRIMARY");
                entity.ToTable("certificates");
                entity.HasIndex(e => e.UserId, "UserId");
                entity.Property(e => e.Id).HasColumnType("int(11)");
                entity.Property(e => e.CertificateName).HasMaxLength(128);
                entity.Property(e => e.Status).HasColumnType("int(11)");
                entity.Property(e => e.UserId).HasColumnType("int(11)");
                entity.HasOne(d => d.User).WithMany(p => p.Certificates).HasForeignKey(d => d.UserId).HasConstraintName("certificates_ibfk_1");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PRIMARY");
                entity.ToTable("users");
                entity.Property(e => e.Id).HasColumnType("int(11)");
                entity.Property(e => e.Email).HasMaxLength(128);
                entity.Property(e => e.Name).HasMaxLength(128);
                entity.Property(e => e.Password).HasMaxLength(128);
                entity.Property(e => e.Role).HasColumnType("int(11)");
            });
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
