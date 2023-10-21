﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProjeComplatedFull1.Entities;
using System;

#nullable disable

namespace ProjeComplatedFull1.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20230911085541_1")]
    partial class _1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.21")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ProjeComplatedFull1.Entities.Dersler", b =>
                {
                    b.Property<int>("DersId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DersId"), 1L, 1);

                    b.Property<string>("DersAd")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("DersId");

                    b.ToTable("Dersler");
                });

            modelBuilder.Entity("ProjeComplatedFull1.Entities.Notlar", b =>
                {
                    b.Property<int>("NotId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("NotId"), 1L, 1);

                    b.Property<int>("DersId")
                        .HasColumnType("int");

                    b.Property<bool>("Durum")
                        .HasColumnType("bit");

                    b.Property<decimal>("Ortalama")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("Sınav1")
                        .HasColumnType("int");

                    b.Property<int?>("Sınav2")
                        .HasColumnType("int");

                    b.Property<int?>("Sınav3")
                        .HasColumnType("int");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("NotId");

                    b.HasIndex("DersId");

                    b.HasIndex("UserId");

                    b.ToTable("Not");
                });

            modelBuilder.Entity("ProjeComplatedFull1.Entities.Roller", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("RoleAd")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Rol");
                });

            modelBuilder.Entity("ProjeComplatedFull1.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Locked")
                        .HasColumnType("bit");

                    b.Property<string>("NameSurname")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("ProfileImageFile")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<int>("RolId")
                        .HasColumnType("int");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("Id");

                    b.HasIndex("RolId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("ProjeComplatedFull1.Entities.Notlar", b =>
                {
                    b.HasOne("ProjeComplatedFull1.Entities.Dersler", "Dersler")
                        .WithMany("Notlar")
                        .HasForeignKey("DersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProjeComplatedFull1.Entities.User", "User")
                        .WithMany("Notlar")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Dersler");

                    b.Navigation("User");
                });

            modelBuilder.Entity("ProjeComplatedFull1.Entities.User", b =>
                {
                    b.HasOne("ProjeComplatedFull1.Entities.Roller", "Rol")
                        .WithMany("users")
                        .HasForeignKey("RolId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Rol");
                });

            modelBuilder.Entity("ProjeComplatedFull1.Entities.Dersler", b =>
                {
                    b.Navigation("Notlar");
                });

            modelBuilder.Entity("ProjeComplatedFull1.Entities.Roller", b =>
                {
                    b.Navigation("users");
                });

            modelBuilder.Entity("ProjeComplatedFull1.Entities.User", b =>
                {
                    b.Navigation("Notlar");
                });
#pragma warning restore 612, 618
        }
    }
}
