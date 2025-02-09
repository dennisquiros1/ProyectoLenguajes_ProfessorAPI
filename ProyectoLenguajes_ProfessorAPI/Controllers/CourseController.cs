using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoLenguajes_ProfessorAPI.Models;

namespace ProyectoLenguajes_ProfessorAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {

        private readonly Asc2DevProfessorContext _context;

        public CourseController(IConfiguration _configuration)
        {
            _context = new Asc2DevProfessorContext(_configuration);
        }


        [HttpGet]
        [Route("[action]")]
        public async Task<ActionResult<IEnumerable<Course>>> GetByCycle(int cycle)
        {
            try
            {
                var courses = await _context.Courses.Where(c => c.Cycle== cycle)
                    .Select(courseItem => new Course()
                    {
                        Acronym = courseItem.Acronym,
                        Name = courseItem.Name,
                        Description = courseItem.Description,
                        Cycle = courseItem.Cycle,
                        Semester = courseItem.Semester,
                        Quota = courseItem.Quota,
                        IdProfessor = courseItem.IdProfessor
                    }).ToListAsync();


                if (courses.Count == 0)
                {
                    return NotFound();
                }

                return courses;
            }
            catch (Exception)
            {
                throw;
            }
        }





        [HttpGet]
        [Route("[action]")]
        public async Task<ActionResult<Course>> GetByAcronym(string acronym)
        {
            try
            {
                var course = await _context.Courses.FirstOrDefaultAsync(c => c.Acronym == acronym);

                if (course == null)
                {
                    return NotFound();
                }

                return course;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
