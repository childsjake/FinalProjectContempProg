using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ContemporaryAPI.Data;
using ContemporaryAPI.Models;


namespace ContemporaryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FavAnimalsController : ControllerBase
    {
        private readonly ContemporaryDbContext _context;
        public FavAnimalsController(ContemporaryDbContext context)
        {
            _context = context;
        }

        //GET: api/FavAnimals/5 Returns first 5 if Null or 0
        [HttpGet("{id?}")]
        public async Task<ActionResult<IEnumerable<FavAnimals>>> GetFavAnimals(int? id)
        {
            if (id == null || id == 0)
            {
                return await _context.FavAnimals.Take(5).ToListAsync();
            }

            var favAnimals = await _context.FavAnimals.FindAsync(id);

            if (favAnimals == null)
            {
                return NotFound();
            }

            return Ok(favAnimals);
        }

        //POST: api/FavAnimals
        [HttpPost]
        public async Task<ActionResult<FavAnimals>> PostFavAnimals(FavAnimals favAnimals)
        {
            _context.FavAnimals.Add(favAnimals);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetFavAnimals), new { id = favAnimals.Id }, favAnimals);
        }

        //PUT: api/FavAnimals/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFavAnimals(int id, FavAnimals favAnimals)
        {
            if (id != favAnimals.Id)
            {
                return BadRequest();
            }

            _context.Entry(favAnimals).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FavAnimalsExists(id))
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

        //DELETE: api/FavAnimals/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFavAnimal(int id)
        {
            var favAnimals = await _context.FavAnimals.FindAsync(id);
            if (favAnimals == null)
            {
                return NotFound();
            }

            _context.FavAnimals.Remove(favAnimals);
            await _context.SaveChangesAsync();

            return NoContent();
        }
        private bool FavAnimalsExists(int id)
        {
            return _context.FavAnimals.Any(e => e.Id == id);
        }
    }
}
