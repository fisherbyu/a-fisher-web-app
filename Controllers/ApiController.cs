using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AFisherWebApp.Controllers
{
    [ApiController]
    [Route("/")]
    public class ApiController : Controller
    {

        // Endpoints: --------------------------------------------------------------------------------------------------------------------

        // GET: api/
        [HttpGet]
        public IActionResult Get()
        {
            var data = new
            {
                content = "Thanks for visiting my API!  Check fisherandrew.org for documentation"
            };

            return Json(data);
        }
    }
}

