using Microsoft.EntityFrameworkCore;
using Shop_Videogiochi.Models;

namespace Shop_Videogiochi.Data
{
    public class VideogameShopContext : DbContext
    { 
        public DbSet<Categoria> Categorie { get; set; }
        public DbSet<Videogioco> Videogiochi { get; set; }
        public DbSet<Ordine> Ordini { get; set; }
        public DbSet<OrdineFornitore> OrdiniFornitore { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=localhost;Database=Shop_Videogiochi;Integrated Security=True");
        }
    }
}
