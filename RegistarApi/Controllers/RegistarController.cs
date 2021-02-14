using Microsoft.AspNetCore.Mvc;

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
        public ActionResult AddToRegistar()
        {
            return Ok();
        }
        
    }
    
    
}
