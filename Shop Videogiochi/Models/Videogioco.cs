﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Shop_Videogiochi.Models
{

    public class PacchettoViaggio
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Il nome del videogioco è obbligatorio")]
        public int Categoria_id { get; set; }

        [Required(ErrorMessage = "Il nome del videogioco è obbligatorio")]
        [StringLength(50, ErrorMessage = "Il nome del pacchetto non può contenere più di 50 caratteri")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "E' obbligatorio inserire l'URL dell'immagine")]
        [Url(ErrorMessage = "URL non valido")]
        public string Foto { get; set; }

        [Required(ErrorMessage = "La descrizione del videogioco è obbligatoria")]
        public string Descrizione { get; set; }

        [Required(ErrorMessage = "E' necessario inserire il costo del pacchetto")]
        public double Prezzo   { get; set; }

        
        public int Like { get; set; }


        public int Disponibilità { get; set; }

        //costruttore

        public Videogioco()
        { }

        public Videogioco(int Id, int Categoria_id, string Nome, string Foto, string Descrizione, double Prezzo, int Disponibilità)
        {
            this.Id = Id;
            this.Categoria_id = Categoria_id;
            this.Nome = Nome;
            this.Foto = Foto;
            this.Descrizione = Descrizione;
            this.Prezzo = Prezzo;
            this.Disponibilità = Disponibilità;
        }













    }
}