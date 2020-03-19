using System.Linq;
using System.Threading.Tasks;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace WebApp.Pages
{
    public class SubjectInfo : PageModel
    {
        private readonly DAL.AppDbContext _context;
        
        public SubjectInfo(DAL.AppDbContext context)
        {
            _context = context;
        }

        public SubjectSemester SubjectSemester { get; set; }
        public int TotalStudents { get; set; }
        public bool GradesAvailable { get; set; }

        public async Task<ActionResult> OnGet(int? id)
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

            TotalStudents = 0;

            foreach (var personSubjectSemester in SubjectSemester.PersonSubjectSemesters)
            {
                if (personSubjectSemester.Role.RoleName == "Student")
                {
                    TotalStudents += 1;
                }
            }

            GradesAvailable = false;

            foreach (var subjectSemester in SubjectSemester.PersonSubjectSemesters)
            {
                if (subjectSemester.Grades.Any())
                {
                    GradesAvailable = true;
                }
            }

            return Page();
        }
    }
}