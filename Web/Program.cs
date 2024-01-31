using Application.Services;
using Domain.Options;
using Domain.Requests;
using Domain.Validators;
using Infrastructure.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Net.Sockets;
using Web.Middlewares;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<ClassOptions>(
    builder.Configuration.GetSection(ClassOptions.Section));

builder.Services.AddCors(config =>
{
    config.AddPolicy("AllowOrigin", option => option.AllowAnyOrigin()
                                                    .AllowAnyMethod());
});

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IValidator<BaseUserRequest>, UserValidator>();
builder.Services.AddSingleton<IUserRepository, UserRepository>();

builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IValidator<BaseProductRequest>, ProductValidator>();
builder.Services.AddSingleton<IProductRepository, ProductRepository>();

var app = builder.Build();

app.UseMiddleware<ExceptionMiddleware>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowOrigin");

//app.UseMiddleware<ApiKeyMiddleware>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
