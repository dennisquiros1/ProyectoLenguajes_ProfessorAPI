using System;
using System.Collections.Generic;
using Newtonsoft.Json;

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

    [JsonIgnore]
    public virtual ICollection<ApplicationConsultation> ApplicationConsultations { get; set; } = new List<ApplicationConsultation>();

    [JsonIgnore]
    public virtual ICollection<Course> Courses { get; set; } = new List<Course>();

    [JsonIgnore]
    public virtual ICollection<PrivateConsultation> PrivateConsultations { get; set; } = new List<PrivateConsultation>();
}
