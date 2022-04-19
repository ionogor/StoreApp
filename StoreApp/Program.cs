using Microsoft.EntityFrameworkCore;
using StoreApp.Bll.Interfaces;
using StoreApp.Bll.Services;
using StoreApp.Common.Profiles;
using StoreApp.Data.Context;
using StoreApp.Data.Interfaces;
using StoreApp.Data.Repository;
using StoreApp.Infrastucture.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
  builder.Services.AddDbContext<GlobalContext>(options =>
  options.UseSqlServer(builder.Configuration.GetConnectionString("Default")));

builder.Services.AddControllers();


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped(typeof(IRepository<>),typeof(EfCoreRepository<>));
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddAutoMapper(typeof(ProductProfile));
builder.Services.AddScoped<IProductService,ProductService>();
builder.Services.AddScoped<ICatalogService,CatalogService>();

var app = builder.Build();

//app.UseMiddleware<ErrorHandlingMiddleware>(); // Middleware custom

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

}
app.UseDefaultFiles();
app.UseStaticFiles();

//app.UseMiddleware<ErrorMiddleware>();
//app.UseMiddleware<Authentification>();
//app.UseMiddleware<Routing>();


app.UseHttpsRedirection();
app.UseDefaultFiles();
app.UseStaticFiles();

app.UseAuthorization();

app.MapControllers();


app.Run();
