﻿// <auto-generated />
using System;
using Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Data.Migrations
{
    [DbContext(typeof(CompanyDbContext))]
    [Migration("20220718130442_AddUserAvatar")]
    partial class AddUserAvatar
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Data.Entities.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<float>("Rating")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "The iPhone X was Apple's flagship 10th anniversary iPhone featuring a 5.8-inch OLED display, facial recognition and 3D camera functionality, a glass body, and an A11 Bionic processor.",
                            Name = "iPhone X",
                            Price = 650m,
                            Rating = 8.2f
                        },
                        new
                        {
                            Id = 2,
                            Description = "Summary ; performanceCore i3 2nd Gen, 2.4 Ghz, 4 GB RAM ; design15.6 inches, 1366 x 768 , 2.7 Kg, 34.3 mm thick ; storage320 GB HDD, SATA, 5400 RPM.",
                            Name = "Lenovo G580",
                            Price = 200m,
                            Rating = 6.5f
                        },
                        new
                        {
                            Id = 3,
                            Description = "LG's Monitor allows you to maximize work efficiency and bring other practical benefits to your workplace with advanced and unique solutions. Learn more now.",
                            Name = "Monitor LG G6",
                            Price = 440m,
                            Rating = 7.7f
                        });
                });

            modelBuilder.Entity("Data.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Avatar")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BirthDate = new DateTime(2022, 7, 18, 16, 4, 42, 518, DateTimeKind.Local).AddTicks(8780),
                            Email = "rejv434@gmail.com",
                            Name = "Vlad",
                            Surname = "Tymo"
                        },
                        new
                        {
                            Id = 2,
                            BirthDate = new DateTime(2022, 7, 18, 16, 4, 42, 521, DateTimeKind.Local).AddTicks(2530),
                            Email = "super4344@gmail.com",
                            Name = "Bob",
                            Surname = "Bobovich"
                        },
                        new
                        {
                            Id = 3,
                            BirthDate = new DateTime(2022, 7, 18, 16, 4, 42, 521, DateTimeKind.Local).AddTicks(2563),
                            Email = "hgkkkkff@gmail.com",
                            Name = "Igor",
                            Surname = "Rufer"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}