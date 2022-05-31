namespace Shop_Videogiochi.Models
{
    public class VideogiocoCategoria
    {
        public Videogioco videogioco { get; set; }
        public List<Categoria>? categoria { get; set; }
    }
}
