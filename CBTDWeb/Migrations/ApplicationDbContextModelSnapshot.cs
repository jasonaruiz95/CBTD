﻿// <auto-generated />
using System;
using CBTDWeb.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CBTDWeb.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CBTDWeb.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DateModified")
                        .HasColumnType("datetime2");

                    b.Property<int>("DisplayOrder")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DateModified = new DateTime(2023, 5, 11, 13, 20, 11, 757, DateTimeKind.Local).AddTicks(6674),
                            DisplayOrder = 1,
                            Name = "Beverages"
                        },
                        new
                        {
                            Id = 2,
                            DateModified = new DateTime(2023, 5, 11, 13, 20, 11, 757, DateTimeKind.Local).AddTicks(6719),
                            DisplayOrder = 2,
                            Name = "Wine"
                        },
                        new
                        {
                            Id = 3,
                            DateModified = new DateTime(2023, 5, 11, 13, 20, 11, 757, DateTimeKind.Local).AddTicks(6721),
                            DisplayOrder = 3,
                            Name = "Books"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}