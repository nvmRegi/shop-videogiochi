using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Shop_Videogiochi.Models
{
    [Table("Ordini")]
    [Index(nameof(Id), IsUnique = true)]
    public class Ordine
    {
        [Key]
        public int Id { get; set; }
        
        //[DataType(ErrorMessage = "Data non valida")]
        public DateTime Data { get; set; }

        [Required(ErrorMessage = "La quantità è obbligatoria")]
        public int Quantità { get; set; }

        //Foreign key videogioco
        
        public int VideogiocoId { get; set; }
        public Videogioco? Videogioco { get; set; }

        //costruttore 

        public Ordine()
        {

        }
    }
}
