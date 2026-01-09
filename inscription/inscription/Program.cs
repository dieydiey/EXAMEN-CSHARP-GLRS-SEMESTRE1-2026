// Program.cs
using Microsoft.EntityFrameworkCore;
using inscription.Data;
using inscription.Services;
using inscription.Services.Interfaces;
using inscription.Repository;
using inscription.Repository.Interfaces;
using inscription.Services.impl;
using inscription.Repositoriy.impl;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Configuration de la base de données avec Entity Framework
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")
    )
);

// Alternative avec SQLite pour développement:
// builder.Services.AddDbContext<ApplicationDbContext>(options =>
//     options.UseSqlite(
//         builder.Configuration.GetConnectionString("SQLiteConnection")
//     )
// );

// Correction : On lie l'Interface à sa Classe d'implémentation
builder.Services.AddScoped<IInscriptionRepositoryInterface, InscriptionRepositoryImpl>(); 
builder.Services.AddScoped<IInscriptionServiceInterface, InscriptionServiceImpl>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}
else
{
    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Inscription}/{action=Index}/{id?}");

// Initialiser la base de données
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        var context = services.GetRequiredService<AppDbContext>();
        context.Database.Migrate();
    }
    catch (Exception ex)
    {
        var logger = services.GetRequiredService<ILogger<Program>>();
        logger.LogError(ex, "Erreur lors de l'initialisation de la base de données.");
    }
}

app.Run();