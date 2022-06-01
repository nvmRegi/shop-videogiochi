using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shop_Videogiochi.Data;
using Shop_Videogiochi.Models;

namespace Shop_Videogiochi.Controllers.API
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class VideogiochiMiPiaceController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get(int? id)
        {
            List<Videogioco> giochiInHomePage = new List<Videogioco>();

            using (VideogameShopContext db = new VideogameShopContext())
            {

                if (id != null)
                {
                    giochiInHomePage = db.Videogiochi.ToList();
                    return Ok(giochiInHomePage);
                }
                return BadRequest();
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody] Videogioco model)
        {
            if (!ModelState.IsValid)
            {
                return UnprocessableEntity(ModelState);
            }
            using (VideogameShopContext db = new VideogameShopContext())
            {
                Videogioco giocoDaMipiacciare = db.Videogiochi.Where(x => 
                    x.Id == model.Id
                        ).Single();

                model.MiPiace = giocoDaMipiacciare.MiPiace++;

                giocoDaMipiacciare.MiPiace = model.MiPiace++;
                db.SaveChanges();
                return Ok();
            }
        }
    }
}
