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

    }
}
