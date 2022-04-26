using Microsoft.EntityFrameworkCore;
using StoreApp.Bll.Interfaces;
using StoreApp.Bll.Repositories;
using StoreApp.Bll.Services;
using StoreApp.Common.Profiles;
using StoreApp.Data.Context;
using StoreApp.Data.Interfaces;
using StoreApp.Data.Repository;
using StoreApp.Helpers;
using StoreApp.Infrastucture.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

  builder.Services.AddDbContext<GlobalContext>(options =>
  options.UseSqlServer(builder.Configuration.GetConnectionString("Default")));

builder.Services.AddControllers();

builder.Services.AddCors();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped(typeof(IRepository<>),typeof(EfCoreRepository<>));
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddAutoMapper(typeof(ProductProfile));
builder.Services.AddAutoMapper(typeof(UserProfile));
builder.Services.AddScoped<IProductService,ProductService>();
builder.Services.AddScoped<ICatalogService,CatalogService>();
builder.Services.AddScoped<JwtService>();

builder.Services.AddScoped<IUserRepository, UserRepository>();

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
app.UseRouting();

app.UseCors(options => options
                .WithOrigins(new []{"http://localhost:3000","http://localhost:8080","http://localhost:4200"})
                .AllowAnyHeader()
                .AllowAnyMethod()
                .AllowCredentials()

);
app.UseAuthorization();

app.MapControllers();


app.Run();
