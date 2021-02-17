using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RegistarApi.Model;

namespace RegistarApi.Controllers
{
    [ApiController]
    public class RegistarController : ControllerBase
    {
        // GET
        // public IActionResult Index()
        // {
        //     return View();
        // }


        [HttpGet]
        public ActionResult GetRegistar()
        {
            return Ok();
        }

        [HttpPost]
        public async Task<ActionResult<EventRegistar>> AddToRegistar( EventRegistar anEvent)
        {
            return Ok();
        }
        
    }
    
    
}
