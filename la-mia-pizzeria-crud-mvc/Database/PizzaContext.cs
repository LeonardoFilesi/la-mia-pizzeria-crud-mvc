﻿using Microsoft.EntityFrameworkCore;  // non generato, aggiunto a mano da me
using la_mia_pizzeria_crud_mvc.Models;   // non generato, aggiunto a mano da me

namespace la_mia_pizzeria_crud_mvc.Database
{
    public class PizzaContext : DbContext
    {
        public DbSet<Pizza> Pizzas { get; set; }

        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=localhost;Integrated Security=True");
        }
        // QUESTO METODO ^^^^^^^^^ IMPOSTA LA STRINGA DI CONNESSIONE
    }
}