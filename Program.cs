using Microsoft.EntityFrameworkCore;
using PortfolioWebsite.Data;

var builder = WebApplication.CreateBuilder(args);

// Lắng nghe cố định cổng 5000 (HTTP)
builder.WebHost.UseUrls("http://localhost:5000");

// EF Core + SQL Server
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection")
    ?? "Server=(localdb)\\MSSQLLocalDB;Database=PortfolioDb;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True";

builder.Services.AddDbContext<PortfolioContext>(opt =>
    opt.UseSqlServer(connectionString));

// API + Swagger
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// CORS (mở cho dev, gồm cả Live Server 127.0.0.1:5500)
builder.Services.AddCors(o =>
{
    o.AddPolicy("AllowAll", p => p
        .AllowAnyOrigin()
        .AllowAnyHeader()
        .AllowAnyMethod());
});

var app = builder.Build();

// Swagger luôn bật (kể cả khi ASPNETCORE_ENVIRONMENT=Production)
app.UseSwagger();
app.UseSwaggerUI();

// HTTP-only để tránh lỗi HTTPS khi chưa bind https
// app.UseHttpsRedirection();

app.UseCors("AllowAll");

// Phục vụ file tĩnh và tự tìm index.html trong wwwroot
app.UseDefaultFiles();
app.UseStaticFiles();

app.MapControllers();

// Tự migrate DB khi khởi động
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<PortfolioContext>();
    db.Database.Migrate();
}

app.Run();
