using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;
using PharmacyAPI.Data;
using PharmacyAPI.Data.Repositories;
using PharmacyAPI.Data.Repositories.Interfaces;
using PharmacyAPI.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder
    .Services.AddControllers()
    .AddJsonOptions(x => x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("YourConnectionString"));
});

// Repositories
builder.Services.AddScoped<ISeederRepository, SeederRepository>();
builder.Services.AddScoped(typeof(IRepository<>), typeof(GenericRepository<>));

// Services
builder.Services.AddScoped<UserService>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
