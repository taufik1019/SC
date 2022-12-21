﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SC.Context;

namespace SC.Migrations
{
    [DbContext(typeof(MyContext))]
    [Migration("20221221060804_init")]
    partial class init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.29")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SC.Models.Keluhan", b =>
                {
                    b.Property<int>("KeluhanId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("KeluhanMahasiswa")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("TanggalKeluhan")
                        .HasColumnType("datetime2");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("KeluhanId");

                    b.HasIndex("UserId");

                    b.ToTable("Keluhans");
                });

            modelBuilder.Entity("SC.Models.ProfileMahasiswa", b =>
                {
                    b.Property<int>("ProfileMahasiswaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Alamat")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Prodi")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Semester")
                        .HasColumnType("int");

                    b.Property<int>("StudentId")
                        .HasColumnType("int");

                    b.Property<DateTime>("TanggalLahir")
                        .HasColumnType("datetime2");

                    b.HasKey("ProfileMahasiswaId");

                    b.ToTable("ProfileMahasiswas");
                });

            modelBuilder.Entity("SC.Models.Respon", b =>
                {
                    b.Property<int>("ResponId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("KeluhanId")
                        .HasColumnType("int");

                    b.Property<string>("ResponKeluhan")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("TanggalRespon")
                        .HasColumnType("datetime2");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("ResponId");

                    b.HasIndex("KeluhanId");

                    b.HasIndex("UserId");

                    b.ToTable("Respons");
                });

            modelBuilder.Entity("SC.Models.Role", b =>
                {
                    b.Property<int>("RoleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("RoleName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RoleId");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("SC.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ProfileMahasiswaId")
                        .HasColumnType("int");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.Property<int?>("User")
                        .HasColumnType("int");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.HasIndex("ProfileMahasiswaId");

                    b.HasIndex("RoleId");

                    b.HasIndex("User");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("SC.Models.Keluhan", b =>
                {
                    b.HasOne("SC.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SC.Models.Respon", b =>
                {
                    b.HasOne("SC.Models.Keluhan", "Keluhan")
                        .WithMany()
                        .HasForeignKey("KeluhanId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SC.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("SC.Models.User", b =>
                {
                    b.HasOne("SC.Models.ProfileMahasiswa", "ProfileMahasiswa")
                        .WithMany()
                        .HasForeignKey("ProfileMahasiswaId");

                    b.HasOne("SC.Models.Role", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SC.Models.Respon", null)
                        .WithMany("Users")
                        .HasForeignKey("User");
                });
#pragma warning restore 612, 618
        }
    }
}