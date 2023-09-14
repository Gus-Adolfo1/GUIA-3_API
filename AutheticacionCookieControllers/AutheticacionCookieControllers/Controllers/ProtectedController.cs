using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AutheticacionCookieControllers.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProtectedController : ControllerBase
    {
        static List<object> data = new List<object>();
        // GET: api/<ProtectedController>
        [HttpGet]
        public IEnumerable<object> Get()
        {
            return data;
        }

        // POST api/<ProtectedController>
        [HttpPost]
        public IActionResult Post(string name, string lastname)
        {
            data.Add(new { name, lastname });
            return Ok();
        }
    }
}
