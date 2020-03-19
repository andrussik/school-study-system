using System.Collections.Generic;
using System.Threading.Tasks;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace WebApp.Pages.PersonSubjectSemesters
{
    public class PersonSubjectGrades : PageModel
    {
        private readonly DAL.AppDbContext _context;

        public PersonSubjectGrades(DAL.AppDbContext context)
        {
            _context = context;
        }

        public Person Person { get; set; }
        public PersonSubjectSemester PersonSubjectSemester { get; set; }
        
        public async Task<ActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            PersonSubjectSemester = await _context.PersonSubjectSemesters
                .Include(a => a.Person)
                .Include(a => a.Role)
                .Include(a => a.Grades)
                .Include(a => a.SubjectSemester).ThenInclude(b => b.Semester)
                .Include(a => a.SubjectSemester).ThenInclude(b => b.Subject)
                .FirstOrDefaultAsync(a => a.PersonSubjectSemesterId == id);

            return Page();
        }
    }
}