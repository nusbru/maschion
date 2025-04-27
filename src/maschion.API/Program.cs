using Microsoft.EntityFrameworkCore;
using maschion.API.Data;
using Scalar.AspNetCore;
using maschion.API.Endpoints;
using maschion.API.Infrastructure;
using DotNetEnv;

Env.Load();

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddOpenApi();

builder.Services.AddDbContext<MaschionDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

var url = Environment.GetEnvironmentVariable("SUPABASE_URL");
var key = Environment.GetEnvironmentVariable("SUPABASE_KEY");

builder.Services.AddSingleton<Supabase.Client>(provider => new Supabase.Client(url, key));

builder.Services.AddScoped<ISupabaseRepository, SupabaseRepository>();
var app = builder.Build();

app.MapScalarApiReference(endpointPrefix: "/api-reference");
app.MapOpenApi();

app.MapAuthEndpoints();

app.Run();