using Microsoft.EntityFrameworkCore;
using NominaAPI;
using NominaAPI.Data;
using NominaAPI.Repository;
using NominaAPI.Services;
using SharedModels;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<NominaContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("Default"));
});

builder.Services.AddAutoMapper(typeof(MappingConfig));
builder.Services.AddControllers().AddNewtonsoftJson();

builder.Services.AddScoped<Repository<User>>();
builder.Services.AddScoped<Repository<Ingresos>>();
builder.Services.AddScoped<Repository<Empleado>>();
builder.Services.AddScoped<Repository<Deducciones>>();
builder.Services.AddScoped<Repository<Nomina>>();

builder.Services.AddControllers();
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