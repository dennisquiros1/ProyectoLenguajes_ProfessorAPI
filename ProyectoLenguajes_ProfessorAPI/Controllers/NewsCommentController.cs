using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoLenguajes_ProfessorAPI.Models;

namespace ProyectoLenguajes_ProfessorAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewsCommentController : Controller
    {

        private readonly Asc2DevProfessorContext _context;

        public NewsCommentController(IConfiguration _configuration)
        {
            _context = new Asc2DevProfessorContext(_configuration);
        }



        [HttpGet]
        [Route("[action]/{id}")]
        public async Task<ActionResult<List<CommentNew>>> GetAll(int id)
        {
            try
            {
                return await _context.CommentNews
                    .Where(newsCommentItem => newsCommentItem.IdNew == id)
                    .Select(newsCommentItem => new CommentNew
                    {
                        ContentC = newsCommentItem.ContentC,
                        IdUser = newsCommentItem.IdUser,
                        NewIdCommentN = newsCommentItem.NewIdCommentN,
                        IdNew = newsCommentItem.IdNew,
                        Date = newsCommentItem.Date
                    })
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error: " + ex.Message);
            }
        }


        [HttpGet]
        [Route("[action]/{id}")]
        public async Task<ActionResult<int>> CheckType(string id)
        {
            try
            {
                bool isProfessor = await _context.Professors.AnyAsync(p => p.Id == id);

                if (isProfessor)
                {
                    return 1;
                }

                bool isStudent = await _context.Students.AnyAsync(s => s.Id == id);

                if (isStudent)
                {
                    return -1;
                }

                return NotFound("User not found as professor or student.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error: " + ex.Message);
            }
        }


        [HttpGet]
        [Route("[action]/{id}")]
        public async Task<ActionResult<Student>> GetStudentCommentData(string id)
        {
            try
            {
                var student = await _context.Students
                    .Where(studentItem => studentItem.Id == id)
                    .Select(studentItem => new Student
                    {
                        Name = studentItem.Name,
                        Photo = studentItem.Photo
                    })
                    .FirstOrDefaultAsync();

                if (student == null)
                {
                    return NotFound();
                }

                return Ok(student);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error: " + ex.Message);
            }
        }



        [HttpGet]
        [Route("[action]/{id}")]
        public async Task<ActionResult<Professor>> GetProfessorCommentData(string id)
        {
            try
            {
                var professor = await _context.Professors
                    .Where(professorItem => professorItem.Id == id)
                    .Select(professorItem => new Professor
                    {
                        Name = professorItem.Name,
                        Photo = professorItem.Photo
                    })
                    .FirstOrDefaultAsync();

                if (professor == null)
                {
                    return NotFound();
                }

                return Ok(professor);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error: " + ex.Message);
            }
        }


    }


}


   