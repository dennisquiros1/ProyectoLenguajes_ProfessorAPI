using System;
using System.Collections.Generic;

namespace ProyectoLenguajes_ProfessorAPI.Models;

public partial class CommentCourse
{
    public int IdCommentC { get; set; }

    public string ContentC { get; set; } = null!;

    public string Acronym { get; set; } = null!;

    public string? IdUser { get; set; }

    public virtual Course AcronymNavigation { get; set; } = null!;
}
