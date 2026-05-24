using libraryujra.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace libraryujra.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        //Hozzon létre végpontot, ahol képes szűrni a könyvek szerzőjére és visszaadni a paraméterként
        //megadott szerző adatait és az általa publikált könyveket.
        [HttpGet("feladat9/{authorname}")]
        public IActionResult Get(string authorname)
        {
            using (var context = new LibrarydbContext())
            {
                try
                {
                    var result = context.Authors.Include(x => x.Books).FirstOrDefault(x => x.AuthorName == authorname);
                    if(result != null)
                    {
                        return Ok(result);
                    }
                    return NotFound();
                }
                catch(Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
        }

        //Hozzon létre végpontot az adatbázisban szerepelő összes szerző számának a lekérdezésére az alábbi beállításokkal és paraméterekkel! 
        [HttpGet("feladat12")]
        public IActionResult GetAuthorNumbers()
        {
            using (var context = new LibrarydbContext())
            {
                try
                {
                    var result = context.Authors.Count();
                    if(result != null)
                    {
                        return StatusCode(200, $"Szerzők száma: {result}");
                    }
                    return NotFound();
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
        }
    }
}
