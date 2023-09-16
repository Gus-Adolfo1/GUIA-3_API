using GAM230609.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GAM230609.AcademyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NoteController : ControllerBase
    {
        static List<Nota> notas = new List<Nota>();

        // GET: api/<NoteController>
        [HttpGet]
        [AllowAnonymous]
        public IEnumerable<Nota> Get()
        {
            return notas;
        }

        // POST api/<NoteController>
        [HttpPost]
        [Authorize]
        public IActionResult Post(int id, string alumno, int nota, string materia)
        {
            var note = new Nota
            {
                id = id,
                alumno = alumno,
                nota = nota,
                materia = materia
            };

            notas.Add(note);
            return Ok();
        }
    }
}