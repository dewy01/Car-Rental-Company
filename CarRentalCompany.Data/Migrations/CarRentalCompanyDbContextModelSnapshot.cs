﻿// <auto-generated />
using System;
using CarRentalCompany.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CarRentalCompany.Data.Migrations
{
    [DbContext(typeof(CarRentalCompanyDbContext))]
    partial class CarRentalCompanyDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CarRentalCompany.Data.Brand", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("Id");

                    b.ToTable("Brands");
                });

            modelBuilder.Entity("CarRentalCompany.Data.Car", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("BrandId")
                        .HasColumnType("int");

                    b.Property<int?>("CarModelId")
                        .HasColumnType("int");

                    b.Property<int?>("ColourId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<int>("Year")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BrandId");

                    b.HasIndex("CarModelId");

                    b.HasIndex("ColourId");

                    b.ToTable("Cars");
                });

            modelBuilder.Entity("CarRentalCompany.Data.CarModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("BrandId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("BrandId");

                    b.ToTable("CarModels");
                });

            modelBuilder.Entity("CarRentalCompany.Data.Car_Owner", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("CarId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<int?>("OwnerId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CarId");

                    b.HasIndex("OwnerId");

                    b.ToTable("Car_Owners");
                });

            modelBuilder.Entity("CarRentalCompany.Data.Colour", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("Id");

                    b.ToTable("Colours");
                });

            modelBuilder.Entity("CarRentalCompany.Data.Owner", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Owners");
                });

            modelBuilder.Entity("CarRentalCompany.Data.Car", b =>
                {
                    b.HasOne("CarRentalCompany.Data.Brand", "Brand")
                        .WithMany("Cars")
                        .HasForeignKey("BrandId");

                    b.HasOne("CarRentalCompany.Data.CarModel", "CarModel")
                        .WithMany("Cars")
                        .HasForeignKey("CarModelId");

                    b.HasOne("CarRentalCompany.Data.Colour", "Colour")
                        .WithMany("Cars")
                        .HasForeignKey("ColourId");

                    b.Navigation("Brand");

                    b.Navigation("CarModel");

                    b.Navigation("Colour");
                });

            modelBuilder.Entity("CarRentalCompany.Data.CarModel", b =>
                {
                    b.HasOne("CarRentalCompany.Data.Brand", "Brand")
                        .WithMany("CarModels")
                        .HasForeignKey("BrandId");

                    b.Navigation("Brand");
                });

            modelBuilder.Entity("CarRentalCompany.Data.Car_Owner", b =>
                {
                    b.HasOne("CarRentalCompany.Data.Car", "Car")
                        .WithMany("Car_Owners")
                        .HasForeignKey("CarId");

                    b.HasOne("CarRentalCompany.Data.Owner", "Owner")
                        .WithMany("Car_Owners")
                        .HasForeignKey("OwnerId");

                    b.Navigation("Car");

                    b.Navigation("Owner");
                });

            modelBuilder.Entity("CarRentalCompany.Data.Brand", b =>
                {
                    b.Navigation("CarModels");

                    b.Navigation("Cars");
                });

            modelBuilder.Entity("CarRentalCompany.Data.Car", b =>
                {
                    b.Navigation("Car_Owners");
                });

            modelBuilder.Entity("CarRentalCompany.Data.CarModel", b =>
                {
                    b.Navigation("Cars");
                });

            modelBuilder.Entity("CarRentalCompany.Data.Colour", b =>
                {
                    b.Navigation("Cars");
                });

            modelBuilder.Entity("CarRentalCompany.Data.Owner", b =>
                {
                    b.Navigation("Car_Owners");
                });
#pragma warning restore 612, 618
        }
    }
}
