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
        public IActionResult Get()
        {
            List<Categoria> categorie = new List<Categoria>();
            using(VideogameShopContext db = new VideogameShopContext())
            {
                categorie = db.Categorie.ToList();
                return Ok(categorie);
            }
        }
    }
}
