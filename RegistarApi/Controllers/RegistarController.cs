using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RegistarApi.Model;

namespace RegistarApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistarController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public RegistarController( ApplicationDbContext context)
        {
            _context = context;

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EventRegistar>> GetRegistar(int id)
        {
            var anEvent = await _context.EventRegistars.FindAsync(id);

            if (anEvent != null)
                return Ok(anEvent);
            return NotFound();
        }

        [HttpPost]
        public async Task<ActionResult<EventRegistar>> AddToRegistar( EventRegistar anEvent)
        {

            _context.EventRegistars.Add(anEvent);
           await _context.SaveChangesAsync();

           return CreatedAtAction(nameof(GetRegistar), new {id = anEvent}, anEvent);
        }


        [HttpDelete]
        public async Task<IActionResult> DeleteRegistarItem(int id)
        {
            var registarItem = await _context.EventRegistars.FindAsync(id);

            if (registarItem == null)
                return StatusCode(404);
            _context.EventRegistars.Remove(registarItem);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEventRegistar (int id, EventRegistar eventRegistar)
        {
            if (id != eventRegistar.Id)
                return BadRequest();

            _context.Entry(eventRegistar).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                return NotFound();

            }

            return NoContent();
        }
        
    }
    
    
}
