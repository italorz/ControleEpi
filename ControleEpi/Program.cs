using ControleEpi.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);
var conexao = builder.Configuration.GetConnectionString("conexao");

// Add services to the container.

builder.Services.AddControllers()
    .AddJsonOptions(ops => ops
    .JsonSerializerOptions.ReferenceHandler = 
    ReferenceHandler.IgnoreCycles);

builder.Services.AddDbContext<AppdbContext>(options => options.UseMySql(conexao, ServerVersion.AutoDetect(conexao)));
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
