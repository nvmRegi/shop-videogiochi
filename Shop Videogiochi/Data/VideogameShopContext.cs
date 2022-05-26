using Microsoft.EntityFrameworkCore;
using Shop_Videogiochi.Models;

namespace Shop_Videogiochi.Data
{
    public class VideogameShopContext : DbContext
    { 
        DbSet<Categoria> Categorie { get; set; }
        DbSet<Videogioco> Videogiochi { get; set; }
        DbSet<Ordine> Ordini { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=localhost;Database=Shop_Videogiochi;Integrated Security=True");
        }
    }
}
