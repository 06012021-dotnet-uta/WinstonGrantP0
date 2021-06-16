using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace DataBase
{
    public partial class P0Context : DbContext
    {
        public P0Context()
        {
        }

        public P0Context(DbContextOptions<P0Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<CustomerOrder> CustomerOrders { get; set; }
        public virtual DbSet<Inventory> Inventories { get; set; }
        public virtual DbSet<OrderedProduct> OrderedProducts { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<StoreLocation> StoreLocations { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=P0;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.ToTable("Customer");

                entity.HasIndex(e => e.CustomerId, "UQ__Customer__A4AE64B91DA768CA")
                    .IsUnique();

                entity.Property(e => e.CustomerId).HasColumnName("CustomerID");

                entity.Property(e => e.Fname)
                    .HasMaxLength(20)
                    .HasColumnName("FName");

                entity.Property(e => e.Lname)
                    .HasMaxLength(20)
                    .HasColumnName("LName");

                entity.HasOne(d => d.DefaultStoreNavigation)
                    .WithMany(p => p.Customers)
                    .HasForeignKey(d => d.DefaultStore)
                    .HasConstraintName("FK__Customer__Defaul__01142BA1");
            });

            modelBuilder.Entity<CustomerOrder>(entity =>
            {
                entity.ToTable("CustomerOrder");

                entity.HasIndex(e => e.CustomerOrderId, "UQ__Customer__28FBA0DDCC5B63C8")
                    .IsUnique();

                entity.Property(e => e.CustomerOrderId).HasColumnName("CustomerOrderID");

                entity.Property(e => e.CustomerId).HasColumnName("CustomerID");

                entity.Property(e => e.CustomerOrdertime).HasColumnType("date");

                entity.Property(e => e.LocationId).HasColumnName("LocationID");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.CustomerOrders)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK__CustomerO__Custo__6383C8BA");

                entity.HasOne(d => d.Location)
                    .WithMany(p => p.CustomerOrders)
                    .HasForeignKey(d => d.LocationId)
                    .HasConstraintName("FK__CustomerO__Locat__6477ECF3");
            });

            modelBuilder.Entity<Inventory>(entity =>
            {
                entity.ToTable("Inventory");

                entity.HasIndex(e => e.InventoryId, "UQ__Inventor__F5FDE6D2D491F283")
                    .IsUnique();

                entity.Property(e => e.InventoryId).HasColumnName("InventoryID");

                entity.Property(e => e.LocationId).HasColumnName("LocationID");

                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.HasOne(d => d.Location)
                    .WithMany(p => p.Inventories)
                    .HasForeignKey(d => d.LocationId)
                    .HasConstraintName("FK__Inventory__Locat__70DDC3D8");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.Inventories)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK__Inventory__Produ__6FE99F9F");
            });

            modelBuilder.Entity<OrderedProduct>(entity =>
            {
                entity.HasKey(e => new { e.CustomerOrderId, e.QuantityOfItems })
                    .HasName("PK__OrderedP__8B06469B092C01EA");

                entity.ToTable("OrderedProduct");

                entity.Property(e => e.CustomerOrderId).HasColumnName("CustomerOrderID");

                entity.Property(e => e.CustomerId).HasColumnName("CustomerID");

                entity.Property(e => e.ProductId).HasColumnName("productID");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.OrderedProducts)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK__OrderedPr__Custo__6B24EA82");

                entity.HasOne(d => d.CustomerOrder)
                    .WithMany(p => p.OrderedProducts)
                    .HasForeignKey(d => d.CustomerOrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__OrderedPr__Custo__6C190EBB");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.OrderedProducts)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK__OrderedPr__produ__6A30C649");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("Product");

                entity.HasIndex(e => e.ProductId, "UQ__Product__B40CC6EC22B3DD32")
                    .IsUnique();

                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.Property(e => e.ProductDescription)
                    .HasMaxLength(20)
                    .HasColumnName("productDescription");

                entity.Property(e => e.ProductName).HasMaxLength(20);

                entity.Property(e => e.ProductPrice).HasColumnType("decimal(5, 2)");
            });

            modelBuilder.Entity<StoreLocation>(entity =>
            {
                entity.HasKey(e => e.LocationId)
                    .HasName("PK__StoreLoc__E7FEA477DB0E0CE4");

                entity.ToTable("StoreLocation");

                entity.HasIndex(e => e.LocationId, "UQ__StoreLoc__E7FEA47620A0C9FA")
                    .IsUnique();

                entity.Property(e => e.LocationId).HasColumnName("LocationID");

                entity.Property(e => e.LocationName).HasMaxLength(20);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
