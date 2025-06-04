using System.Security.Cryptography;
using ClassManagementWebApi.Entities;
using ClassManagementWebApi.Entities.Teacher;
using ClassManagementWebApi.src.Entities;
using Microsoft.EntityFrameworkCore;

namespace ClassManagementWebApi.src.Contexts
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<ClassSubject> ClassSubjects { get; set; }
        public DbSet<GraduationCourse> GraduationCourses { get; set; }
        public DbSet<Manager> Managers { get; set; }
        public DbSet<Register> Registers { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<ClassTime> ClassTimes { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasIndex(e => e.Email).IsUnique();
            modelBuilder.Entity<Manager>()
                .HasMany(e => e.ClassSubjects)
                .WithOne(e => e.Manager)
                .HasForeignKey(e => e.ManagerId)
                .HasPrincipalKey(e => e.ManagerId);

            modelBuilder.Entity<Teacher>()
                .HasMany(e => e.ClassSubjects)
                .WithMany(e => e.Teacher);

            modelBuilder.Entity<Admin>()
                .HasKey(e => e.Id);

           modelBuilder.Entity<ClassSubject>(entity =>
            {
                entity.HasOne(cs => cs.Manager)
                    .WithMany(m => m.ClassSubjects)
                    .HasForeignKey(cs => cs.ManagerId)
                    .OnDelete(DeleteBehavior.Restrict); // Prevent cascading deletes if needed

                entity.HasMany(cs => cs.Teacher)
                    .WithMany(t => t.ClassSubjects);
                });

            modelBuilder.Entity<Admin>().HasData(
                new Admin()
                {
                    Id=1,
                    CPF = "12345678",
                    Email = "eduarbaldin@gmail.com",
                    Password = "123456",
                    Name = "Admin Eduardo"
                });

            // Create users
            modelBuilder.Entity<User>().HasData(
                new User()
                {
                    Id=1,
                    CPF = "12345678",
                    Email = "eduarbaldin@gmail.com",
                    Password = "123456",
                    Name = "Admin",
                    Salt = "y9wrDdai3E=n",
                    Role = Roles.Admin,
                },
                new User()
                {
                    Id=2,
                    CPF = "12345678",
                    Email = "diretor@gmail.com",
                    Password = "123456",
                    Name = "Diretor Teste",
                    Salt = "y9wrDdai3E=k",
                    Role = Roles.Principal,
                });

            // Create teachers
            modelBuilder.Entity<Teacher>().HasData(
                new Teacher()
                {
                    TeacherId=1,
                    CPF = "12345678",
                    Email = "johanny@gmail.com",
                    Password = "123456",
                    Name = "Johanny",
                    Role = Roles.Teacher.ToString(),
                },
                new Teacher()
                {
                    TeacherId=2,
                    CPF = "12345678",
                    Email = "johan1ny@gmail.com",
                    Password = "123456",
                    Name = "Johanny",
                    Role = Roles.Teacher.ToString(),
                });


            // Create managers
            modelBuilder.Entity<Manager>().HasData(
                new Manager()
                {
                    ManagerId=1,
                    Name = "Cordenador Teste",
                    CPF = "12345678",
                    Email = "teste@gmail.com",
                    Password = "123456",
                });

            // Create class subjects
        modelBuilder.Entity<ClassSubject>().HasData(
    new ClassSubject
    {
        ClassSubjectId = 1,
        Name = "PowerBI",
        ManagerId = 1, // Ensure this matches the seeded ManagerId
        TeacherId=1,
    },
    new ClassSubject
    {
        ClassSubjectId = 2,
        Name = "PowerBI",
        ManagerId = 1, // Ensure this matches the seeded ManagerId
        TeacherId=2,
    }
);
        }
    }
}