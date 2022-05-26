using System.ComponentModel.DataAnnotations;

namespace Shop_Videogiochi.Models
{
    public class Categoria
    {
        [Key]
        public int Id { get; set; } 
        [Required(ErrorMessage = "Il tema del videogioco")]
        [StringLength(30,ErrorMessage = "Il tema non può avere più di ")]
        public string Tema { get; set; }
    }
}
