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
    public class MoviesController : ControllerBase
    {
        private readonly ContemporaryDbContext _context;

        public MoviesController(ContemporaryDbContext context)
        {
            _context = context;
        }

        // GET: api/Movies/{id} Returns first 5 if id is null or 0
        [HttpGet("{id?}")]
        public async Task<ActionResult> GetMovies(int? id)
        {
            if (id == null || id == 0)
            {
                var topFiveMovies = await _context.Movies.Take(5).ToListAsync();
                return Ok(topFiveMovies);
            }

            var movies = await _context.Movies.FindAsync(id);

            if (movies == null)
            {
                return NotFound();
            }

            return Ok(movies);
        }

        // POST: api/movies
        [HttpPost]
        public async Task<ActionResult<Movies>> PostMovies(Movies movies)
        {
            _context.Movies.Add(movies);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetMovies), new { id = movies.Id }, movies);
        }

        // PUT: api/movies/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMovies(int id, Movies movies)
        {
            if (id != movies.Id)
            {
                return BadRequest();
            }

            _context.Entry(movies).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MoviesExists(id))
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

        // DELETE: api/movies/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMovies(int id)
        {
            var movies = await _context.Movies.FindAsync(id);
            if (movies == null)
            {
                return NotFound();
            }

            _context.Movies.Remove(movies);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MoviesExists(int id)
        {
            return _context.Movies.Any(e => e.Id == id);
        }
    }
}