using class_management_web_api.src.Entities;
using Microsoft.EntityFrameworkCore;

namespace class_management_web_api.src.Contexts
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<ClassSubject> ClassSubjects { get; set; }
        public DbSet<ClassTime> ClassTime { get; set; }
        public DbSet<Manager> Managers { get; set; }
        public DbSet<Principal> Principals { get; set; }
        public DbSet<Register> Registers { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<User> Users { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Manager>()
            .HasMany(e => e.ClassSubjects)
            .WithOne(e => e.Manager)
            .HasForeignKey(e => e.ManagerId)
            .HasPrincipalKey(e => e.ManagerId);

            modelBuilder.Entity<Teacher>()
            .HasMany(e => e.ClassSubjects)
            .WithOne(e => e.Teacher)
            .HasForeignKey(e => e.TeacherId)
            .HasPrincipalKey(e => e.TeacherId);
            //criar admin
            modelBuilder.Entity<Admin>().HasData(
            new Admin()
            {
                Id = Guid.NewGuid(),
                CPF = "12345678",
                Email = "eduarbaldin@gmail.com",
                Password = "123456",
                Name = "Admin"
            });
            //criar user
            modelBuilder.Entity<User>().HasData(
            new User()
            {
                Id = Guid.NewGuid(),
                CPF = "12345678",
                Email = "eduarbaldin@gmail.com",
                Password = "123456",
                Name = "Admin",
                Salt = "y9wrDdai3E=n",
                Role = Role.Admin,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            });
            //criar teacher
            modelBuilder.Entity<Teacher>().HasData(
            new Teacher()
            {
                TeacherId = Guid.Parse("ee6393f2-abfe-47e6-8186-bc08bc4a4cd0"),
                CPF = "12345678",
                Email = "eduarbaldin@gmail.com",
                Password = "123456",
                Name = "Teacher Teste",
                Role = Role.Teacher.ToString(),
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            });
            //criar classSubject
            modelBuilder.Entity<Manager>().HasData(
                new Manager()
                {
                    ManagerId = Guid.Parse("97f31c66-6114-487a-a364-fcd2659c01a1"),
                    Name = "Cordenador Teste",
                    CPF = "12345678",
                    Email = "eduarbaldin@gmail.com",
                    Password = "123456",
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                }
            );
            //criar classSubject
            modelBuilder.Entity<ClassSubject>().HasData(
                new ClassSubject()
                {
                    ClassSubjectId = Guid.NewGuid(),
                    Name = "Materia Teste",
                    ManagerId = Guid.Parse("97f31c66-6114-487a-a364-fcd2659c01a1"),
                    TeacherId = Guid.Parse("ee6393f2-abfe-47e6-8186-bc08bc4a4cd0"),
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                }
            );
        }
    }
}
//#TODO ja criei o relacionamento dos professores com a materia e dos cordenadores com a materia
//#TODO criar rotas para inserção de cordenadores e aulas -> core do sistema
//crair front end pra isso (creio que será + rápido que o back)