using DotNetEnv;
using EnerGov.WebApi.EfCore;
using EnerGov.WebApi.Helper;
using EnerGov.WebApi.Interface;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
Env.Load();
// DotNetEnv.Env.Load();
string connectionString = $"Host={Env.GetString("Host")};Database={Env.GetString("DatabaseName")};Port={Env.GetString("DatabasePort")};Username={Env.GetString("MasterUsername")};Password={Env.GetString("MasterPassword")};";
builder.Services.AddDbContext<EF_DataContext>(options =>
{
    options.UseNpgsql(connectionString);
});
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IDbHelper, DbHelper>();
builder.Services.AddCors(options =>
{
    options.AddPolicy(
        name: "AllowOrigin",
        builder => {
            builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader();
        });
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("AllowOrigin");

app.UseAuthorization();

app.MapControllers();

app.MigrateDatabase();
app.Run();
