using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Shop_Videogiochi.Data;
using System.Text.Json.Serialization;

namespace Shop_Videogiochi.Models
{
    [Table("Videogiochi")]
    [Index(nameof(Id), IsUnique = true)]
    public class Videogioco
    {
        [Key]
        public int Id { get; set; }


        [Required(ErrorMessage = "Il nome del videogioco è obbligatorio")]
        [StringLength(50, ErrorMessage = "Il nome del pacchetto non può contenere più di 50 caratteri")]
        public string Nome { get; set; }


        [Required(ErrorMessage = "E' obbligatorio inserire l'URL dell'immagine")]
        [Url(ErrorMessage = "URL non valido")]
        public string Foto { get; set; }


        [Required(ErrorMessage = "La descrizione del videogioco è obbligatoria")]
        [StringLength(4000, ErrorMessage = "La descrizione del Videogioco non può contenere più di 4000 caratteri")]
        public string Descrizione { get; set; }


        [Required(ErrorMessage = "E' necessario inserire il costo del prodotto")]
        [Range(0, 500, ErrorMessage = "Il prezzo del prodotto dev'essere inferiore a 500€")]
        public double Prezzo{ get; set; }

        public int? MiPiace { get; set; }

        //foreign key Categoria
        public int? CategoriaId { get; set; }

        public Categoria? Categoria { get; set; }

        //collegamento 1 a molti con ordini
        [JsonIgnore]
        public List<Ordine>? Ordini { get; set; }

        [JsonIgnore]
        public List<OrdineFornitore>? OrdiniFornitore { get; set; }

        private int Disponibilità;

        //costruttore

        public Videogioco()
        {

        }

        public Videogioco(string Nome, string Foto, string Descrizione, double Prezzo)
        {
            this.Nome = Nome;
            this.Foto = Foto;
            this.Descrizione = Descrizione;
            this.Prezzo = Prezzo;
        }

        public int GetDisponibilità()
        {
            Disponibilità = 0;
            using(VideogameShopContext db = new VideogameShopContext())
            {
                List<OrdineFornitore> listaOrdiniFornitore = db.OrdiniFornitore.Where(ordine => ordine.VideogiocoId == Id).ToList();
                List<Ordine> listaOrdini = db.Ordini.Where(ordine => ordine.VideogiocoId == Id).ToList();
                
                foreach(OrdineFornitore ordine in listaOrdiniFornitore)
                {
                    Disponibilità += ordine.Quantità;
                }
                foreach(Ordine ordine in listaOrdini)
                {
                    Disponibilità -= ordine.Quantità;
                }
            }
            return Disponibilità;
        }
    }
}