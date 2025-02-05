using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ProyectoLenguajes_ProfessorAPI.Models;

public partial class Asc2DevProfessorContext : DbContext
{
    private readonly IConfiguration _configuration;

    public Asc2DevProfessorContext()
    {
    }


    public Asc2DevProfessorContext(IConfiguration configuration)
    {
        _configuration = configuration;
    }


    public Asc2DevProfessorContext(DbContextOptions<Asc2DevProfessorContext> options)
        : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
       => optionsBuilder.UseSqlServer(_configuration.GetConnectionString("DefaultConnection"));

    public virtual DbSet<Administrator> Administrators { get; set; }

    public virtual DbSet<ApplicationConsultation> ApplicationConsultations { get; set; }

    public virtual DbSet<BreakingNew> BreakingNews { get; set; }

    public virtual DbSet<CommentCourse> CommentCourses { get; set; }

    public virtual DbSet<CommentNew> CommentNews { get; set; }

    public virtual DbSet<Course> Courses { get; set; }

    public virtual DbSet<PrivateConsultation> PrivateConsultations { get; set; }

    public virtual DbSet<Professor> Professors { get; set; }

    public virtual DbSet<RegistrationApplication> RegistrationApplications { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Administrator>(entity =>
        {
            entity.HasKey(e => e.IdAdministrator);

            entity.ToTable("Administrator", "edu");

            entity.Property(e => e.IdAdministrator).HasMaxLength(50);
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.LastName).HasMaxLength(70);
            entity.Property(e => e.Name).HasMaxLength(70);
            entity.Property(e => e.Password).HasMaxLength(50);
        });

        modelBuilder.Entity<ApplicationConsultation>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_SoliciteConsultation");

            entity.ToTable("ApplicationConsultation", "edu");

            entity.Property(e => e.Answer).HasMaxLength(500);
            entity.Property(e => e.IdProfessor)
                .HasMaxLength(50)
                .HasColumnName("Id_Professor");
            entity.Property(e => e.IdStudent)
                .HasMaxLength(50)
                .HasColumnName("Id_Student");
            entity.Property(e => e.Text).HasMaxLength(500);

            entity.HasOne(d => d.IdProfessorNavigation).WithMany(p => p.ApplicationConsultations)
                .HasForeignKey(d => d.IdProfessor)
                .HasConstraintName("FK_ApplicationConsultation_Professor");

            entity.HasOne(d => d.IdStudentNavigation).WithMany(p => p.ApplicationConsultations)
                .HasForeignKey(d => d.IdStudent)
                .HasConstraintName("FK_ApplicationConsultation_Id_Student");
        });

        modelBuilder.Entity<BreakingNew>(entity =>
        {
            entity.HasKey(e => e.IdNew).HasName("PK_BreakingNews");

            entity.ToTable("BreakingNew", "edu");

            entity.Property(e => e.IdNew).HasColumnName("idNew");
            entity.Property(e => e.Paragraph).HasMaxLength(1500);
            entity.Property(e => e.Photo).IsUnicode(false);
            entity.Property(e => e.Title).HasMaxLength(50);
        });

        modelBuilder.Entity<CommentCourse>(entity =>
        {
            entity.HasKey(e => e.IdCommentC).HasName("PK_CommentCourses");

            entity.ToTable("CommentCourse", "edu");

            entity.Property(e => e.Acronym).HasMaxLength(50);
            entity.Property(e => e.ContentC).HasMaxLength(500);
            entity.Property(e => e.IdUser)
                .HasMaxLength(50)
                .HasColumnName("Id_User");

            entity.HasOne(d => d.AcronymNavigation).WithMany(p => p.CommentCourses)
                .HasForeignKey(d => d.Acronym)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CommentCourses_Course");
        });

        modelBuilder.Entity<CommentNew>(entity =>
        {
            entity.HasKey(e => e.NewIdCommentN);

            entity.ToTable("CommentNew", "edu");

            entity.Property(e => e.ContentC).HasMaxLength(500);
            entity.Property(e => e.IdNew).HasColumnName("Id_New");
            entity.Property(e => e.IdUser)
                .HasMaxLength(50)
                .HasColumnName("Id_User");

            entity.HasOne(d => d.IdNewNavigation).WithMany(p => p.CommentNews)
                .HasForeignKey(d => d.IdNew)
                .HasConstraintName("FK_CommentNews_BreakingNew");
        });

        modelBuilder.Entity<Course>(entity =>
        {
            entity.HasKey(e => e.Acronym);

            entity.ToTable("Course", "edu");

            entity.Property(e => e.Acronym).HasMaxLength(50);
            entity.Property(e => e.Description).HasMaxLength(1000);
            entity.Property(e => e.IdProfessor)
                .HasMaxLength(50)
                .HasColumnName("Id_Professor");
            entity.Property(e => e.Name).HasMaxLength(50);

            entity.HasOne(d => d.IdProfessorNavigation).WithMany(p => p.Courses)
                .HasForeignKey(d => d.IdProfessor)
                .HasConstraintName("FK_Course_Professor");
        });

        modelBuilder.Entity<PrivateConsultation>(entity =>
        {
            entity.ToTable("PrivateConsultation", "edu");

            entity.Property(e => e.Answer).HasMaxLength(500);
            entity.Property(e => e.IdProfessor)
                .HasMaxLength(50)
                .HasColumnName("Id_Professor");
            entity.Property(e => e.IdStudent)
                .HasMaxLength(50)
                .HasColumnName("Id_Student");
            entity.Property(e => e.Text).HasMaxLength(500);

            entity.HasOne(d => d.IdProfessorNavigation).WithMany(p => p.PrivateConsultations)
                .HasForeignKey(d => d.IdProfessor)
                .HasConstraintName("FK_PrivateConsultation_Professor");

            entity.HasOne(d => d.IdStudentNavigation).WithMany(p => p.PrivateConsultations)
                .HasForeignKey(d => d.IdStudent)
                .HasConstraintName("FK_PrivateConsultation_Id_Student");
        });

        modelBuilder.Entity<Professor>(entity =>
        {
            entity.ToTable("Professor", "edu");

            entity.Property(e => e.Id).HasMaxLength(50);
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.Expertise).HasMaxLength(200);
            entity.Property(e => e.LastName).HasMaxLength(50);
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.Password).HasMaxLength(70);
            entity.Property(e => e.Photo).IsUnicode(false);
        });

        modelBuilder.Entity<RegistrationApplication>(entity =>
        {
            entity.ToTable("RegistrationApplication", "edu");

            entity.Property(e => e.Answer).HasMaxLength(150);
            entity.Property(e => e.IdStudent)
                .HasMaxLength(50)
                .HasColumnName("Id_Student");

            entity.HasOne(d => d.IdStudentNavigation).WithMany(p => p.RegistrationApplications)
                .HasForeignKey(d => d.IdStudent)
                .HasConstraintName("FK_RegistrationApplication_Id_Student");
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.ToTable("Student", "edu");

            entity.Property(e => e.Id).HasMaxLength(50);
            entity.Property(e => e.Email).HasMaxLength(70);
            entity.Property(e => e.LastName).HasMaxLength(50);
            entity.Property(e => e.Likings).HasMaxLength(200);
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.Password).HasMaxLength(70);
            entity.Property(e => e.Photo).IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
