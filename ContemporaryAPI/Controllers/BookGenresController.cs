using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ContemporaryAPI.Data;
using ContemporaryAPI.Models;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace ContemporaryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookGenresController : ControllerBase
    {
        private readonly ContemporaryDbContext _context;

        public BookGenresController(ContemporaryDbContext context)
        {
            _context = context;
        }

        // GET: api/bookgenres/{id} Returns first 5 if id is null or 0
        [HttpGet("{id?}")]
        public async Task<ActionResult> GetBookGenres(int? id)
        {
            if (id == null || id == 0)
            {
                var topFiveGenres = await _context.BookGenres.Take(5).ToListAsync();
                return Ok(topFiveGenres);
            }

            var bookGenres = await _context.BookGenres.FindAsync(id);

            if (bookGenres == null)
            {
                return NotFound();
            }

            return Ok(bookGenres);
        }

        // POST: api/bookgenres
        [HttpPost]
        public async Task<ActionResult<BookGenres>> PostBookGenre(BookGenres bookGenres)
        {
            _context.BookGenres.Add(bookGenres);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetBookGenres), new { id = bookGenres.Id }, bookGenres);
        }

        // PUT: api/bookgenres/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBookGenre(int id, BookGenres bookGenres)
        {
            if (id != bookGenres.Id)
            {
                return BadRequest();
            }

            _context.Entry(bookGenres).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookGenresExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // DELETE: api/bookgenres/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBookGenre(int id)
        {
            var bookGenre = await _context.BookGenres.FindAsync(id);
            if (bookGenre == null)
            {
                return NotFound();
            }

            _context.BookGenres.Remove(bookGenre);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BookGenresExists(int id)
        {
            return _context.BookGenres.Any(e => e.Id == id);
        }
    }
}
