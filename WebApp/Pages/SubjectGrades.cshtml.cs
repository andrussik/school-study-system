using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace WebApp.Pages
{
    public class SubjectGrades : PageModel
    {
        private readonly DAL.AppDbContext _context;
        
        public SubjectGrades(DAL.AppDbContext context)
        {
            _context = context;
        }

        public SubjectSemester SubjectSemester { get; set; }
        public ICollection<PersonSubjectSemester> PersonSubjectSemesters { get; set; }

        public ICollection<Grade> Grades { get; set; }
        public string AverageGrade { get; set; }
        
        public async Task<ActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            
            SubjectSemester = await _context.SubjectSemesters
                .Include(a => a.Semester)
                .Include(a => a.Subject)
                .Include(a => a.PersonSubjectSemesters).ThenInclude(b => b.Person)
                .Include(a => a.PersonSubjectSemesters).ThenInclude(b => b.Role)
                .Include(a => a.PersonSubjectSemesters).ThenInclude(b => b.Grades)
                .FirstOrDefaultAsync(a => a.SubjectSemesterId == id);

            if (SubjectSemester == null)
            {
                return NotFound();
            }

            PersonSubjectSemesters = SubjectSemester.PersonSubjectSemesters.ToList();

            var peopleWithGrades = SubjectSemester.PersonSubjectSemesters
                .Where(a => a.Grades.Any())
                .ToList();

            if (peopleWithGrades.Any())
            {
                Grades = new List<Grade>();
                foreach (var peopleWithGrade in peopleWithGrades)
                {
                    foreach (var peopleGrade in peopleWithGrade.Grades)
                    {
                        Grades.Add(peopleGrade);
                    }
                }
            }

            var personSubjects = SubjectSemester.PersonSubjectSemesters
                .Where(a => a.Grades.Any(b => b.GradeNumber != null))
                .ToList();
            
            var grade = -1;
            var count = 0;

            if (personSubjects.Any())
            {
                grade = 0;
                
                foreach (var personSubject in personSubjects)
                {
                    foreach (var personGrade in personSubject.Grades)
                    {
                        if (personGrade.GradeNumber != null)
                        {
                            grade += personGrade.GradeNumber.Value;
                            count++;
                        }
                    }
                }
            }

            if (grade != -1)
            {
                AverageGrade = Math.Round((double) grade/count, 2).ToString();
            }
            
            
            
            return Page();
        }
    }
}