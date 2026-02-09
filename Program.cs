using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using VirtualPlanetarium.CodeFirst;

var builder = Host.CreateApplicationBuilder(args);

var connectionString = "Server=localhost;Database=VirtualPlanetariumCodeFirstDb;Trusted_Connection=True;TrustServerCertificate=True;";

builder.Services.AddDbContext<PlanetariumDbContext>(options =>
    options.UseSqlServer(connectionString));

var host = builder.Build();

Console.WriteLine("Code-First проект успішно налаштовано!.");