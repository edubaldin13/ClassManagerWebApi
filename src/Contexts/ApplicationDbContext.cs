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
    }
    //model creating to seed tables
    // protected override void OnModelCreating(ModelBuilder modelBuilder)
    // {
    //     modelBuilder.Entity<Admin>().HasData(
    //     new Admin()
    //     {
    //         Id = 1,
    //         CPF = "12345678",
    //         Email = "eduarbaldin@gmail.com",
    //         Password = "123456",
    //         Name = "Admin"
    //     });
    // }
}
