using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shop_Videogiochi.Data;
using Shop_Videogiochi.Models;

namespace Shop_Videogiochi.Controllers.API
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PiuVendutiController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            
            using (VideogameShopContext db = new VideogameShopContext())
            {
                List<Videogioco> listaPiuVenduti = db.Videogiochi.FromSqlRaw("SELECT Videogiochi.* FROM Videogiochi INNER JOIN Ordini ON Videogiochi.Id = Ordini.VideogiocoId WHERE data >= DATEADD(day, -30, GETDATE()) AND data <= GETDATE() GROUP BY Videogiochi.Id, Videogiochi.Nome, Videogiochi.Descrizione, Videogiochi.Prezzo, Videogiochi.Foto, Videogiochi.CategoriaId, Videogiochi.MiPiace ORDER BY SUM(Quantità) DESC").ToList();

                return Ok(listaPiuVenduti);
            }
        }
    }
}

//Condizione del Where prima della modifica -30
//MONTH(data) = MONTH(DATEADD(month, -1, GETDATE())