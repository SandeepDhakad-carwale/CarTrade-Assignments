

using AutoMapper;
using Cars.Domains;
using Cars.DAL.Repositories;
using Cars.DAL.Data;
using Cars.BLL.Services;
using Cars.BLL.Mapping;
using Cars.Api.Middlewares;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Register DatabaseContext with connection string
builder.Services.AddSingleton<DatabaseContext>(sp =>
    new DatabaseContext(builder.Configuration.GetConnectionString("DefaultConnection")));

// Register repositories and services
builder.Services.AddScoped<IStockRepository, StockRepository>();
builder.Services.AddScoped<IStockService, StockService>();


// Add AutoMapper for DTO mapping
builder.Services.AddAutoMapper(cfg => cfg.AddProfile<MappingProfile>(), typeof(MappingProfile).Assembly);


// Add Swagger for API documentation
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

app.UseMiddleware<GlobalExceptionMiddleware>();

app.MapControllers();

app.Run();

