using GAM230609.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SVLT230609.AcademyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class EnrollmentController : ControllerBase
    {
        static List<Inscripcion> inscripcion = new List<Inscripcion>();

        // GET: api/<EnrollmentController>
        [HttpGet]
        public IEnumerable<Inscripcion> Get()
        {
            return inscripcion;
        }

        // GET api/<EnrollmentController>/5
        [HttpGet("{id}")]
        public Inscripcion Get(int id)
        {
            var inscripcions = inscripcion.FirstOrDefault(e => e.id == id);
            return inscripcions;
        }

        // POST api/<EnrollmentController>
        [HttpPost]
        public IActionResult Post(int id, string nombre, string grado, int año)
        {
            // Crea una nueva instancia de Enrollment utilizando los datos proporcionados
            var enrollment = new Inscripcion
            {
                id = id,
                nombre = nombre,
                grado = grado,
                año = año
            };

            inscripcion.Add(enrollment);
            return Ok();
        }

        // PUT api/<StudentsController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Inscripcion inscripcions)
        {
            var ExistingInscripcion = inscripcion.FirstOrDefault(e => e.id == id);
            if (ExistingInscripcion != null)
            {
                ExistingInscripcion.nombre = inscripcions.nombre;
                ExistingInscripcion.grado = inscripcions.grado;
                ExistingInscripcion.año = inscripcions.año;
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }
    }
}