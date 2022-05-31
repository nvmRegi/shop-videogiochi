using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shop_Videogiochi.Data;
using Shop_Videogiochi.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Shop_Videogiochi.Controllers.API
{

    //api per i videogiochi per l'home 


    [Route("api/[controller]/[action]")] //richiamerò così il metodo es /api/Videogiochi/Get 
    [ApiController]
    public class VideogiochiController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get(string? search, int? idCategoria)
        {
            List<Videogioco> giochiInHomePage = new List<Videogioco>();

            using (VideogameShopContext db = new VideogameShopContext())
            {
                if(search != null && search != "")
                {
                    giochiInHomePage = db.Videogiochi.Include(videogioco => videogioco.Categoria)
                        .Where(videogioco => videogioco.Nome.Contains(search) || videogioco.Descrizione.Contains(search)).ToList();
                }
                else if(idCategoria != null)
                {
                    giochiInHomePage = db.Videogiochi.Include(videogioco => videogioco.Categoria)
                        .Where(videogioco => videogioco.CategoriaId == idCategoria).ToList();
                } 
                else
                {
                    giochiInHomePage = db.Videogiochi.Include(videogioco => videogioco.Categoria).ToList();
                }
                return Ok(giochiInHomePage);
            }
        }
    }
}
