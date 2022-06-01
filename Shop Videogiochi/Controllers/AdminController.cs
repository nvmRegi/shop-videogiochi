using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shop_Videogiochi.Data;
using Shop_Videogiochi.Models;

namespace Shop_Videogiochi.Controllers
{
    public class AdminController : Controller
    {
        [HttpGet]
        public IActionResult Index(int? id)
        {
            List<Videogioco> videogiocoList = new List<Videogioco>();

            using(VideogameShopContext db = new VideogameShopContext())
            {
                if(id != null)
                {
                    videogiocoList = db.Videogiochi.Include(videogioco => videogioco.Categoria).Where(videogioco => videogioco.CategoriaId == id).ToList();
                }
                else
                {
                    videogiocoList = db.Videogiochi.Include(videogioco => videogioco.Categoria).ToList();

                }
            }
            return View(videogiocoList);
        }

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
                        .First();
                    OrdineFornitoreVideogioco model = new OrdineFornitoreVideogioco();
                    model.videogioco = videogiocoTrovato;
                    return View("Dettagli", model);
                }
                catch (ArgumentNullException ex)
                {
                    return NotFound("Prodotto inesistente");
                }
                catch (InvalidOperationException ex)
                {
                    return BadRequest("Operazione Errata");
                }
            }
        }
        /*----------------------------------------------------read------------------------------------------------------------*/

        [HttpGet]
        public IActionResult Crea()
        {
            using (VideogameShopContext db = new VideogameShopContext())
            {
                List<Categoria> categoria = db.Categorie.ToList();

                VideogiocoCategoria model = new VideogiocoCategoria();
                model.videogioco = new Videogioco();
                model.categoria = categoria;
                return View("FormCrea", model);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Crea(VideogiocoCategoria model)
        {
            if (!ModelState.IsValid)
            {
                using (VideogameShopContext db = new VideogameShopContext())
                {
                    List<Categoria> categoria = db.Categorie.ToList();
                    model.categoria = categoria;
                }

                return View("FormCrea", model);
            }

            using (VideogameShopContext db = new VideogameShopContext())
            {
                Videogioco videogiocoToCreate = new Videogioco();
                videogiocoToCreate.Nome = model.videogioco.Nome;
                videogiocoToCreate.Foto = model.videogioco.Foto;
                videogiocoToCreate.Descrizione = model.videogioco.Descrizione;
                videogiocoToCreate.Prezzo = model.videogioco.Prezzo;
                videogiocoToCreate.MiPiace = 0;

                videogiocoToCreate.CategoriaId = model.videogioco.CategoriaId;

                db.Videogiochi.Add(videogiocoToCreate);
                db.SaveChanges();
            }

            //Pizza pizzaConId = new Pizza(PostData.GetPizze().Count, nuovaPizza.Name , nuovaPizza.Description , nuovaPizza.Image);

            //Il mio modello è corretto
            //PostData.GetPizze().Add(pizzaConId);

            return RedirectToAction("Index");
        }


        // ------------------------------------------- Modifica Videogioco -------------------------------------------------

        [HttpGet]
        public IActionResult Aggiorna(int id)
        {
            Videogioco videogiocoDaModificare = null;
            List<Categoria> categoria = new List<Categoria>();

            using (VideogameShopContext db = new VideogameShopContext())
            {
                videogiocoDaModificare = db.Videogiochi
                              .Where(videogioco => videogioco.Id == id)
                              .First();

                categoria = db.Categorie.ToList<Categoria>();
            }

            if (videogiocoDaModificare == null)
            {
                return NotFound();
            }
            else
            {
                VideogiocoCategoria model = new VideogiocoCategoria();
                model.videogioco = videogiocoDaModificare;
                model.categoria = categoria;
                return View("FormModifica", model);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Aggiorna(int id, VideogiocoCategoria modello)
        {
            if (!ModelState.IsValid)
            {
                using (VideogameShopContext db = new VideogameShopContext())
                {
                    List<Categoria> categoria = db.Categorie.ToList();
                    modello.categoria = categoria;
                }

                return View("FormCrea", modello);
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
                    VideogiocoDaModificare.Nome = modello.videogioco.Nome;
                    VideogiocoDaModificare.Foto = modello.videogioco.Foto;
                    VideogiocoDaModificare.Descrizione = modello.videogioco.Descrizione;
                    VideogiocoDaModificare.Prezzo = modello.videogioco.Prezzo;

                    db.SaveChanges();

                    return RedirectToAction("Index");
                }
                else
                {
                    return NotFound();
                }
            }
        }
        // -------------------------------------------Fine Modifica Videogioco -------------------------------------------------

        
         [HttpPost]
         public IActionResult Cancella(int id)
         {
            using (VideogameShopContext db = new VideogameShopContext())
            {
                Videogioco videogiocoDaCancellare = db.Videogiochi
                    .Where(x => x.Id == id)
                    .First();
                   
                if (videogiocoDaCancellare != null)
                {
                    db.Videogiochi.Remove(videogiocoDaCancellare);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    return NotFound();
                }

            }
         }

        [HttpPost] //Nella vista Dettagli puoi comprare un videogioco
        public IActionResult CompraVideogioco(int id, OrdineFornitoreVideogioco model)
        {
            

            using (VideogameShopContext db = new VideogameShopContext())
            {
                model.videogioco = db.Videogiochi.Where(videogioco => videogioco.Id == id).First();

                if (!ModelState.IsValid)
                {
                    return View("Dettagli", model);
                }
                OrdineFornitore ordineFornitore = new OrdineFornitore();
                ordineFornitore.VideogiocoId = id;
                ordineFornitore.NomeFornitore = model.ordineFornitore.NomeFornitore;
                ordineFornitore.Quantità = model.ordineFornitore.Quantità;
                ordineFornitore.Data = DateTime.Now;
                
                db.OrdiniFornitore.Add(ordineFornitore);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

    }
}
