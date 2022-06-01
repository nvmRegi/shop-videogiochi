using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shop_Videogiochi.Data;
using Shop_Videogiochi.Models;
using System.Diagnostics;

namespace Shop_Videogiochi.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            using(VideogameShopContext db = new VideogameShopContext())
            {
                List<Categoria> listaCategoria = db.Categorie.ToList();
                return View("Homepage", listaCategoria);
            }
        }

        [HttpGet]
        public IActionResult Dettagli(int id)
        {
            using(VideogameShopContext db = new VideogameShopContext())
            {
                try
                {
                    Videogioco videogiocoDaCercare = db.Videogiochi
                        .Where(videogioco => videogioco.Id == id).Include(videogioco => videogioco.Categoria)
                        .First();
                    OrdineVideogioco model = new OrdineVideogioco();
                    model.videogioco = videogiocoDaCercare;
                    return View("Dettaglio", model);
                }
                catch (InvalidOperationException ex)
                {
                    return NotFound("Il videogioco con id " + id + "non è stato trovato");
                }catch(Exception ex)
                {
                    return BadRequest(ex);
                }
            }
        }

        [HttpPost]
        public IActionResult CompraVideogioco(int id, OrdineVideogioco model)
        {
            
            
            using (VideogameShopContext db = new VideogameShopContext())
            {
                model.videogioco = db.Videogiochi.Where(videogioco => videogioco.Id == id).First();
                if (!ModelState.IsValid)
                {
                    return View("Dettaglio", model);
                }

                Ordine ordineCliente = new Ordine();
                ordineCliente.VideogiocoId = id;
                ordineCliente.Quantità = model.ordine.Quantità;
                ordineCliente.Data = DateTime.Now;

                db.Ordini.Add(ordineCliente);
                db.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult PiùVenduti()
        {
            return View("PiùVenduti");
        }
    }
}