
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AutheticacionCookieControllers.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        static List<object> data = new List<object>();

        // GET: api/<TestController>
        [HttpGet]
        [AllowAnonymous]
        public IEnumerable<object> Get()
        {
            return data;
        }

        // POST api/<TestController>
        [AllowAnonymous]
        [HttpPost]
        public IActionResult Post(string name, string lastname)
        {
            data.Add(new { name, lastname });
            return Ok();
        }

        // DELETE api/<TestController>/5
        [Authorize]
        [HttpDelete]
        public IActionResult Delete()
        {
            data = new List<object>();
            return Ok();
        }
    }
}
