using System;
using System.Collections.Generic;

namespace ProyectoLenguajes_ProfessorAPI.Models;

public partial class Course
{
    public string Acronym { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public int? Cycle { get; set; }

    public int? Semester { get; set; }

    public int? Quota { get; set; }

    public string? IdProfessor { get; set; }

    public virtual ICollection<CommentCourse> CommentCourses { get; set; } = new List<CommentCourse>();

    public virtual Professor? IdProfessorNavigation { get; set; }
}
