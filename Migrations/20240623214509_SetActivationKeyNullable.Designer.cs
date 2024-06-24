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
    [Migration("20240623214509_SetActivationKeyNullable")]
    partial class SetActivationKeyNullable
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
                            Id = new Guid("29e10d80-4701-49cb-b205-5bcc6e0fc245"),
                            CPF = "12345678",
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "eduarbaldin@gmail.com",
                            Name = "Admin Eduardo",
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
                            ClassSubjectId = new Guid("ccc68657-6489-4b5a-9419-6af4fd349c30"),
                            CreatedAt = new DateTime(2024, 6, 23, 21, 45, 7, 808, DateTimeKind.Utc).AddTicks(8221),
                            ManagerId = new Guid("97f31c66-6114-487a-a364-fcd2659c01a1"),
                            Name = "PowerBI",
                            TeacherId = new Guid("ee6393f2-abfe-47e6-8186-bc08bc4a4cd0"),
                            UpdatedAt = new DateTime(2024, 6, 23, 21, 45, 7, 808, DateTimeKind.Utc).AddTicks(8222)
                        },
                        new
                        {
                            ClassSubjectId = new Guid("3bf73a9c-f58c-4600-b043-bca5df6a352f"),
                            CreatedAt = new DateTime(2024, 6, 23, 21, 45, 7, 808, DateTimeKind.Utc).AddTicks(8225),
                            ManagerId = new Guid("97f31c66-6114-487a-a364-fcd2659c01a1"),
                            Name = "PowerBI",
                            TeacherId = new Guid("d0c7bf7b-efc0-4c63-9c9b-1bfa0e1dd207"),
                            UpdatedAt = new DateTime(2024, 6, 23, 21, 45, 7, 808, DateTimeKind.Utc).AddTicks(8226)
                        });
                });

            modelBuilder.Entity("class_management_web_api.src.Entities.ClassTime", b =>
                {
                    b.Property<Guid>("ClassTimeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("ClassClosingHour")
                        .HasColumnType("datetime2");

                    b.Property<int>("ClassDuration")
                        .HasColumnType("int");

                    b.Property<DateTime>("ClassStartingHour")
                        .HasColumnType("datetime2");

                    b.Property<int>("ClassesQuantity")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("WeekDay")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ClassTimeId");

                    b.ToTable("ClassTime");
                });

            modelBuilder.Entity("class_management_web_api.src.Entities.GraduationCourse", b =>
                {
                    b.Property<Guid>("GraduationCourseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("ClassDuration")
                        .HasColumnType("int");

                    b.Property<int>("ClassesQuantity")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("ManagerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("GraduationCourseId");

                    b.HasIndex("ManagerId");

                    b.ToTable("GraduationCourses");
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
                            CreatedAt = new DateTime(2024, 6, 23, 21, 45, 7, 808, DateTimeKind.Utc).AddTicks(8194),
                            Email = "teste@gmail.com",
                            Name = "Cordenador Teste",
                            Password = "123456",
                            Role = "Manager",
                            UpdatedAt = new DateTime(2024, 6, 23, 21, 45, 7, 808, DateTimeKind.Utc).AddTicks(8195)
                        },
                        new
                        {
                            ManagerId = new Guid("61794cec-ba4a-432c-af5e-f58fe07799ac"),
                            CPF = "12345678",
                            CreatedAt = new DateTime(2024, 6, 23, 21, 45, 7, 808, DateTimeKind.Utc).AddTicks(8198),
                            Email = "pedro@gmail.com",
                            Name = "Pedro",
                            Password = "123456",
                            Role = "Manager",
                            UpdatedAt = new DateTime(2024, 6, 23, 21, 45, 7, 808, DateTimeKind.Utc).AddTicks(8198)
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

                    b.Property<Guid?>("ActivationKey")
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

                    b.Property<Guid?>("GraduationCourseId")
                        .HasColumnType("uniqueidentifier");

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

                    b.HasIndex("GraduationCourseId");

                    b.ToTable("Teachers");

                    b.HasData(
                        new
                        {
                            TeacherId = new Guid("ee6393f2-abfe-47e6-8186-bc08bc4a4cd0"),
                            CPF = "12345678",
                            CreatedAt = new DateTime(2024, 6, 23, 21, 45, 7, 808, DateTimeKind.Utc).AddTicks(8166),
                            Email = "johanny@gmail.com",
                            Name = "Johanny",
                            Password = "123456",
                            Role = "Teacher",
                            UpdatedAt = new DateTime(2024, 6, 23, 21, 45, 7, 808, DateTimeKind.Utc).AddTicks(8166)
                        },
                        new
                        {
                            TeacherId = new Guid("d0c7bf7b-efc0-4c63-9c9b-1bfa0e1dd207"),
                            CPF = "12345678",
                            CreatedAt = new DateTime(2024, 6, 23, 21, 45, 7, 808, DateTimeKind.Utc).AddTicks(8169),
                            Email = "tiago@gmail.com",
                            Name = "Tiago",
                            Password = "123456",
                            Role = "Teacher",
                            UpdatedAt = new DateTime(2024, 6, 23, 21, 45, 7, 808, DateTimeKind.Utc).AddTicks(8170)
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
                            Id = new Guid("a0776d82-0383-42fc-beae-638db701d0ee"),
                            CPF = "12345678",
                            CreatedAt = new DateTime(2024, 6, 23, 21, 45, 7, 808, DateTimeKind.Utc).AddTicks(8129),
                            Email = "eduarbaldin@gmail.com",
                            Name = "Admin",
                            Password = "123456",
                            Role = 3,
                            Salt = "y9wrDdai3E=n",
                            UpdatedAt = new DateTime(2024, 6, 23, 21, 45, 7, 808, DateTimeKind.Utc).AddTicks(8132)
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

            modelBuilder.Entity("class_management_web_api.src.Entities.GraduationCourse", b =>
                {
                    b.HasOne("class_management_web_api.src.Entities.Manager", "Manager")
                        .WithMany("GraduationCourses")
                        .HasForeignKey("ManagerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Manager");
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

            modelBuilder.Entity("class_management_web_api.src.Entities.Teacher", b =>
                {
                    b.HasOne("class_management_web_api.src.Entities.GraduationCourse", "GraduationCourse")
                        .WithMany("Teachers")
                        .HasForeignKey("GraduationCourseId");

                    b.Navigation("GraduationCourse");
                });

            modelBuilder.Entity("class_management_web_api.src.Entities.GraduationCourse", b =>
                {
                    b.Navigation("Teachers");
                });

            modelBuilder.Entity("class_management_web_api.src.Entities.Manager", b =>
                {
                    b.Navigation("ClassSubjects");

                    b.Navigation("GraduationCourses");
                });

            modelBuilder.Entity("class_management_web_api.src.Entities.Teacher", b =>
                {
                    b.Navigation("ClassSubjects");
                });
#pragma warning restore 612, 618
        }
    }
}
