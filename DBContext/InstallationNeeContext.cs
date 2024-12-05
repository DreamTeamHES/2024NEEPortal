using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using DBContext.Models;

namespace DBContext;

public partial class InstallationNeeContext : DbContext
{
    public InstallationNeeContext()
    {
    }

    public InstallationNeeContext(DbContextOptions<InstallationNeeContext> options)
        : base(options)
    {
    }

    public virtual DbSet<ElectricityProductionPlant> ElectricityProductionPlants { get; set; }

    public virtual DbSet<MainCategoryCatalogue> MainCategoryCatalogues { get; set; }

    public virtual DbSet<PlantCategoryCatalogue> PlantCategoryCatalogues { get; set; }

    public virtual DbSet<SubCategoryCatalogue> SubCategoryCatalogues { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=tcp:2024nee.database.windows.net,1433;Initial Catalog=InstallationNEE;Persist Security Info=False;User ID=neeserver;Password=AdminHevs01;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ElectricityProductionPlant>(entity =>
        {
            entity.HasKey(e => e.XtfId).HasName("PK__Electric__3037340A6B2A071D");

            entity.ToTable("ElectricityProductionPlant");

            entity.Property(e => e.XtfId)
                .ValueGeneratedNever()
                .HasColumnName("xtf_id");
            entity.Property(e => e.Address).HasMaxLength(255);
            entity.Property(e => e.Canton).HasMaxLength(10);
            entity.Property(e => e.MainCategory).HasMaxLength(50);
            entity.Property(e => e.Municipality).HasMaxLength(255);
            entity.Property(e => e.PlantCategory).HasMaxLength(50);
            entity.Property(e => e.SubCategory).HasMaxLength(50);
            entity.Property(e => e.X).HasColumnName("x");
            entity.Property(e => e.Y).HasColumnName("y");

            entity.HasOne(d => d.MainCategoryNavigation).WithMany(p => p.ElectricityProductionPlants)
                .HasForeignKey(d => d.MainCategory)
                .HasConstraintName("FK_ElectricityProductionPlant_MainCategory");

            entity.HasOne(d => d.PlantCategoryNavigation).WithMany(p => p.ElectricityProductionPlants)
                .HasForeignKey(d => d.PlantCategory)
                .HasConstraintName("FK_ElectricityProductionPlant_PlantCategory");

            entity.HasOne(d => d.SubCategoryNavigation).WithMany(p => p.ElectricityProductionPlants)
                .HasForeignKey(d => d.SubCategory)
                .HasConstraintName("FK_ElectricityProductionPlant_SubCategory");
        });

        modelBuilder.Entity<MainCategoryCatalogue>(entity =>
        {
            entity.HasKey(e => e.CatalogueId).HasName("PK__MainCate__D52462683FEE06F1");

            entity.ToTable("MainCategoryCatalogue");

            entity.Property(e => e.CatalogueId)
                .HasMaxLength(50)
                .HasColumnName("Catalogue_id");
            entity.Property(e => e.De)
                .HasMaxLength(255)
                .HasColumnName("de");
            entity.Property(e => e.En)
                .HasMaxLength(255)
                .HasColumnName("en");
            entity.Property(e => e.Fr)
                .HasMaxLength(255)
                .HasColumnName("fr");
            entity.Property(e => e.It)
                .HasMaxLength(255)
                .HasColumnName("it");
        });

        modelBuilder.Entity<PlantCategoryCatalogue>(entity =>
        {
            entity.HasKey(e => e.CatalogueId).HasName("PK__PlantCat__D5246268D0F71B4E");

            entity.ToTable("PlantCategoryCatalogue");

            entity.Property(e => e.CatalogueId)
                .HasMaxLength(50)
                .HasColumnName("Catalogue_id");
            entity.Property(e => e.De)
                .HasMaxLength(255)
                .HasColumnName("de");
            entity.Property(e => e.En)
                .HasMaxLength(255)
                .HasColumnName("en");
            entity.Property(e => e.Fr)
                .HasMaxLength(255)
                .HasColumnName("fr");
            entity.Property(e => e.It)
                .HasMaxLength(255)
                .HasColumnName("it");
        });

        modelBuilder.Entity<SubCategoryCatalogue>(entity =>
        {
            entity.HasKey(e => e.CatalogueId).HasName("PK__SubCateg__D524626817534F8D");

            entity.ToTable("SubCategoryCatalogue");

            entity.Property(e => e.CatalogueId)
                .HasMaxLength(50)
                .HasColumnName("Catalogue_id");
            entity.Property(e => e.De)
                .HasMaxLength(255)
                .HasColumnName("de");
            entity.Property(e => e.En)
                .HasMaxLength(255)
                .HasColumnName("en");
            entity.Property(e => e.Fr)
                .HasMaxLength(255)
                .HasColumnName("fr");
            entity.Property(e => e.It)
                .HasMaxLength(255)
                .HasColumnName("it");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
