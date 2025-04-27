using Microsoft.EntityFrameworkCore;
using maschion.API.Data;
using Scalar.AspNetCore;
using maschion.API.Endpoints;
using maschion.API.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddOpenApi();

builder.Services.AddDbContext<MaschionDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

var url = builder.Configuration.GetValue<string>("Supabase:Url");
var key = builder.Configuration.GetValue<string>("Supabase:Key");

builder.Services.AddSingleton<Supabase.Client>(provider => new Supabase.Client(url, key));

builder.Services.AddScoped<ISupabaseRepository, SupabaseRepository>();
var app = builder.Build();

app.MapScalarApiReference(endpointPrefix: "/api-reference");
app.MapOpenApi();

app.MapAuthEndpoints();

app.Run();