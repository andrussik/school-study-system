using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace WebApp.Pages.Persons
{
    public class PersonSubjects : PageModel
    {
        
        private readonly DAL.AppDbContext _context;

        public PersonSubjects(DAL.AppDbContext context)
        {
            _context = context;
        }

        public Person Person { get; set; }
        public ICollection<PersonSubjectSemester> PersonSubjectSemesters { get; set; }
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
                            avgGrade += grade.GradeNumber.Value;
                        }
                    }
                }
                
            }
            
            return Page();
        }
    }
}