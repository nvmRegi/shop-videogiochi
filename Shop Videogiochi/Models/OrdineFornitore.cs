using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shop_Videogiochi.Models
{
    [Table("OrdiniFornitore")]
    [Index(nameof(Id), IsUnique = true)]
    public class OrdineFornitore
    {
        [Key]
        public int Id { get; set; }

        public DateTime Data { get; set; }

        [Required(ErrorMessage = "La quantità è obbligatoria")]
        public int Quantità { get; set; }

        [Required(ErrorMessage = "Il nome del fornitore è obbligatorio")]
        [StringLength(50, ErrorMessage = "Il nome del fornitore non può contenere più di 50 caratteri")]
        public string NomeFornitore { get; set; }

        //Foreign key videogioco
        public int VideogiocoId { get; set; }
        public Videogioco? Videogioco { get; set; }


        //costruttore 

        public OrdineFornitore()
        {

        }
    }
}
