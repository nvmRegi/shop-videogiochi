using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Shop_Videogiochi.Data;
using Shop_Videogiochi.Models;

namespace Shop_Videogiochi.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }


        // ------------------------------------------- Modifica Videogioco -------------------------------------------------

        [HttpGet]
        public IActionResult Aggiorna(int id)
        {
            Videogioco videogiocoDaModificare = null;

            using (VideogameShopContext db = new VideogameShopContext())
            {

                videogiocoDaModificare = db.Videogiochi
                              .Where(PacchettoViaggio => PacchettoViaggio.Id == id)
                              .First();
            }

            if (videogiocoDaModificare == null)
            {
                return NotFound();
            }
            else
            {
                return View("Index", videogiocoDaModificare);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Aggiorna(int id, Videogioco modello)
        {
            if (!ModelState.IsValid)
            {
                return View("AggiornaPacchetto", modello);
            }

            Videogioco VideogiocoDaModificare = null;

            using (VideogameShopContext db = new VideogameShopContext())
            {
                VideogiocoDaModificare = db.Videogiochi
                      .Where(Pizza => Pizza.Id == id)
                      .First();

                if (VideogiocoDaModificare != null)
                {
                    //aggiorniamo i campi con i nuovi valori
                    VideogiocoDaModificare.Nome = modello.Nome;
                    VideogiocoDaModificare.Foto = modello.Foto;
                    VideogiocoDaModificare.Descrizione = modello.Descrizione;
                    VideogiocoDaModificare.Like = modello.Like;
                    VideogiocoDaModificare.Disponibilità = modello.Disponibilità;
                    VideogiocoDaModificare.Prezzo = modello.Prezzo;

                    db.SaveChanges();

                    return RedirectToAction("index");
                }
                else
                {
                    return NotFound();
                }
            }
        }
        // -------------------------------------------Fine Modifica Videogioco -------------------------------------------------

        /*----------------------------------------------------read------------------------------------------------------------*/

        [HttpGet]
        public IActionResult Dettagli(int id)
        {

            using (VideogameShopContext db = new VideogameShopContext())
            {
                try
                {
                    Videogioco videogiocoTrovato = db.Videogiochi
                        .Where(x => x.Id == id)
                        .Single();
                    return View("Details", videogiocoTrovato);
                }
                catch (InvalidOperationException ex)
                {
                    return NotFound("Pacchetto inesistente");
                }
            }
        }
    }
}

        /*----------------------------------------------------read------------------------------------------------------------*/

        [HttpGet]
        public IActionResult Crea()
        {
            return View("FormCrea");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Crea(Videogiochi nuovoVideogioco)
        {
            if (!ModelState.IsValid)
            {
                return View("FormCrea", nuovoVideogioco);
            }

            using (VideogameShopContext db = new VideogameShopContext())
            {
                Videogiochi videogiocoToCreate = new Videogiochi(nuovoVideogioco.Nome, nuovoVideogioco.Descrizione, nuovoVideogioco.Foto, nuovoVideogioco.Prezzo);

                db.Videogiochi.Add(videogiocoToCreate);
                db.SaveChanges();
            }

            //Pizza pizzaConId = new Pizza(PostData.GetPizze().Count, nuovaPizza.Name , nuovaPizza.Description , nuovaPizza.Image);

            //Il mio modello è corretto
            //PostData.GetPizze().Add(pizzaConId);

            return RedirectToAction("Index");
        }
    }
}
