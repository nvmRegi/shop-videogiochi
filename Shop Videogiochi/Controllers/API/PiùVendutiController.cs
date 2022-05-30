using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shop_Videogiochi.Data;
using Shop_Videogiochi.Models;

namespace Shop_Videogiochi.Controllers.API
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PiùVendutiController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            List<Ordine> listaPiuVenduti = new List<Ordine>();
            using (VideogameShopContext db = new VideogameShopContext())
            {

                listaPiuVenduti = (from Ordini in db.Ordini group Ordini.VideogiocoId select *).ToList();
                //listaPiuVenduti = db.Ordini.FromSqlRaw("SELECT VideogiocoId, SUM(Quantità) as Vendite FROM Ordini GROUP BY VideogiocoId ORDER BY Vendite desc");
            }
            return Ok(listaPiuVenduti);
        }
    }
}
