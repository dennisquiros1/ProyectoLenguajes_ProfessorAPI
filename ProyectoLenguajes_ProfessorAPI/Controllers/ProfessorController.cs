using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoLenguajes_ProfessorAPI.Models;

namespace ProyectoLenguajes_ProfessorAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfessorController : ControllerBase
    {
        private readonly Asc2DevProfessorContext _context;

        public ProfessorController(IConfiguration _configuration)
        {
            _context = new Asc2DevProfessorContext(_configuration);
        }


        [HttpGet]
        [Route("[action]")]
        public async Task<ActionResult<Professor>> GetById(string id)
        {
            try
            {
                var professor = await _context.Professors.FirstOrDefaultAsync(p => p.Id == id);

                if (professor == null)
                {
                    return NotFound();
                }

                return professor;
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<ActionResult<int>> Authenticate(string id, string password)
        {
            // Verificar si el profesor existe
            var exists = await _context.Professors.AnyAsync(p => p.Id == id);
            if (!exists)
            {
                return -1; // No existe el profesor
            }

            // Verificar si el ID y la contraseña coinciden
            var match = await _context.Professors
                .Where(p => p.Id == id && p.Password == password)
                .Select(p => new { p.Name, p.Email })
                .FirstOrDefaultAsync();

            if (match != null)
            {
                return 1; // Autenticación exitosa
            }

            return 0; // Contraseña incorrecta
        }


        [HttpPut]
        [Route("[action]")]
        public async Task<IActionResult> EditProfessor(string id, [FromBody] Professor updatedProfessor)
        {
            var professor = await _context.Professors.FindAsync(id);
            if (professor == null)
            {
                return NotFound("Profesor no encontrado.");
            }

            // Actualizar los campos permitidos
            professor.Name = updatedProfessor.Name;
            professor.LastName = updatedProfessor.LastName;
            professor.Password = updatedProfessor.Password;
            professor.Email = updatedProfessor.Email;
            professor.Photo = updatedProfessor.Photo;

            try
            {
                await _context.SaveChangesAsync();
                return Ok("Profesor actualizado correctamente.");
            }
            catch (Exception ex)
            {
                return BadRequest($"Error al actualizar el profesor: {ex.Message}");
            }
        }






    }
}
