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
        public IActionResult Get(int? idCategoria)
        {
            List<Categoria> categorie = new List<Categoria>();
            using(VideogameShopContext db = new VideogameShopContext())
            {
                if(idCategoria != null && idCategoria != -1)
                {
                    Categoria categoria = db.Categorie.Where(categoria => categoria.Id == idCategoria).FirstOrDefault();
                    return Ok(categoria);
                }
                else
                {
                    categorie = db.Categorie.ToList();
                    return Ok(categorie);
                }
            }
        }
    }
}
