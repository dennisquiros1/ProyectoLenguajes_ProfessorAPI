using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace ProyectoLenguajes_ProfessorAPI.Models;

public partial class Student
{
    public string Id { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string? Likings { get; set; }

    public string? Photo { get; set; }

    public short Active { get; set; }

    public short Register { get; set; }

    public short Asociation { get; set; }

    [JsonIgnore]
    public virtual ICollection<ApplicationConsultation> ApplicationConsultations { get; set; } = new List<ApplicationConsultation>();

    [JsonIgnore]
    public virtual ICollection<PrivateConsultation> PrivateConsultations { get; set; } = new List<PrivateConsultation>();

    [JsonIgnore]
    public virtual ICollection<RegistrationApplication> RegistrationApplications { get; set; } = new List<RegistrationApplication>();
}
