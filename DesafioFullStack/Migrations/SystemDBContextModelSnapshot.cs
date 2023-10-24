﻿// <auto-generated />
using System;
using DesafioFullStack.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DesafioFullStack.Migrations
{
    [DbContext(typeof(SystemDBContext))]
    partial class SystemDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DesafioFullStack.Entities.Company", b =>
                {
                    b.Property<string>("CNPJ")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("CEP")
                        .IsRequired()
                        .HasMaxLength(12)
                        .HasColumnType("nvarchar(12)");

                    b.Property<string>("TradeName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("CNPJ");

                    b.ToTable("Companies");
                });

            modelBuilder.Entity("DesafioFullStack.Entities.Supplier", b =>
                {
                    b.Property<string>("CNPJ")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime?>("Birthday")
                        .HasMaxLength(11)
                        .HasColumnType("datetime2");

                    b.Property<string>("CEP")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("RG")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.HasKey("CNPJ");

                    b.ToTable("Suppliers");
                });
#pragma warning restore 612, 618
        }
    }
}
