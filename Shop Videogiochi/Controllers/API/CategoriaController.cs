using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shop_Videogiochi.Data;
using Shop_Videogiochi.Models;

namespace Shop_Videogiochi.Controllers.API
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get(int id)
        {
            List<Videogioco> videoGiochiPerCategoria = new List<Videogioco>();
            using (VideogameShopContext db= new VideogameShopContext())
            {
                

                if(id != null)
                {
                    videoGiochiPerCategoria = db.Videogiochi.Where(videogioco => videogioco.CategoriaId == id).ToList();
                    return Ok(videoGiochiPerCategoria);
                }
                return BadRequest();

                
                
            }
        }
    }
}
