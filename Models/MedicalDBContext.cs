using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace MedicineService.Models
{
    public partial class MedicalDBContext : DbContext
    {
        public MedicalDBContext()
        {
        }

        public MedicalDBContext(DbContextOptions<MedicalDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Medicine> Medicines { get; set; }
        public virtual DbSet<StoredMedicine> StoredMedicines { get; set; }
        public virtual DbSet<Vendor> Vendors { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=MedicalDB;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<StoredMedicine>(entity =>
            {
                entity.HasKey(e => new { e.BatchNo, e.MedicineId });

                entity.HasIndex(e => e.MedicineId, "IX_StoredMedicines_MedicineId");

                entity.HasIndex(e => e.VendorId, "IX_StoredMedicines_VendorId");

                entity.HasOne(d => d.Medicine)
                    .WithMany(p => p.StoredMedicines)
                    .HasForeignKey(d => d.MedicineId);

                entity.HasOne(d => d.Vendor)
                    .WithMany(p => p.StoredMedicines)
                    .HasForeignKey(d => d.VendorId);
            });

            modelBuilder.Entity<Vendor>(entity =>
            {
                entity.Property(e => e.Address).IsRequired();

                entity.Property(e => e.City).IsRequired();

                entity.Property(e => e.EmailId).IsRequired();

                entity.Property(e => e.Name).IsRequired();
            });

          

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
