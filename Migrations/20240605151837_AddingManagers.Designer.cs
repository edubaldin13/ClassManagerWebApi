﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using class_management_web_api.src.Contexts;

#nullable disable

namespace class_management_web_api.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240605151837_AddingManagers")]
    partial class AddingManagers
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("class_management_web_api.src.Entities.Admin", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CPF")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(254)
                        .HasColumnType("nvarchar(254)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(254)
                        .HasColumnType("nvarchar(254)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Admins");

                    b.HasData(
                        new
                        {
                            Id = new Guid("62095c4d-a399-4b94-9bc7-33ddb80ba539"),
                            CPF = "12345678",
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "eduarbaldin@gmail.com",
                            Name = "Admin",
                            Password = "123456",
                            UpdatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("class_management_web_api.src.Entities.ClassSubject", b =>
                {
                    b.Property<Guid>("ClassSubjectId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("ManagerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("TeacherId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("ClassSubjectId");

                    b.HasIndex("ManagerId");

                    b.HasIndex("TeacherId");

                    b.ToTable("ClassSubjects");

                    b.HasData(
                        new
                        {
                            ClassSubjectId = new Guid("f7185071-181e-4abe-a8c1-ca80ef72aa16"),
                            CreatedAt = new DateTime(2024, 6, 5, 15, 18, 36, 778, DateTimeKind.Utc).AddTicks(8967),
                            ManagerId = new Guid("97f31c66-6114-487a-a364-fcd2659c01a1"),
                            Name = "Materia Teste",
                            TeacherId = new Guid("ee6393f2-abfe-47e6-8186-bc08bc4a4cd0"),
                            UpdatedAt = new DateTime(2024, 6, 5, 15, 18, 36, 778, DateTimeKind.Utc).AddTicks(8967)
                        });
                });

            modelBuilder.Entity("class_management_web_api.src.Entities.ClassTime", b =>
                {
                    b.Property<Guid>("ClassTimeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Duration")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("EndingHour")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("StartingHour")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("WeekDay")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ClassTimeId");

                    b.ToTable("ClassTime");
                });

            modelBuilder.Entity("class_management_web_api.src.Entities.Manager", b =>
                {
                    b.Property<Guid>("ManagerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CPF")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(254)
                        .HasColumnType("nvarchar(254)");

                    b.Property<string>("ManagerDoc")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(254)
                        .HasColumnType("nvarchar(254)");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("ManagerId");

                    b.ToTable("Managers");

                    b.HasData(
                        new
                        {
                            ManagerId = new Guid("97f31c66-6114-487a-a364-fcd2659c01a1"),
                            CPF = "12345678",
                            CreatedAt = new DateTime(2024, 6, 5, 15, 18, 36, 778, DateTimeKind.Utc).AddTicks(8946),
                            Email = "eduarbaldin@gmail.com",
                            Name = "Cordenador Teste",
                            Password = "123456",
                            Role = "Manager",
                            UpdatedAt = new DateTime(2024, 6, 5, 15, 18, 36, 778, DateTimeKind.Utc).AddTicks(8947)
                        });
                });

            modelBuilder.Entity("class_management_web_api.src.Entities.Principal", b =>
                {
                    b.Property<Guid>("PrincipalId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CPF")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)");

                    b.Property<Guid>("ClassSubjectId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(254)
                        .HasColumnType("nvarchar(254)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(254)
                        .HasColumnType("nvarchar(254)");

                    b.Property<string>("PrincipalDoc")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("PrincipalId");

                    b.HasIndex("ClassSubjectId");

                    b.ToTable("Principals");
                });

            modelBuilder.Entity("class_management_web_api.src.Entities.Register", b =>
                {
                    b.Property<Guid>("RegisterId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ActivationKey")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CPF")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(254)
                        .HasColumnType("nvarchar(254)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(254)
                        .HasColumnType("nvarchar(254)");

                    b.Property<int?>("Role")
                        .HasColumnType("int");

                    b.Property<string>("Salt")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("RegisterId");

                    b.ToTable("Registers");
                });

            modelBuilder.Entity("class_management_web_api.src.Entities.Student", b =>
                {
                    b.Property<Guid>("StudentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CPF")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)");

                    b.Property<Guid>("ClassSubjectId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(254)
                        .HasColumnType("nvarchar(254)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(254)
                        .HasColumnType("nvarchar(254)");

                    b.Property<string>("RA")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("StudentId");

                    b.HasIndex("ClassSubjectId")
                        .IsUnique();

                    b.ToTable("Student");
                });

            modelBuilder.Entity("class_management_web_api.src.Entities.Teacher", b =>
                {
                    b.Property<Guid>("TeacherId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CPF")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(254)
                        .HasColumnType("nvarchar(254)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(254)
                        .HasColumnType("nvarchar(254)");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TeacherDoc")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("TeacherId");

                    b.ToTable("Teachers");

                    b.HasData(
                        new
                        {
                            TeacherId = new Guid("ee6393f2-abfe-47e6-8186-bc08bc4a4cd0"),
                            CPF = "12345678",
                            CreatedAt = new DateTime(2024, 6, 5, 15, 18, 36, 778, DateTimeKind.Utc).AddTicks(8924),
                            Email = "eduarbaldin@gmail.com",
                            Name = "Teacher Teste",
                            Password = "123456",
                            Role = "Teacher",
                            UpdatedAt = new DateTime(2024, 6, 5, 15, 18, 36, 778, DateTimeKind.Utc).AddTicks(8925)
                        });
                });

            modelBuilder.Entity("class_management_web_api.src.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CPF")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(254)
                        .HasColumnType("nvarchar(254)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(254)
                        .HasColumnType("nvarchar(254)");

                    b.Property<int?>("Role")
                        .HasColumnType("int");

                    b.Property<string>("Salt")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = new Guid("52c97cbb-e4e5-49f6-ae36-a3d63ae3856a"),
                            CPF = "12345678",
                            CreatedAt = new DateTime(2024, 6, 5, 15, 18, 36, 778, DateTimeKind.Utc).AddTicks(8885),
                            Email = "eduarbaldin@gmail.com",
                            Name = "Admin",
                            Password = "123456",
                            Role = 0,
                            Salt = "y9wrDdai3E=n",
                            UpdatedAt = new DateTime(2024, 6, 5, 15, 18, 36, 778, DateTimeKind.Utc).AddTicks(8887)
                        });
                });

            modelBuilder.Entity("class_management_web_api.src.Entities.ClassSubject", b =>
                {
                    b.HasOne("class_management_web_api.src.Entities.Manager", "Manager")
                        .WithMany("ClassSubjects")
                        .HasForeignKey("ManagerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("class_management_web_api.src.Entities.Teacher", "Teacher")
                        .WithMany("ClassSubjects")
                        .HasForeignKey("TeacherId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Manager");

                    b.Navigation("Teacher");
                });

            modelBuilder.Entity("class_management_web_api.src.Entities.Principal", b =>
                {
                    b.HasOne("class_management_web_api.src.Entities.ClassSubject", "ClassSubject")
                        .WithMany()
                        .HasForeignKey("ClassSubjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ClassSubject");
                });

            modelBuilder.Entity("class_management_web_api.src.Entities.Student", b =>
                {
                    b.HasOne("class_management_web_api.src.Entities.ClassSubject", "ClassSubject")
                        .WithOne("Student")
                        .HasForeignKey("class_management_web_api.src.Entities.Student", "ClassSubjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ClassSubject");
                });

            modelBuilder.Entity("class_management_web_api.src.Entities.ClassSubject", b =>
                {
                    b.Navigation("Student");
                });

            modelBuilder.Entity("class_management_web_api.src.Entities.Manager", b =>
                {
                    b.Navigation("ClassSubjects");
                });

            modelBuilder.Entity("class_management_web_api.src.Entities.Teacher", b =>
                {
                    b.Navigation("ClassSubjects");
                });
#pragma warning restore 612, 618
        }
    }
}