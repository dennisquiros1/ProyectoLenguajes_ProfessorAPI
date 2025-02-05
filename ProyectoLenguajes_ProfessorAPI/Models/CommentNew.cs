using System;
using System.Collections.Generic;

namespace ProyectoLenguajes_ProfessorAPI.Models;

public partial class CommentNew
{
    public string ContentC { get; set; } = null!;

    public int? IdNew { get; set; }

    public string? IdUser { get; set; }

    public int NewIdCommentN { get; set; }

    public virtual BreakingNew? IdNewNavigation { get; set; }
}
