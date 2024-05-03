﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace w.sale.car.db.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240503014612_ModifySaleSnType")]
    partial class ModifySaleSnType
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("bt.rent.car.model.Model.Car", b =>
                {
                    b.Property<int>("IdCar")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdCar"));

                    b.Property<bool>("Available")
                        .HasColumnType("bit");

                    b.Property<int>("Capacity")
                        .HasColumnType("int");

                    b.Property<int>("Cost")
                        .HasColumnType("int");

                    b.Property<string>("Make")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Mileage")
                        .HasColumnType("int");

                    b.Property<int>("Model")
                        .HasColumnType("int");

                    b.Property<int>("SubModel")
                        .HasColumnType("int");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("YearModel")
                        .HasColumnType("int");

                    b.HasKey("IdCar");

                    b.ToTable("car");
                });

            modelBuilder.Entity("bt.rent.car.model.Model.Location", b =>
                {
                    b.Property<int>("IdLocation")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdLocation"));

                    b.Property<bool>("Available")
                        .HasColumnType("bit");

                    b.Property<string>("Locality")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ZipCode")
                        .HasColumnType("int");

                    b.Property<string>("Zone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdLocation");

                    b.ToTable("location");
                });

            modelBuilder.Entity("bt.rent.car.model.Model.Reserve", b =>
                {
                    b.Property<int>("IdReserve")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdReserve"));

                    b.Property<float>("BaseCost")
                        .HasColumnType("real");

                    b.Property<DateTime>("CollectDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeliveryDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("DoSale")
                        .HasColumnType("bit");

                    b.Property<int>("IdCar")
                        .HasColumnType("int");

                    b.Property<int>("IdClient")
                        .HasColumnType("int");

                    b.Property<int>("IdCollectLocation")
                        .HasColumnType("int");

                    b.Property<int?>("IdDeliveryLocation")
                        .HasColumnType("int");

                    b.Property<float>("OthersCosts")
                        .HasColumnType("real");

                    b.Property<DateTime>("ReserveDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("SN")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdReserve");

                    b.ToTable("reserve");
                });

            modelBuilder.Entity("bt.rent.car.model.Model.Sale", b =>
                {
                    b.Property<int>("IdSale")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdSale"));

                    b.Property<int>("IdCar")
                        .HasColumnType("int");

                    b.Property<int>("IdUser")
                        .HasColumnType("int");

                    b.Property<int>("IdVendor")
                        .HasColumnType("int");

                    b.Property<DateTime>("SaleDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("SnReserve")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("TotalSale")
                        .HasColumnType("real");

                    b.HasKey("IdSale");

                    b.ToTable("sale");
                });

            modelBuilder.Entity("bt.rent.car.model.Model.User", b =>
                {
                    b.Property<int>("IdUser")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdUser"));

                    b.Property<float>("AmountApproved")
                        .HasColumnType("real");

                    b.Property<int>("Document")
                        .HasColumnType("int");

                    b.Property<string>("DocumentType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PaymentType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdUser");

                    b.ToTable("user");
                });
#pragma warning restore 612, 618
        }
    }
}
