using EFitnessAPI.Data;
using EFitnessAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EFitnessAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AchievementsController : ControllerBase
    {
        private readonly EFitnessContext _context;

        public AchievementsController(EFitnessContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAchievements()
        {
            var achievements = await _context.Achievements.Include(a => a.Member).ToListAsync();
            return Ok(achievements);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAchievement(int id)
        {
            var achievement = await _context.Achievements.Include(a => a.Member).FirstOrDefaultAsync(a => a.Id == id);
            if (achievement == null) return NotFound();
            return Ok(achievement);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAchievement([FromBody] Achievement achievement)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            _context.Achievements.Add(achievement);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetAchievement), new { id = achievement.Id }, achievement);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAchievement(int id, [FromBody] Achievement achievement)
        {
            if (id != achievement.Id) return BadRequest();

            _context.Entry(achievement).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Achievements.Any(a => a.Id == id)) return NotFound();
                throw;
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAchievement(int id)
        {
            var achievement = await _context.Achievements.FindAsync(id);
            if (achievement == null) return NotFound();

            _context.Achievements.Remove(achievement);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
