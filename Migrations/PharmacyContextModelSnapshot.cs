﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PharmacyAPI.Data;

#nullable disable

namespace PharmacyAPI.Migrations
{
    [DbContext(typeof(PharmacyContext))]
    partial class PharmacyContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("PharmacyAPI.Models.Batch", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<long>("BranchId")
                        .HasColumnType("bigint")
                        .HasColumnName("branch_id");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime")
                        .HasColumnName("date");

                    b.Property<long>("SupplierId")
                        .HasColumnType("bigint")
                        .HasColumnName("supplier_id");

                    b.Property<decimal>("TotalCost")
                        .HasColumnType("decimal(8, 2)")
                        .HasColumnName("total_cost");

                    b.HasKey("Id");

                    b.HasIndex("BranchId");

                    b.HasIndex("SupplierId");

                    b.ToTable("batch", (string)null);
                });

            modelBuilder.Entity("PharmacyAPI.Models.Branch", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("Latitude")
                        .IsRequired()
                        .HasMaxLength(15)
                        .IsUnicode(false)
                        .HasColumnType("varchar(15)")
                        .HasColumnName("latitude");

                    b.Property<string>("Longitude")
                        .IsRequired()
                        .HasMaxLength(15)
                        .IsUnicode(false)
                        .HasColumnType("varchar(15)")
                        .HasColumnName("longitude");

                    b.Property<long>("ManagerId")
                        .HasColumnType("bigint")
                        .HasColumnName("manager_id");

                    b.HasKey("Id");

                    b.HasIndex("ManagerId");

                    b.ToTable("branch", (string)null);
                });

            modelBuilder.Entity("PharmacyAPI.Models.Category", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.ToTable("category", (string)null);
                });

            modelBuilder.Entity("PharmacyAPI.Models.Customer", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<long>("CustomerNumber")
                        .HasColumnType("bigint")
                        .HasColumnName("customer_number");

                    b.Property<bool>("IsBlocked")
                        .HasColumnType("bit")
                        .HasColumnName("is_blocked");

                    b.Property<long>("PersonId")
                        .HasColumnType("bigint")
                        .HasColumnName("person_id");

                    b.HasKey("Id");

                    b.HasIndex("PersonId");

                    b.ToTable("customer", (string)null);
                });

            modelBuilder.Entity("PharmacyAPI.Models.InventoryAdjustment", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime")
                        .HasColumnName("date");

                    b.Property<string>("Description")
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("description");

                    b.Property<long>("ProductBatchId")
                        .HasColumnType("bigint")
                        .HasColumnName("product_batch_id");

                    b.Property<int>("QuantityChange")
                        .HasColumnType("int")
                        .HasColumnName("quantity_change");

                    b.Property<int>("Reason")
                        .HasColumnType("int")
                        .HasColumnName("reason");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint")
                        .HasColumnName("user_id");

                    b.HasKey("Id");

                    b.HasIndex("ProductBatchId");

                    b.HasIndex("UserId");

                    b.ToTable("inventory_adjustment", (string)null);
                });

            modelBuilder.Entity("PharmacyAPI.Models.Manufacturer", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.ToTable("manufacturer", (string)null);
                });

            modelBuilder.Entity("PharmacyAPI.Models.Person", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("Address")
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("address");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("first_name");

                    b.Property<bool>("Gender")
                        .HasColumnType("bit")
                        .HasColumnName("gender");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("last_name");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(15)
                        .IsUnicode(false)
                        .HasColumnType("varchar(15)")
                        .HasColumnName("phone_number");

                    b.HasKey("Id");

                    b.ToTable("person", (string)null);
                });

            modelBuilder.Entity("PharmacyAPI.Models.Product", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("Barcode")
                        .IsRequired()
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("barcode");

                    b.Property<long>("CategoryId")
                        .HasColumnType("bigint")
                        .HasColumnName("category_id");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("description");

                    b.Property<int>("Form")
                        .HasColumnType("int")
                        .HasColumnName("form");

                    b.Property<int?>("FrequencyLimitDays")
                        .HasColumnType("int")
                        .HasColumnName("frequency_limit_days");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit")
                        .HasColumnName("is_deleted");

                    b.Property<long>("ManufacturerId")
                        .HasColumnType("bigint")
                        .HasColumnName("manufacturer_id");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("name");

                    b.Property<bool>("RequiresPrescription")
                        .HasColumnType("bit")
                        .HasColumnName("requires_prescription");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("ManufacturerId");

                    b.ToTable("product", (string)null);
                });

            modelBuilder.Entity("PharmacyAPI.Models.ProductBatch", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<long>("BatchId")
                        .HasColumnType("bigint")
                        .HasColumnName("batch_id");

                    b.Property<decimal>("CostPrice")
                        .HasColumnType("decimal(8, 2)")
                        .HasColumnName("cost_price");

                    b.Property<DateOnly>("ExpirationDate")
                        .HasColumnType("date")
                        .HasColumnName("expiration_date");

                    b.Property<long>("ProductId")
                        .HasColumnType("bigint")
                        .HasColumnName("product_id");

                    b.Property<long>("Quantity")
                        .HasColumnType("bigint")
                        .HasColumnName("quantity");

                    b.Property<decimal>("SellingPrice")
                        .HasColumnType("decimal(8, 2)")
                        .HasColumnName("selling_price");

                    b.HasKey("Id");

                    b.HasIndex("BatchId");

                    b.HasIndex("ProductId");

                    b.ToTable("product_batch", (string)null);
                });

            modelBuilder.Entity("PharmacyAPI.Models.ProductSale", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<long>("ProductId")
                        .HasColumnType("bigint")
                        .HasColumnName("product_id");

                    b.Property<int>("Quantity")
                        .HasColumnType("int")
                        .HasColumnName("quantity");

                    b.Property<long>("SaleId")
                        .HasColumnType("bigint")
                        .HasColumnName("sale_id");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.HasIndex("SaleId");

                    b.ToTable("product_sale", (string)null);
                });

            modelBuilder.Entity("PharmacyAPI.Models.Role", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("Role1")
                        .IsRequired()
                        .HasMaxLength(15)
                        .IsUnicode(false)
                        .HasColumnType("varchar(15)")
                        .HasColumnName("role");

                    b.HasKey("Id");

                    b.ToTable("role", (string)null);
                });

            modelBuilder.Entity("PharmacyAPI.Models.Sale", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<long>("BranchId")
                        .HasColumnType("bigint")
                        .HasColumnName("branch_id");

                    b.Property<long>("CustomerId")
                        .HasColumnType("bigint")
                        .HasColumnName("customer_id");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime")
                        .HasColumnName("date");

                    b.Property<decimal>("TotalPrice")
                        .HasColumnType("decimal(8, 2)")
                        .HasColumnName("total_price");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint")
                        .HasColumnName("user_id");

                    b.HasKey("Id");

                    b.HasIndex("BranchId");

                    b.HasIndex("CustomerId");

                    b.HasIndex("UserId");

                    b.ToTable("sale", (string)null);
                });

            modelBuilder.Entity("PharmacyAPI.Models.Supplier", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<long>("PersonId")
                        .HasColumnType("bigint")
                        .HasColumnName("person_id");

                    b.HasKey("Id");

                    b.HasIndex("PersonId");

                    b.ToTable("supplier", (string)null);
                });

            modelBuilder.Entity("PharmacyAPI.Models.User", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<long?>("BranchId")
                        .HasColumnType("bigint")
                        .HasColumnName("branch_id");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("email");

                    b.Property<bool>("IsAdmin")
                        .HasColumnType("bit")
                        .HasColumnName("is_admin");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit")
                        .HasColumnName("is_deleted");

                    b.Property<long?>("ManagerId")
                        .HasColumnType("bigint")
                        .HasColumnName("manager_id");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("password");

                    b.Property<long>("PersonId")
                        .HasColumnType("bigint")
                        .HasColumnName("person_id");

                    b.Property<long>("RoleId")
                        .HasColumnType("bigint")
                        .HasColumnName("role_id");

                    b.HasKey("Id");

                    b.HasIndex("BranchId");

                    b.HasIndex("ManagerId");

                    b.HasIndex("PersonId");

                    b.HasIndex("RoleId");

                    b.HasIndex(new[] { "Email" }, "unique_email")
                        .IsUnique();

                    b.ToTable("user", (string)null);
                });

            modelBuilder.Entity("PharmacyAPI.Models.Batch", b =>
                {
                    b.HasOne("PharmacyAPI.Models.Branch", "Branch")
                        .WithMany("Batches")
                        .HasForeignKey("BranchId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PharmacyAPI.Models.Supplier", "Supplier")
                        .WithMany("Batches")
                        .HasForeignKey("SupplierId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Branch");

                    b.Navigation("Supplier");
                });

            modelBuilder.Entity("PharmacyAPI.Models.Branch", b =>
                {
                    b.HasOne("PharmacyAPI.Models.User", "Manager")
                        .WithMany("Branches")
                        .HasForeignKey("ManagerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Manager");
                });

            modelBuilder.Entity("PharmacyAPI.Models.Customer", b =>
                {
                    b.HasOne("PharmacyAPI.Models.Person", "Person")
                        .WithMany("Customers")
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Person");
                });

            modelBuilder.Entity("PharmacyAPI.Models.InventoryAdjustment", b =>
                {
                    b.HasOne("PharmacyAPI.Models.ProductBatch", "ProductBatch")
                        .WithMany("InventoryAdjustments")
                        .HasForeignKey("ProductBatchId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PharmacyAPI.Models.User", "User")
                        .WithMany("InventoryAdjustments")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ProductBatch");

                    b.Navigation("User");
                });

            modelBuilder.Entity("PharmacyAPI.Models.Product", b =>
                {
                    b.HasOne("PharmacyAPI.Models.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PharmacyAPI.Models.Manufacturer", "Manufacturer")
                        .WithMany("Products")
                        .HasForeignKey("ManufacturerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("Manufacturer");
                });

            modelBuilder.Entity("PharmacyAPI.Models.ProductBatch", b =>
                {
                    b.HasOne("PharmacyAPI.Models.Batch", "Batch")
                        .WithMany("ProductBatches")
                        .HasForeignKey("BatchId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PharmacyAPI.Models.Product", "Product")
                        .WithMany("ProductBatches")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Batch");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("PharmacyAPI.Models.ProductSale", b =>
                {
                    b.HasOne("PharmacyAPI.Models.Product", "Product")
                        .WithMany("ProductSales")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PharmacyAPI.Models.Sale", "Sale")
                        .WithMany("ProductSales")
                        .HasForeignKey("SaleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");

                    b.Navigation("Sale");
                });

            modelBuilder.Entity("PharmacyAPI.Models.Sale", b =>
                {
                    b.HasOne("PharmacyAPI.Models.Branch", "Branch")
                        .WithMany("Sales")
                        .HasForeignKey("BranchId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PharmacyAPI.Models.Customer", "Customer")
                        .WithMany("Sales")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PharmacyAPI.Models.User", "User")
                        .WithMany("Sales")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Branch");

                    b.Navigation("Customer");

                    b.Navigation("User");
                });

            modelBuilder.Entity("PharmacyAPI.Models.Supplier", b =>
                {
                    b.HasOne("PharmacyAPI.Models.Person", "Person")
                        .WithMany("Suppliers")
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Person");
                });

            modelBuilder.Entity("PharmacyAPI.Models.User", b =>
                {
                    b.HasOne("PharmacyAPI.Models.Branch", "Branch")
                        .WithMany("Users")
                        .HasForeignKey("BranchId");

                    b.HasOne("PharmacyAPI.Models.User", "Manager")
                        .WithMany("InverseManager")
                        .HasForeignKey("ManagerId");

                    b.HasOne("PharmacyAPI.Models.Person", "Person")
                        .WithMany("Users")
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PharmacyAPI.Models.Role", "Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Branch");

                    b.Navigation("Manager");

                    b.Navigation("Person");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("PharmacyAPI.Models.Batch", b =>
                {
                    b.Navigation("ProductBatches");
                });

            modelBuilder.Entity("PharmacyAPI.Models.Branch", b =>
                {
                    b.Navigation("Batches");

                    b.Navigation("Sales");

                    b.Navigation("Users");
                });

            modelBuilder.Entity("PharmacyAPI.Models.Category", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("PharmacyAPI.Models.Customer", b =>
                {
                    b.Navigation("Sales");
                });

            modelBuilder.Entity("PharmacyAPI.Models.Manufacturer", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("PharmacyAPI.Models.Person", b =>
                {
                    b.Navigation("Customers");

                    b.Navigation("Suppliers");

                    b.Navigation("Users");
                });

            modelBuilder.Entity("PharmacyAPI.Models.Product", b =>
                {
                    b.Navigation("ProductBatches");

                    b.Navigation("ProductSales");
                });

            modelBuilder.Entity("PharmacyAPI.Models.ProductBatch", b =>
                {
                    b.Navigation("InventoryAdjustments");
                });

            modelBuilder.Entity("PharmacyAPI.Models.Role", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("PharmacyAPI.Models.Sale", b =>
                {
                    b.Navigation("ProductSales");
                });

            modelBuilder.Entity("PharmacyAPI.Models.Supplier", b =>
                {
                    b.Navigation("Batches");
                });

            modelBuilder.Entity("PharmacyAPI.Models.User", b =>
                {
                    b.Navigation("Branches");

                    b.Navigation("InventoryAdjustments");

                    b.Navigation("InverseManager");

                    b.Navigation("Sales");
                });
#pragma warning restore 612, 618
        }
    }
}
