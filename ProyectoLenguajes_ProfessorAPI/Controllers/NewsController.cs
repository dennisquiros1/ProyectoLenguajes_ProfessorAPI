using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoLenguajes_ProfessorAPI.Models;

namespace ProyectoLenguajes_ProfessorAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewsController : Controller
    {

        private readonly Asc2DevProfessorContext _context;

        public NewsController(IConfiguration _configuration)
        {
            _context = new Asc2DevProfessorContext(_configuration);
        }



        [HttpGet]
        [Route("[action]")]
        public async Task<ActionResult<List<BreakingNew>>> GetAll()
        {
            try
            {
                return await _context.BreakingNews
                    .Select(newsItem => new BreakingNew
                    {
                        Date = newsItem.Date,
                        Title = newsItem.Title,
                        Paragraph = newsItem.Paragraph,
                        Photo = newsItem.Photo,
                        IdNew = newsItem.IdNew
                    })
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error: " + ex.Message);
            }
        }



    }
}
