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
        public IActionResult Get()
        {
            List<Videogioco> giochiInHomePage = new List<Videogioco>();

            using (VideogameShopContext db = new VideogameShopContext())
            {

                giochiInHomePage = db.Videogiochi.Include(videogioco => videogioco.Categoria).ToList<Videogioco>();
                return Ok(giochiInHomePage);
                         
            }
        }
    }
}
