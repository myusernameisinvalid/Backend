using libraryujra.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace libraryujra.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        /*Hozzon létre végpontot az összes könyv és minden adatának a kilistázására. 
        A válasz tartalma a lenti mintáktól eltérhet a választott technológiának megfelelően,
        de a „books” táblában szereplő összes adatot tartalmaznia kell! Amennyiben nem sikerül az adatlekérés,
        akkor a válasz keletkezett hibaüzenet legyen 400-as hibakóddal.
        */
        [HttpGet("feladat10")]
        public IActionResult Get()
        {
            using (var context = new LibrarydbContext())
            {
                try
                {
                    var result = context.Books.Select(book => new
                    {
                        book.BookId,
                        book.Title,
                        book.PublishDate,
                        book.AuthorId,
                        book.CategoryId
                    }).ToList();

                    return Ok(result);
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
        }

         /*Hozzon létre végpontot új könyv rögzítésére az alábbi feltételekkel és beállításokkal!
         A könyv rögzítése csak akkor lehetséges, ha a felhasználó be van jelentkezve és van jogosultsága hozzá.
         Ez akkor lehetséges, ha a paraméterben kapott „UserID” értéke „FKB3F4FEA09CE43C”. 
         Oldja meg, hogy a főprogram tárolja ezt az azonosítót „UID” néven és a végpont hasonlítsa össze 
         ezt a paraméterében kapott értékkel. Sikeres rögzítés esetén 201 CREATED státuszkóddal és a 
         „Könyv hozzáadása sikeresen megtörtént.” JSON üzenettel térjen vissza! Hiba esetén 400 BAD REQUEST hibakóddal 
         és a hibára utaló üzenettel térjen vissza! Amennyiben jogosultsági probléma lép fel, akkor 401 Unauthorized hibakóddal
         és „Nincs jogosultsága új könyv felvételéhez!” üzenettel térjen vissza.
         */
        [HttpPost("feladat13")]
        public IActionResult AddBook(string uid, Book book)
        {
            string userid = "FKB3F4FEA09CE43C";
            using (var context = new LibrarydbContext())
            {
                try
                {
                    if (userid == uid)
                    {
                        context.Books.Add(book);
                        context.SaveChanges();
                        return StatusCode(201, "Könyv hozzáadása sikeresen megtörtént");
                    }
                    else
                    {
                        return StatusCode(401, "Nincs jogosultsága új könyv felvételéhez");
                    }
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
        }
    }
}