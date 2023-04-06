using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using BeSpokeApp.Repository.Models;

namespace BeSpokeApp.Repository
{
    public partial class BespokeDbContext : DbContext
    {
        public BespokeDbContext()
        {
        }

        public BespokeDbContext(DbContextOptions<BespokeDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Customer> Customers { get; set; } = null!;
        public virtual DbSet<Discount> Discounts { get; set; } = null!;
        public virtual DbSet<Product> Products { get; set; } = null!;
        public virtual DbSet<Sale> Sales { get; set; } = null!;
        public virtual DbSet<Salesperson> SalesPerson { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Name=BeSpokeConnString");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>(entity =>
            {
                entity.Property(e => e.CustomerId).ValueGeneratedNever();
            });

            modelBuilder.Entity<Discount>(entity =>
            {
                entity.Property(e => e.DiscountId).ValueGeneratedNever();

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.Discounts)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Discount__Produc__66603565");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.Property(e => e.ProductId).ValueGeneratedNever();
            });

            modelBuilder.Entity<Sale>(entity =>
            {
                entity.HasOne(d => d.Customer)
                    .WithMany()
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Sales__CustomerI__6383C8BA");

                entity.HasOne(d => d.Product)
                    .WithMany()
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Sales__ProductId__619B8048");

                entity.HasOne(d => d.SalesPerson)
                    .WithMany()
                    .HasForeignKey(d => d.SalesPersonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Sales__SalesPers__628FA481");
            });

            modelBuilder.Entity<Salesperson>(entity =>
            {
                entity.Property(e => e.SalesPersonId).ValueGeneratedNever();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
