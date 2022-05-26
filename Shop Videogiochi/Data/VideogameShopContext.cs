namespace Shop_Videogiochi.Data
{
    public DbSet<Categoria>? Categorie { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Data Source=localhost;Database=Shop_Videogiochi;Integrated Security=True");
    }
}
