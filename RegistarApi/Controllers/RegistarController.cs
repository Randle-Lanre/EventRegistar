using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
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

        [HttpGet]
        public ActionResult GetRegistar()
        {
            return Ok();
        }

        [HttpPost]
        public async Task<ActionResult<EventRegistar>> AddToRegistar( EventRegistar anEvent)
        {

            _context.EventRegistars.Add(anEvent);
           await _context.SaveChangesAsync();

           return CreatedAtAction(nameof(GetRegistar), new {id = anEvent}, anEvent);
        }
        
    }
    
    
}
