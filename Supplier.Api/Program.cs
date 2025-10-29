using Microsoft.EntityFrameworkCore;
using Supplier.Infrastructure.Data;
using Supplier.Infrastructure.Repositories;
using Supplier.Domain.Repositories;
using Supplier.Application.Interfaces;
using Supplier.Application.Services;
using Supplier.Application.Profiles;
using AutoMapper;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Supplier API",
        Version = "v1",
        Description = "API para gerenciamento de fornecedores (CRUD)"
    });
});


var mapperConfigExpr = new MapperConfigurationExpression();
mapperConfigExpr.AddProfile<SupplierProfile>();

var loggerFactory = LoggerFactory.Create(builder => builder.AddConsole());
var mapperConfiguration = new MapperConfiguration(mapperConfigExpr, loggerFactory);

IMapper mapper = new Mapper(mapperConfiguration);
builder.Services.AddSingleton(mapper);

builder.Services.AddDbContext<SupplierDbContext>(opt =>
    opt.UseSqlite("Data Source=suppliers.db"));

builder.Services.AddScoped<ISupplierRepository, SupplierRepository>();
builder.Services.AddScoped<ISupplierService, SupplierService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();
app.Run();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<SupplierDbContext>();
    db.Database.Migrate();
}
