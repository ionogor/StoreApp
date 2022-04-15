using Microsoft.EntityFrameworkCore;
using StoreApp.Bll.Interfaces;
using StoreApp.Bll.Services;
using StoreApp.Common.Profiles;
using StoreApp.Data.Context;
using StoreApp.Data.Interfaces;
using StoreApp.Data.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
  builder.Services.AddDbContext<GlobalContext>(options =>
  options.UseSqlServer(builder.Configuration.GetConnectionString("Default")));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped(typeof(IRepository<>),typeof(EfCoreRepository<>));
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddAutoMapper(typeof(ProductProfile));
builder.Services.AddScoped<IProductService,ProductService>();

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
