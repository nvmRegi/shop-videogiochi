using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shop_Videogiochi.Data;
using Shop_Videogiochi.Models;

namespace Shop_Videogiochi.Controllers
{
    public class AdminController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            List<Videogioco> videogiocoList = new List<Videogioco>();

            using(VideogameShopContext db = new VideogameShopContext())
            {
                videogiocoList = db.Videogiochi.ToList<Videogioco>();
            }
            return View(videogiocoList);
        }


        // ------------------------------------------- Modifica Videogioco -------------------------------------------------

        [HttpGet]
        public IActionResult Aggiorna(int id)
        {
            Videogioco videogiocoDaModificare = null;

            using (VideogameShopContext db = new VideogameShopContext())
            {

                videogiocoDaModificare = db.Videogiochi
                              .Where(videogioco => videogioco.Id == id)
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
                catch (ArgumentNullException ex)
                {
                    return NotFound("Prodotto inesistente");
                }
                catch (InvalidOperationException ex)
                {
                    return NotFound("Operazione Errata");
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
        public IActionResult Crea(Videogioco nuovoVideogioco)
        {
            if (!ModelState.IsValid)
            {
                return View("FormCrea", nuovoVideogioco);
            }

            using (VideogameShopContext db = new VideogameShopContext())
            {
                Videogioco videogiocoToCreate = new Videogioco(nuovoVideogioco.Nome, nuovoVideogioco.Descrizione, nuovoVideogioco.Foto, nuovoVideogioco.Prezzo);

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
