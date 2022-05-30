using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shop_Videogiochi.Data;
using Shop_Videogiochi.Models;

//namespace Shop_Videogiochi.Controllers.API
//{
//    [Route("api/[controller]/[action]")]
//    [ApiController]
//    public class PiùVendutiController : ControllerBase
//    {
//        [HttpGet]
//        public IActionResult Get()
//        {
//            List<Videogioco> listaPiuVenduti = new List<Videogioco>();
//            using (VideogameShopContext db = new VideogameShopContext())
//            {
                
//               listaPiuVenduti = db.Ordini.FromSqlRaw("")
             
//            }
//        }
//    }
//}
