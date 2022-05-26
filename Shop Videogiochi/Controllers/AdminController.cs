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
