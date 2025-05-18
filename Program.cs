using FileExchangerAPI.ActionClass;
using FileExchangerAPI.Interface;
using FileExchangerAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Formats.Asn1;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("ConnectDb");
builder.Services.AddDbContext<FileExchangeDbContext>(options => options.UseSqlServer(connectionString));

// Add services to the container.
builder.Services.AddTransient<IUser, UserClass>();
builder.Services.AddTransient<IFile, FileClass>();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
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

app.MapControllers();

app.Run();
