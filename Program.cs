using Microsoft.EntityFrameworkCore;
using Unitofwork.Data;
using Unitofwork.Repository.Implementation;
using Unitofwork.Repository.Interface;
using Unitofwork.Service;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<TestDBContext>(options=>
    options.UseSqlServer(builder.Configuration.GetConnectionString("appconnection")));

builder.Services.AddScoped<IOrderheaderrepository, Orderheaderrepository>();
builder.Services.AddScoped<IOrderItemrepository, OrderItemRepository>();
builder.Services.AddScoped<IUnitofWork, UnitofWork>();
builder.Services.AddScoped<IOrderService, OrderService>();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi(); 
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
