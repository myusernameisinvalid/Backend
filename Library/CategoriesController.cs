using libraryujra.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace libraryujra.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        /*Hozzon létre végpontot az adatbázisban szerepelő kategóriák adatainak a lekérdezésére 
        az alábbi beállításokkal és paraméterekkel! Oldja meg, hogy a válasz üzenetben a „categories” tábla 
        összes mezője és a hozzátartozó összes könyv adataival szerepeljenek.
        A válasz tartalma a lenti mintáktól eltérhet a választott technológiának megfelelően, de a „categories” táblában 
        szereplő összes adatot tartalmaznia kell! Amennyiben nem sikerül az adatlekérés, akkor a válasz keletkezett hibaüzenet
        legyen 400-as hibakóddal.
        */
        [HttpGet("feladat11")]
        public IActionResult Get()
        {
            using (var context = new LibrarydbContext())
            {
                try
                {
                    var result = context.Categories.Include(x => x.Books).ToList();
                    if(result != null)
                    {
                        return Ok(result);
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