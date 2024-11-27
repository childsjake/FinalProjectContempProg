using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ContemporaryAPI.Data;
using ContemporaryAPI.Models;
using System.Threading.Tasks;
using System.Collections.Generic;
using System;

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

        // GET: api/bookgenres
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookGenres>>> GetBookGenres()
        {
            return await _context.BookGenres.ToListAsync();
        }

        // GET: api/bookgenres/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<BookGenres>> GetBookGenre(int id)
        {
            var bookGenre = await _context.BookGenres.FindAsync(id);

            if (bookGenre == null)
            {
                return NotFound();
            }

            return bookGenre;
        }

        // POST: api/bookgenres
        [HttpPost]
        public async Task<ActionResult<BookGenres>> PostBookGenre(BookGenres bookGenres)
        {
            _context.BookGenres.Add(bookGenres);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetBookGenre), new { id = bookGenres.Id }, bookGenres);
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
            await _context.SaveChangesAsync();

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
    }
}
