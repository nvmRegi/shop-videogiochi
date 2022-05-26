using Microsoft.AspNetCore.Mvc;
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
        public IActionResult Aggiorna(int id, PacchettoViaggio modello)
        {
            if (!ModelState.IsValid)
            {
                return View("AggiornaPacchetto", modello);
            }

            PacchettoViaggio pacchettoDaModificare = null;

            using (TravelAgencyContext db = new TravelAgencyContext())
            {
                pacchettoDaModificare = db.PacchettiViaggio
                      .Where(Pizza => Pizza.Id == id)
                      .First();

                if (pacchettoDaModificare != null)
                {
                    //aggiorniamo i campi con i nuovi valori
                    pacchettoDaModificare.Destinazione = modello.Destinazione;
                    pacchettoDaModificare.TipoPensione = modello.TipoPensione;
                    pacchettoDaModificare.StelleHotel = modello.StelleHotel;
                    pacchettoDaModificare.NumerOspiti = modello.NumerOspiti;
                    pacchettoDaModificare.Immagine = modello.Immagine;
                    pacchettoDaModificare.Prezzo = modello.Prezzo;

                    db.SaveChanges();

                    return RedirectToAction("index");
                }
                else
                {
                    return NotFound();
                }
            }
        }







        /*-------------------------------------read---------------------------------------------------------------------------------------*/

        [HttpGet]
        public IActionResult Dettagli(int id)
        {

            using VideogameShopContext db = new VideogameShopContext()
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
    /*----------------------------------------------------------------------------------------------------------------------------*/
}

}
