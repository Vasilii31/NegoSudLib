using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using NegoSudAPI.Middleware;
using NegoSudLib.DAO;
using NegoSudLib.Interfaces;
using NegoSudLib.NegosudDbContext;
using NegoSudLib.Repositories;
using NegoSudLib.Services;
using NLog.Extensions.Logging;

var builder = WebApplication.CreateBuilder(args);

// Ajout Autorisation via Identity
builder.Services.AddAuthentication(IdentityConstants.ApplicationScheme)
.AddIdentityCookies();

builder.Services.AddCors(options =>
{
	options.AddPolicy("AllowWebApp", builder =>
	{
		builder.WithOrigins("https://localhost:7070/")
			   .AllowAnyHeader()
			   .AllowAnyMethod()
			   .AllowCredentials(); // Allow cookies, if needed
	});
});

//builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
//    .AddCookie(options =>
//    {
//        options.LoginPath = "/Login";
//        options.Cookie.Name = ".AspNetCore.Identity.Application";
//        // Other cookie options...
//    });
builder.Services.AddAuthorizationBuilder();
builder.Services.AddIdentityCore<User>()
	.AddRoles<IdentityRole>()
	.AddEntityFrameworkStores<NegoSudDBContext>()
	.AddApiEndpoints();


// Add services to the container.
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//chaine de connexion
string connexionString = builder.Configuration.GetConnectionString("MainConnexionString") ??
	throw (new Exception("Connection string is missing"));

// On ajoute le contexte
builder.Services.AddDbContext<NegoSudDBContext>(options => options
		.UseMySql(connexionString, ServerVersion.AutoDetect(connexionString)));
//builder.Services.AddScoped<NegoSudDBContext>();
// On ajoute les services nécessaires
builder.Services.AddScoped<IRolesService, RolesService>();
builder.Services.AddScoped<ISeedService, SeedService>();
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
builder.Services.AddScoped<IInventaireService, InventaireService>();
builder.Services.AddScoped<IInventaireRepository, InventaireRepository>();

// Configuration nLog
builder.Logging.ClearProviders();
builder.Logging.AddNLog("NLog.config");

var app = builder.Build();

app.MapIdentityApi<User>();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}
app.UseCors("AllowWebApp");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();


app.UseMiddleware<LoggingMiddleware>();

app.Run();
