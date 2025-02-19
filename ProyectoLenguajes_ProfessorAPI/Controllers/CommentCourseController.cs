using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoLenguajes_ProfessorAPI.Models;

namespace ProyectoLenguajes_ProfessorAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentCourseController : ControllerBase
    {

        private readonly Asc2DevProfessorContext _context;

        public CommentCourseController(IConfiguration _configuration)
        {
            _context = new Asc2DevProfessorContext(_configuration);
        }


        [HttpGet]
        [Route("[action]")]
        public async Task<ActionResult<IEnumerable<CommentCourse>>> GetComments(string acronym)
        {
            try
            {
                var comments = await _context.CommentCourses.Where(c => c.Acronym == acronym)
                    .Select(commentItem => new CommentCourse()
                    {
                        IdCommentC = commentItem.IdCommentC,
                        Acronym = commentItem.Acronym,
                        ContentC = string.IsNullOrEmpty(commentItem.ContentC) ? "[Comentario vacio]" : commentItem.ContentC,
                        Date =  commentItem.Date,
                        IdUser = commentItem.IdUser
                    }).ToListAsync();


                if (comments.Count == 0)
                {
                    return NotFound();
                }

                return Ok(comments);
            }
            catch (Exception)
            {
                throw;
            }
        }


        [HttpPost]
        [Route("PostComment")]
        public async Task<ActionResult<CommentCourse>> PostComment(CommentCourse commentCourse)
        {

            _context.CommentCourses.Add(commentCourse);
            
            await _context.SaveChangesAsync();

            return Ok(commentCourse);
        }
    }
}
