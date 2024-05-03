using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using w.sale.car.api.Utils;
using w.sale.car.db;
using w.sale.car.db.Dtos;
using w.sale.car.db.Repository;
using w.sale.car.db.Repository.Impl;
using w.sale.car.services;



var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("SchemaName");


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

// Add services to the container.
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connectionString));

//add Repositorio generico
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

builder.Services.AddScoped<IReserveService, ReserveService>();
builder.Services.AddScoped<ILocationService, LocationService>();
builder.Services.AddScoped<ICarService, CarService>();
builder.Services.AddScoped<IUserService, UserService>();

//add validadores
builder.Services.AddScoped<IValidator<LocationInDto>, LocationValidator>();
builder.Services.AddScoped<IValidator<ReserveInDto>, ReserveValidator>();
builder.Services.AddScoped<IValidator<CarInDto>, CarValidator>();
builder.Services.AddScoped<IValidator<UserInDto>, UserValidator>();
builder.Services.AddScoped<IValidator<SaleInDto>, SaleValidator>();

builder.Services.AddSwaggerGen();

string cors = "Cors";
builder.Services.AddCors(options => {
options.AddPolicy(name:cors, 
                  build =>
                  {
                      build.WithOrigins("*");
                      build.AllowAnyMethod();
                      build.AllowAnyHeader();

                  });
});

builder.Services.AddMvc().AddJsonOptions( options => {
    options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(cors);

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
