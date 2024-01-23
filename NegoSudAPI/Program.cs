using NegoSudAPI.Middleware;
using NegoSudLib.Interfaces;
using NegoSudLib.NegosudDbContext;
using NegoSudLib.Repositories;
using NegoSudLib.Services;
using NLog.Extensions.Logging;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// On ajoute le contexte
builder.Services.AddScoped<NegoSudDBContext>();
// On ajoute les services nécessaires
builder.Services.AddScoped<IProduitsRepository, ProduitsRepository>();
builder.Services.AddScoped<IProduitsServices, ProduitService>();
builder.Services.AddScoped<IPrixRepository, PrixRepository>();
builder.Services.AddScoped<IPrixService, PrixService>();
builder.Services.AddScoped<IEmployesRepository, EmployesRepository>();
builder.Services.AddScoped<IEmployesService, EmployesService>();
builder.Services.AddScoped<IClientRepository, ClientRepository>();
builder.Services.AddScoped<IClientService, ClientService>();
builder.Services.AddScoped<IDetailMvtRepository, DetailMvtRepository>();
builder.Services.AddScoped<IDetailMvtService, DetailMvtService>();
builder.Services.AddScoped<ICommandesRepository, CommandesRepository>();
builder.Services.AddScoped<ICommandesService, CommandesService>();
builder.Services.AddScoped<IVentesRepository, VentesRepository>();
builder.Services.AddScoped<IVentesService, VentesService>();
builder.Services.AddScoped<IAutreMvtRepository, AutreMvtRepository>();
builder.Services.AddScoped<IAutreMvtService, AutreMvtService>();

// Configuration nLog
builder.Logging.ClearProviders();
builder.Logging.AddNLog("NLog.config");

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

app.UseMiddleware<LoggingMiddleware>();

app.Run();
