using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace management_system.Entities.DataModels;

public partial class AppDbContext : DbContext
{
    public AppDbContext()
    {
    }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Brand> Brands { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UserType> UserTypes { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Brand>(entity =>
        {
            entity.HasKey(e => e.BrandId).HasName("Brand_pkey");

            entity.ToTable("Brand", "management_system");

            entity.Property(e => e.BrandId).UseIdentityAlwaysColumn();
            entity.Property(e => e.Name).HasMaxLength(200);
            entity.Property(e => e.ShortName).HasMaxLength(50);
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.ProductId).HasName("Product_pkey");

            entity.ToTable("Product", "management_system");

            entity.Property(e => e.ProductId).UseIdentityAlwaysColumn();
            entity.Property(e => e.ProductName).HasMaxLength(200);
            entity.Property(e => e.RackNumber).HasMaxLength(200);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PrimaryKey");

            entity.ToTable("User", "management_system");

            entity.Property(e => e.UserId).UseIdentityAlwaysColumn();
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.FirstName).HasMaxLength(200);
            entity.Property(e => e.LastName).HasMaxLength(200);
            entity.Property(e => e.Number).HasMaxLength(11);

            entity.HasOne(d => d.UserType).WithMany(p => p.Users)
                .HasForeignKey(d => d.UserTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("UserTypeFK");
        });

        modelBuilder.Entity<UserType>(entity =>
        {
            entity.HasKey(e => e.UserTypeId).HasName("UserTypePrimaryKey");

            entity.ToTable("UserType", "management_system");

            entity.Property(e => e.UserTypeId).ValueGeneratedNever();
            entity.Property(e => e.Type).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
