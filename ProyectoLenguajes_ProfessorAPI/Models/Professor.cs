using System;
using System.Collections.Generic;

namespace ProyectoLenguajes_ProfessorAPI.Models;

public partial class Professor
{
    public string Id { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string Email { get; set; } = null!;

    public short Active { get; set; }

    public string? Photo { get; set; }

    public string? Expertise { get; set; }

    public virtual ICollection<ApplicationConsultation> ApplicationConsultations { get; set; } = new List<ApplicationConsultation>();

    public virtual ICollection<Course> Courses { get; set; } = new List<Course>();

    public virtual ICollection<PrivateConsultation> PrivateConsultations { get; set; } = new List<PrivateConsultation>();
}
