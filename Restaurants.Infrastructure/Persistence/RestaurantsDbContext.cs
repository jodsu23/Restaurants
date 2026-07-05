using Microsoft.EntityFrameworkCore;
using Restaurants.Domain.Entities;

namespace Restaurants.Infrastructure.Persistence;

internal class RestaurantsDbContext : DbContext
{
    internal DbSet<Restaurant> Restaurants { get; set; }
    internal DbSet<Dish> Dishes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb; Database=RestaurantsDb;Trusted_Connection=True;");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Restaurant>()
            .OwnsOne(r => r.Address);

        modelBuilder.Entity<Restaurant>()
            .HasMany(r => r.Dishes)
            .WithOne()
            .HasForeignKey(d => d.RestaurantId);
    }


}

/*
Para instalar el EntityFramework debe ser en
el Restaurants.Infrastructure

Agregar package nuget
Microsoft.EntityFrameworkCore.SqlServer
version 8.0.0

Luego desde Restaurants.Infrastructure agregar una carpeta llamada: Persistence
Ademas agregar una clase llamada: RestaurantDbContext.cs

agregar la herencia a => : DbContext

luego se agregar la cadena de conexion (el codigo lo agregare a este texto luego) 
se debera instalar: Microsoft.EntityFrameworkCore.Tools version 8.0

Luego abrir la consola para agregar el siguiente comando:
ALERTA: en consola seleccionar en Default Project: Restaurant.Infrastructure

tools => nugget package managar => console package manager

ALERTA: Restaurants.Infrastructure seleccionar como : Set as StartUpProject

Luego agregar este comando para iniciar la Migracion:
add-migration Init

ALERT: como da error de primary key hay que agregsar esto en la clase dish
public int RestaurantId { get; set; }

agregar nuevamente el comando de migracion y listo

ALERT: Para ver la tabla refleja  
 */
