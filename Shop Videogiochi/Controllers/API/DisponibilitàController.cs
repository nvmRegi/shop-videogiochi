using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shop_Videogiochi.Data;
using Shop_Videogiochi.Models;

namespace Shop_Videogiochi.Controllers.API
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class DisponibilitàController : ControllerBase
    {
        //public IActionResult Get()
        //{
        //    using(VideogameShopContext db = new VideogameShopContext())
        //    {
        //        List<OrdineFornitore> listaOrdiniTot = db.OrdiniFornitore.ToList();
        //        List<OrdineFornitore> listaOrdiniVideogame = db.OrdiniFornitore.FromSqlRaw("SELECT VideogiSUM(Quantità) FROM OrdiniFornitore GROUP BY VideogiocoId").ToList();
                
        //        List
        //    }
        //}
    }
}
