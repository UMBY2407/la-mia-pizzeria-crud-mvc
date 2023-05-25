using LaMiaPizzeria.Models;
using Microsoft.EntityFrameworkCore;

namespace LaMiaPizzeria.Database
{
    public class PizzeriaContext : DbContext
    {
        public DbSet<Pizza> Pizzas { get; set; }
        public DbSet<PizzaCategory> PizzaCategories { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=PC-DI-UMBERTO\\MSSQLSERVER15;Initial Catalog=EFPizzeria;" + "Integrated Security=True;TrustServerCertificate=True");
        }
    }
}
