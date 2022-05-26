using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shop_Videogiochi.Models
{
    [Table("Categoria")]
    [Index(nameof(Id), IsUnique = true)]
    public class Categoria
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Il tema del videogioco")]
        [StringLength(30, ErrorMessage = "Il tema non può avere più di ")]
        public string Tema { get; set; }

        public List<Videogioco> Videogiochi { get; set; }


        public Categoria()
        {

        }

        //Non metto l'id nel costruttore perchè sarà presente nel database
        public Categoria(string Tema)
        {
            this.Tema = Tema;
        }
    }

}
