using System;
using System.Collections.Generic;

namespace ProyectoLenguajes_ProfessorAPI.Models;

public partial class PrivateConsultation
{
    public int Id { get; set; }

    public string Text { get; set; } = null!;

    public short Status { get; set; }

    public string? Answer { get; set; }

    public string? IdStudent { get; set; }

    public string? IdProfessor { get; set; }

    public Professor? IdProfessorNavigation { get; set; }

    public Student? IdStudentNavigation { get; set; }
}
