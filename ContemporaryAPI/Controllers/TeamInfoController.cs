using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ContemporaryAPI.Data;
using ContemporaryAPI.Models;

namespace ContemporaryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamInfoController : ControllerBase
    {
        private readonly ContemporaryDbContext _context;

        public TeamInfoController(ContemporaryDbContext context)
        {
            _context = context;
        }

        // GET: api/TeamInfo/5 Returns first 5 if Null or 0
        [HttpGet("{id?}")]
        public async Task<ActionResult<IEnumerable<TeamInfo>>> GetTeamInfo(int? id)
        {
            if (id == null || id == 0)
            {
                return await _context.TeamInfos.Take(5).ToListAsync();
            }

            var teamInfo = await _context.TeamInfos.FindAsync(id);

            if (teamInfo == null)
            {
                return NotFound();
            }

            return Ok(teamInfo);
        }

        // POST: api/TeamInfo
        [HttpPost]
        public async Task<ActionResult<TeamInfo>> PostTeamInfo(TeamInfo teamInfo)
        {
            _context.TeamInfos.Add(teamInfo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTeamInfo", new { id = teamInfo.Id }, teamInfo);
        }

        // PUT: api/TeamInfo/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTeamInfo(int id, TeamInfo teamInfo)
        {
            if (id != teamInfo.Id)
            {
                return BadRequest();
            }

            _context.Entry(teamInfo).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TeamInfoExists(id))
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

        // DELETE: api/TeamInfo/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTeamInfo(int id)
        {
            var teamInfo = await _context.TeamInfos.FindAsync(id);
            if (teamInfo == null)
            {
                return NotFound();
            }

            _context.TeamInfos.Remove(teamInfo);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TeamInfoExists(int id)
        {
            return _context.TeamInfos.Any(e => e.Id == id);
        }
    }
}
