using System;
using System.Collections.Generic;
using Newtonsoft.Json;

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

    [JsonIgnore]
    public virtual ICollection<CommentCourse> CommentCourses { get; set; } = new List<CommentCourse>();
    [JsonIgnore]
    public virtual Professor? IdProfessorNavigation { get; set; }
}
