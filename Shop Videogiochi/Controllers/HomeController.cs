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
            return View("Homepage");
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
                    return View("Dettagli", videogiocoDaCercare);
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
        public IActionResult CompraVideogioco(int id, Videogioco model, int quantità)
        {
            if (!ModelState.IsValid)
            {
                return View("Dettagli", model);
            }

            using (VideogameShopContext db = new VideogameShopContext())
            {
                Videogioco videogiocoDaComprare = db.Videogiochi
                    .Where(videogioco => videogioco.Id == id)
                    .First();

                Ordine ordineCliente = new Ordine();
                ordineCliente.VideogiocoId = id;
                ordineCliente.Quantità = -quantità;
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