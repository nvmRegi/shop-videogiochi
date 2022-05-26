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
