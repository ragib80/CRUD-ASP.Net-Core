using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using RetailerAPI.Data;
using RetailerAPI.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<RetailerDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("RetailerConnectionString")));

builder.Services.AddScoped<IRetailerRepository, SQLRetailerRepository>();

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
