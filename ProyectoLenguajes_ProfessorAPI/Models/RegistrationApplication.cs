using System;
using System.Collections.Generic;

namespace ProyectoLenguajes_ProfessorAPI.Models;

public partial class RegistrationApplication
{
    public int Id { get; set; }

    public string? Answer { get; set; }

    public short Status { get; set; }

    public DateOnly? Date { get; set; }

    public string? IdStudent { get; set; }

    public virtual Student? IdStudentNavigation { get; set; }
}
