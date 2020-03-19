using System;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace DAL
{
    public class AppDbContext: DbContext
    {

        public DbSet<Grade> Grades { get; set; } = default!;
        public DbSet<Person> Persons { get; set; } = default!;
        public DbSet<PersonSubjectSemester> PersonSubjectSemesters { get; set; } = default!;
        public DbSet<Role> Roles { get; set; } = default!;
        public DbSet<Semester> Semesters { get; set; } = default!;
        public DbSet<Subject> Subjects { get; set; } = default!;
        public DbSet<SubjectSemester> SubjectSemesters { get; set; } = default!;

        public AppDbContext(DbContextOptions option): base(option)
        {
        }
    }
}