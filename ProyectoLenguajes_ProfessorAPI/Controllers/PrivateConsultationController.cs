using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoLenguajes_ProfessorAPI.Models;

namespace ProyectoLenguajes_ProfessorAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrivateConsultationController : ControllerBase
    {
        private readonly Asc2DevProfessorContext _context;

        public PrivateConsultationController(IConfiguration configuration)
        {
            _context = new Asc2DevProfessorContext(configuration);
        }

        [HttpGet]
        [Route("[action]/{idProfessor}")]
        public async Task<ActionResult<IEnumerable<PrivateConsultation>>> GetPrivateByProfessor(string idProfessor)
        {
            try
            {
                var consultations = await _context.PrivateConsultations.Where(c => c.Status == 0 && c.IdProfessor == idProfessor).ToListAsync();

                if (consultations.Count == 0)
                {
                    return NotFound();
                }
                else
                {
                    return consultations;
                }
            }catch (Exception)
            {
                throw;
            }    
        }

        [HttpGet]
        [Route("[action]/{id}")]
        public async Task<ActionResult<PrivateConsultation>> Get (int id)
        {
            try
            {
                var consultation = await _context.PrivateConsultations.Where(c => c.Id == id).FirstOrDefaultAsync();

                if (consultation == null)
                {
                    return NotFound();
                }
                else
                {
                    return consultation;
                }
            } catch (Exception)
            {
                throw;
            }
        }

        [HttpPut]
        [Route("[action]")]
        public async Task<IActionResult> Put(PrivateConsultation consultation)
        {
            try
            {
                _context.Entry(consultation).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return NoContent();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
