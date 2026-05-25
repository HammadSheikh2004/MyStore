using Microsoft.EntityFrameworkCore;
using MinimalAPI.CollectionExtension;
using MinimalAPI.DbContextClass;
using MinimalAPI.EndPoints;
using MinimalAPI.Repository;
using MinimalAPI.Services;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);
var connectionName = builder.Configuration.GetConnectionString("MyConn");
builder.Services.AddDbContext<MyDbContext>(options => options.UseNpgsql(connectionName));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.APIServiceCollection();   

var app = builder.Build();
app.UseStaticFiles();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "MyStore API");
    });
}

app.UseHttpsRedirection();

app.APIEndpointsCollection();
app.Run();

