using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DAL;
using Domain;

namespace WebApp.Pages.PersonSubjectSemesters
{
    public class IndexModel : PageModel
    {
        private readonly DAL.AppDbContext _context;

        public IndexModel(DAL.AppDbContext context)
        {
            _context = context;
        }

        public Person Person { get; set; }
        public ICollection<PersonSubjectSemester> PersonSubjectSemesters { get; set; }
        public int GainedETCS { get; set; }
        public string AverageGrade { get; set; }
        
        public async Task<ActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Person = await _context.Persons
                .Include(a => a.PersonSubjectSemesters).ThenInclude(b => b.Role)
                .Include(a => a.PersonSubjectSemesters).ThenInclude(b => b.Grades)
                .Include(a => a.PersonSubjectSemesters).ThenInclude(b => b.SubjectSemester).ThenInclude(c => c.Semester)
                .Include(a => a.PersonSubjectSemesters).ThenInclude(b => b.SubjectSemester).ThenInclude(c => c.Subject)
                .FirstOrDefaultAsync(a => a.PersonId == id);

            PersonSubjectSemesters = _context.PersonSubjectSemesters
                .Where(a => a.PersonId == id)
                .Include(a => a.Grades)
                .Include(a => a.Person)
                .Include(a => a.Role)
                .Include(a => a.SubjectSemester).ThenInclude(b => b.Semester)
                .Include(a => a.SubjectSemester).ThenInclude(b => b.Subject)
                .ToList();

            if (PersonSubjectSemesters == null)
            {
                return NotFound();
            }

            var avgGrade = -1;
            int count = 0;

            foreach (var personSubject in PersonSubjectSemesters)
            {
                if (personSubject.Grades.Any())
                {
                    if (avgGrade == -1)
                    {
                        avgGrade = 0;
                    }
                    
                    foreach (var grade in personSubject.Grades)
                    {
                        if (grade.GradeNumber != null)
                        {
                            count++;
                            avgGrade += grade.GradeNumber.Value;
                        }
                    }
                }
            }

            if (avgGrade != -1)
            {
                AverageGrade = Math.Round((double) avgGrade/count, 2).ToString();

            }

            var ETCS = -1;

            foreach (var personSubjectSemester in PersonSubjectSemesters)
            {
                if (personSubjectSemester.Grades.Any())
                {
                    ETCS = 0;
                    
                    foreach (var grade in personSubjectSemester.Grades)
                    {
                        if (grade.IsPassed)
                        {
                            ETCS += personSubjectSemester.SubjectSemester.Subject.ECTS;
                        }
                    }
                }
            }

            GainedETCS = ETCS; 
            
            return Page();
        }
    }
}
