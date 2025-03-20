using lojaDoDot.infra.data;
using lojaDoDot.infra.service;
using lojaDoDot.infra.service.impl;
using lojaDoDot.infra.controller;
using Microsoft.EntityFrameworkCore;
using Openapi;
using lojaDoDot.infra.data.repository;
using lojaDoDot.infra.data.repository.impl;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddOpenApi();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseInMemoryDatabase("TestDatabase"));

builder.Services.AddScoped<IUserRepository, UserRepositoy>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();

builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IProductService, ProductService>();

builder.Services.AddScoped<IController, Presentation>();
builder.Services.AddControllers();
builder.Services.AddHttpClient<AccountApi.ApiClient>(client =>
{
    client.BaseAddress = new Uri("https://localhost:7000/");
});

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
var app = builder.Build();

app.MapOpenApi();
app.UseHttpsRedirection();
app.MapControllers();
app.Run();
