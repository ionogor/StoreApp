using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using StoreApp.Bll.Interfaces;
using StoreApp.Bll.Repositories;
using StoreApp.Bll.Services;
using StoreApp.Common.Profiles;
using StoreApp.Data.Context;
using StoreApp.Data.Interfaces;
using StoreApp.Data.Repository;
using StoreApp.Helpers;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddCors(options =>
{
    options.AddPolicy("CORSPolicy",
        builder =>
        {
            builder
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader()
            .AllowCredentials()
            .WithOrigins("http://localhost:3000", "https://appname.azurestaticapps.net");
        });
});
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
app.UseAuthentication();
app.UseAuthorization();
//app.UseCors(options => options

//                .AllowAnyOrigin()
//                 .AllowAnyMethod()
//                .AllowAnyHeader()
//                .AllowCredentials()
//                .WithOrigins(new[] { "http://localhost:3000", "http://localhost:8090" })
//);



app.UseCors("CORSPolicy");
app.UseDefaultFiles();
app.UseStaticFiles();
//app.UseMiddleware<ErrorMiddleware>();
//app.UseMiddleware<Authentification>();
//app.UseMiddleware<Routing>();
app.UseHttpsRedirection();
app.UseDefaultFiles();
app.UseStaticFiles();
app.UseRouting();

app.MapControllers();


app.Run();
