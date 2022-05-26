using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shop_Videogiochi.Models
{
    [Table("Ordini")]
    [Index(nameof(Id), IsUnique = true)]
    public class Ordine
    {
        [Key]
        public int Id { get; set; }
        
        [Required(ErrorMessage = "Il nome del videogioco è obbligatorio")]
        public int Videogame_id { get; set; }

        [Required(ErrorMessage = "E' obbligatorio inserire la data dell'ordine")]
        //[DataType(ErrorMessage = "Data non valida")]
        public DateTime Data { get; set; }

        [Required(ErrorMessage = "La quantità è obbligatoria")]
        public int Quantità { get; set; }

        [Required(ErrorMessage = "Il nome del fornitore è obbligatorio")]
        [StringLength(50, ErrorMessage = "Il nome del fornitore non può contenere più di 50 caratteri")]
        public string? NomeFornitore { get; set; }

        //Foreign key videogioco
        public int VideogiocoId { get; set; }
        public Videogioco Videogioco { get; set; }


        //costruttore 

        public Ordine()
        {

        }

        public Ordine ( int Id, int Videogame_id , DateTime Data , int Quantità , string Nome )
        {
            this.Id = Id;
            this.Videogame_id = Videogame_id;
            this.Data = Data;
            this.Quantità = Quantità;
            this.NomeFornitore = Nome;
            
        }
    }
}
