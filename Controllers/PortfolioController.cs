using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PortfolioWebsite.Data;
using PortfolioWebsite.Models;

namespace PortfolioWebsite.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PortfolioController : ControllerBase
    {
        private readonly PortfolioContext _context;

        public PortfolioController(PortfolioContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<PortfolioData>> GetPortfolio()
        {
            var portfolio = await _context.PortfolioData
                .Include(p => p.Projects)
                .FirstOrDefaultAsync();

            if (portfolio == null)
            {
                return NotFound();
            }

            return Ok(portfolio);
        }

        [HttpGet("projects")]
        public async Task<ActionResult<IEnumerable<Project>>> GetProjects()
        {
            var projects = await _context.Projects.ToListAsync();
            return Ok(projects);
        }

        [HttpPost("projects")]
        public async Task<ActionResult<Project>> CreateProject(Project project)
        {
            _context.Projects.Add(project);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetProjects), new { id = project.Id }, project);
        }

        [HttpPut("projects/{id}")]
        public async Task<IActionResult> UpdateProject(int id, Project project)
        {
            if (id != project.Id)
            {
                return BadRequest();
            }

            _context.Entry(project).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProjectExists(id))
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

        [HttpDelete("projects/{id}")]
        public async Task<IActionResult> DeleteProject(int id)
        {
            var project = await _context.Projects.FindAsync(id);
            if (project == null)
            {
                return NotFound();
            }

            _context.Projects.Remove(project);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpPost("music/toggle")]
        public async Task<IActionResult> ToggleMusic()
        {
            var portfolio = await _context.PortfolioData.FirstOrDefaultAsync();
            if (portfolio == null)
            {
                return NotFound();
            }

            portfolio.MusicPlayer.IsPlaying = !portfolio.MusicPlayer.IsPlaying;
            await _context.SaveChangesAsync();

            return Ok(new { isPlaying = portfolio.MusicPlayer.IsPlaying });
        }

        private bool ProjectExists(int id)
        {
            return _context.Projects.Any(e => e.Id == id);
        }
    }
}
