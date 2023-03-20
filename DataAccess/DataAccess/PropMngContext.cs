using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.DataAccess;

public partial class PropMngContext : DbContext
{
    public PropMngContext()
    {
    }

    public PropMngContext(DbContextOptions<PropMngContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Feature> Features { get; set; }

    public virtual DbSet<Landlord> Landlords { get; set; }

    public virtual DbSet<PriceHistory> PriceHistories { get; set; }

    public virtual DbSet<Property> Properties { get; set; }

    public virtual DbSet<PropertyOwner> PropertyOwners { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=DESKTOP-PB8AOLR\\VANKA;Initial Catalog=PropMNG;TrustServerCertificate=True;Persist Security Info=True;User ID=sa;Password=vanka");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Feature>(entity =>
        {
            entity.HasKey(e => e.FeatureId).HasName("PK__Feature__82230BC9A8B491D9");

            entity.ToTable("Feature");

            entity.Property(e => e.FeatureDescription)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasOne(d => d.Property).WithMany(p => p.Features)
                .HasForeignKey(d => d.PropertyId)
                .HasConstraintName("FK__Feature__Propert__2C3393D0");
        });

        modelBuilder.Entity<Landlord>(entity =>
        {
            entity.HasKey(e => e.LandlordId).HasName("PK__Landlord__8EC79DA30BBB088E");

            entity.ToTable("Landlord");

            entity.Property(e => e.CitizenId)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.Location)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Tel)
                .HasMaxLength(15)
                .IsUnicode(false);
        });

        modelBuilder.Entity<PriceHistory>(entity =>
        {
            entity.HasKey(e => e.PriceId).HasName("PK__PriceHis__49575BAF450DBF78");

            entity.ToTable("PriceHistory");

            entity.Property(e => e.Amount).HasColumnType("money");
            entity.Property(e => e.Date).HasColumnType("datetime");

            entity.HasOne(d => d.Property).WithMany(p => p.PriceHistories)
                .HasForeignKey(d => d.PropertyId)
                .HasConstraintName("FK__PriceHist__Prope__31EC6D26");
        });

        modelBuilder.Entity<Property>(entity =>
        {
            entity.HasKey(e => e.PropertyId).HasName("PK__Property__70C9A7351976601D");

            entity.ToTable("Property");

            entity.Property(e => e.Available)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.Contact)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Location)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Price).HasColumnType("money");
        });

        modelBuilder.Entity<PropertyOwner>(entity =>
        {
            entity.HasKey(e => e.OwnId).HasName("PK__Property__7DD388758532683D");

            entity.ToTable("PropertyOwner");

            entity.Property(e => e.OwnEndDate).HasColumnType("datetime");
            entity.Property(e => e.OwnStartDate).HasColumnType("datetime");

            entity.HasOne(d => d.Landlord).WithMany(p => p.PropertyOwners)
                .HasForeignKey(d => d.LandlordId)
                .HasConstraintName("FK__PropertyO__Landl__29572725");

            entity.HasOne(d => d.Property).WithMany(p => p.PropertyOwners)
                .HasForeignKey(d => d.PropertyId)
                .HasConstraintName("FK__PropertyO__Prope__286302EC");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
