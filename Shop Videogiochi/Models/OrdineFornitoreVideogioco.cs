namespace Shop_Videogiochi.Models
{
    public class OrdineFornitoreVideogioco
    {
        public Videogioco? videogioco { get; set; }
        public OrdineFornitore ordineFornitore { get; set; }
    }
}
