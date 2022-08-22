using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace AnimalSheltersAPI.Models
{
    public partial class animalshelterdbContext : DbContext
    {
        public animalshelterdbContext()
        {
        }

        public animalshelterdbContext(DbContextOptions<animalshelterdbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Animal> Animals { get; set; } = null!;
        public virtual DbSet<Shelter> Shelters { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=.;Database=animalshelterdb;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Animal>(entity =>
            {
                entity.ToTable("ANIMAL");

                entity.Property(e => e.AnimalId).HasColumnName("animalID");

                entity.Property(e => e.Age)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("age");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.Property(e => e.Race)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("race");

                entity.Property(e => e.Sex)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("sex");

                entity.Property(e => e.ShelterId).HasColumnName("shelterId");

                entity.Property(e => e.Specie)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("specie");

                entity.Property(e => e.State)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("state");

                entity.HasOne(d => d.Shelter)
                    .WithMany(p => p.Animals)
                    .HasForeignKey(d => d.ShelterId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ANIMAL_SHELTER");
            });

            modelBuilder.Entity<Shelter>(entity =>
            {
                entity.ToTable("SHELTER");

                entity.Property(e => e.ShelterId).HasColumnName("shelterID");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.Property(e => e.Owner)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("owner");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
