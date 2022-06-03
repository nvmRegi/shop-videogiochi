using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shop_Videogiochi.Data;
using Shop_Videogiochi.Models;
using Shop_Videogiochi.Models.Models_Ponte;

namespace Shop_Videogiochi.Controllers.API
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class VideogiochiMiPiaceController : ControllerBase
    {

        //Prende i videogiochi preferiti dell'utente
        [HttpGet]
        public IActionResult Get(string? cerca, int? id, int? idCategoria)
        {
            List<Videogioco> listaVideogiochiPreferiti = new List<Videogioco>();
            List<dataInputId> idVideogiochiPreferiti = VideogiochiPreferiti.listaVideogiochiPreferiti;
            
            if(idVideogiochiPreferiti.Count == 0)
            {
                return Ok(listaVideogiochiPreferiti);
            }

            using(VideogameShopContext db = new VideogameShopContext())
            {
                for(int i = 0; i < idVideogiochiPreferiti.Count; i++)
                {
                    Videogioco daCercare = db.Videogiochi.Include(Videogioco => Videogioco.Categoria).Where(videogioco => videogioco.Id == idVideogiochiPreferiti[i].Id).First();
                    listaVideogiochiPreferiti.Add(daCercare);
                }

                if (id != null)
                {
                    Videogioco videogiocoTrovato = listaVideogiochiPreferiti.Find(videogioco => videogioco.Id == id);
                    return Ok(videogiocoTrovato);
                }
                else if (idCategoria != null)
                {
                    List<Videogioco> videogiochiPerCategoria = listaVideogiochiPreferiti.FindAll(videogioco => videogioco.CategoriaId == idCategoria);
                    return Ok(videogiochiPerCategoria);
                } else if(cerca != null && cerca != "")
                {
                    List<Videogioco> videogiochiRicerca = listaVideogiochiPreferiti.Where(videogioco => videogioco.Nome.Contains(cerca) || videogioco.Descrizione.Contains(cerca)).ToList();
                    return Ok(videogiochiRicerca);
                }
                return Ok(listaVideogiochiPreferiti);
            }
        }

        //Aggiunge un videogioco ai preferiti dell'utente
        [HttpPost]
        public IActionResult Post([FromBody]dataInputId data)
        {
            if (!ModelState.IsValid)
            {
                return UnprocessableEntity(ModelState);
            }

            List<dataInputId> idVideogiochiPreferiti = VideogiochiPreferiti.listaVideogiochiPreferiti;
            idVideogiochiPreferiti.Add(data);

            using(VideogameShopContext db = new VideogameShopContext())
            {
                Videogioco videogiocoDaCambiare = db.Videogiochi.Where(videogioco => videogioco.Id == data.Id).First();

                if(videogiocoDaCambiare != null)
                {
                    if(videogiocoDaCambiare.MiPiace == null)
                    {
                        videogiocoDaCambiare.MiPiace = 0;
                    }

                    videogiocoDaCambiare.MiPiace = videogiocoDaCambiare.MiPiace + 1;
                    db.SaveChanges();
                }
            }

            return Ok(idVideogiochiPreferiti);
        }




        //Rimuove un videogioco ai preferiti dell'utente
        [HttpDelete ("{id}")]
        public IActionResult Delete(int id)
        { 

            List<dataInputId> idVideogiochiPreferiti = VideogiochiPreferiti.listaVideogiochiPreferiti;

            dataInputId daTogliere = new dataInputId();

            daTogliere.Id = id;

            idVideogiochiPreferiti.Remove(daTogliere);

            using (VideogameShopContext db = new VideogameShopContext())
            {
                Videogioco videogiocoDaCambiare = db.Videogiochi.Where(videogioco => videogioco.Id == daTogliere.Id).First();

                if (videogiocoDaCambiare != null)
                {
                    if (videogiocoDaCambiare.MiPiace == null)
                    {
                        videogiocoDaCambiare.MiPiace = 0;
                    }

                    videogiocoDaCambiare.MiPiace = videogiocoDaCambiare.MiPiace -1;
                    db.SaveChanges();
                }
            }

            return Ok(idVideogiochiPreferiti);
        }




















    }
}
