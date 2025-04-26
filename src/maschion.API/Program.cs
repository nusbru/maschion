using Microsoft.EntityFrameworkCore;
using maschion.API.Data;
using Scalar.AspNetCore;
using maschion.API.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddOpenApi();

builder.Services.AddDbContext<MaschionDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

app.MapScalarApiReference(endpointPrefix: "/api-reference");
app.MapOpenApi();

app.MapGet("/ping", () => "Pong!");


app.Run();