using Microsoft.EntityFrameworkCore;
using NegoSudLib.NegosudDbContext;

var builder = WebApplication.CreateBuilder(args);

//chaine de connexion
string connexionString = builder.Configuration.GetConnectionString("MainConnexionString") ??
    throw (new Exception("Connection string is missing"));

// On ajoute le contexte
builder.Services.AddDbContext<NegoSudDBContext>(options => options
        .UseMySql(connexionString, ServerVersion.AutoDetect(connexionString)));

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
