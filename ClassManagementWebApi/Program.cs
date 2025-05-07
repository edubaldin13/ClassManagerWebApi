using System.Text;
using ClassManagementWebApi.src.Configs.AutoMapper;
using ClassManagementWebApi.src.Contexts;
using ClassManagementWebApi.src.Repositories;
using ClassManagementWebApi.src.Repositories.Authentication;
using ClassManagementWebApi.src.Repositories.GraduationCourse;
using ClassManagementWebApi.src.Repositories.Manager;
using ClassManagementWebApi.src.Repositories.Register;
using ClassManagementWebApi.src.Repositories.Teacher;
using ClassManagementWebApi.src.Repositories.User;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Serilog;
using Npgsql;
//using Npgsql.EntityFrameworkCore.PostgreSQL;

Environment.SetEnvironmentVariable("ASPNETCORE_ENVIRONMENT", "Development");
Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .CreateLogger();
var builder = WebApplication.CreateBuilder(args);          
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(connectionString));
// builder.Services.AddCors(options => {
//     options.AddDefaultPolicy(
//         policy => {
//             policy.WithOrigins("http://localhost:4200", "http://localhost:5000");
//         }
//     );
// });
builder.Services.AddCors(options =>
        {
            // this defines a CORS policy called "default"
            options.AddPolicy("default", policy =>
            {
                policy.AllowAnyOrigin()
                    .AllowAnyHeader()
                    .AllowAnyMethod();
            });
        });  
builder.Services.AddSerilog();
builder.Services.AddMvc();
builder.Services.AddControllers(option => { 
}).AddNewtonsoftJson().AddXmlDataContractSerializerFormatters();
builder.Services.AddScoped<IAuthenticationRepository, AuthenticationRepository>();
builder.Services.AddScoped<IGraduationCourseRepository, GraduationCourseRepository>();
builder.Services.AddScoped<ITeacherRepository, TeacherRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IRegisterRepository, RegisterRepository>();
builder.Services.AddScoped<IManagerRepository, ManagerRepository>();
builder.Services.AddAutoMapper(typeof(MappingConfig));
var key = builder.Configuration.GetValue<string>("ApiSettings:Secret");
builder.Services.AddAuthentication(options => 
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(x =>
{
    x.RequireHttpsMetadata = false;
    x.SaveToken = true;
    x.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(key)),
        ValidateIssuer = false,
        ValidateAudience = false,
        ValidateLifetime = true
    };
    x.Events = new JwtBearerEvents
    {
        OnMessageReceived = context =>
        {
            var token = context.Request.Headers.Authorization.FirstOrDefault()?.Split(" ").Last();
            if(token == null || token == "null")
            {
                context.NoResult();
                return Task.CompletedTask;
            }
                return Task.CompletedTask;
        },
        OnAuthenticationFailed = context =>
        {
            if (context.Exception.GetType() == typeof(SecurityTokenMalformedException))
            {
                context.NoResult();
                context.Response.StatusCode = 401;
                context.Response.ContentType = "text/plain";
                return context.Response.WriteAsync("Invalid token.");
            }
            return Task.CompletedTask;
        }
    };
});
// builder.Services.AddAuthorization();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// builder.Services.AddControllers();
var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}else{
    app.UseHttpsRedirection();
}
app.UseCors("default");
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run("http://localhost:5001");