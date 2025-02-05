using System;
using System.Collections.Generic;

namespace ProyectoLenguajes_ProfessorAPI.Models;

public partial class BreakingNew
{
    public DateOnly Date { get; set; }

    public string Title { get; set; } = null!;

    public string Paragraph { get; set; } = null!;

    public string? Photo { get; set; }

    public int IdNew { get; set; }

    public virtual ICollection<CommentNew> CommentNews { get; set; } = new List<CommentNew>();
}
