using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace ProyectoLenguajes_ProfessorAPI.Models;

public partial class CommentNew
{
    public string ContentC { get; set; } = null!;

    public int? IdNew { get; set; }

    public DateOnly? Date { get; set; }

    public string? IdUser { get; set; }
    public int NewIdCommentN { get; set; }

    [JsonIgnore]
    public virtual BreakingNew? IdNewNavigation { get; set; }
}
