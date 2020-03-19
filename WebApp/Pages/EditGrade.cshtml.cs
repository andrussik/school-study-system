using System;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace WebApp.Pages
{
    public class EditGrade : PageModel
    {
        
        private readonly DAL.AppDbContext _context;
        
        public EditGrade(DAL.AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Grade Grade { get; set; }
        
        public async Task<ActionResult> OnGet(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Grade = await _context.Grades
                .Include(a => a.PersonSubjectSemester)
                .Include(a => a.PersonSubjectSemester).ThenInclude(b => b.Role)
                .Include(a => a.PersonSubjectSemester).ThenInclude(b => b.Person)
                .Include(a => a.PersonSubjectSemester).ThenInclude(b => b.SubjectSemester)
                .Include(a => a.PersonSubjectSemester).ThenInclude(b => b.SubjectSemester).ThenInclude(c => c.Semester)
                .Include(a => a.PersonSubjectSemester).ThenInclude(b => b.SubjectSemester).ThenInclude(c => c.Subject)
                .FirstOrDefaultAsync(a => a.GradeId == id);
                // .Include(g => g.PersonSubjectSemester).FirstOrDefaultAsync(m => m.GradeId == id);


            ViewData["PersonSubjectSemesterId"] = new SelectList(_context.PersonSubjectSemesters, "PersonSubjectSemesterId", "PersonSubjectSemesterId");
                
            if (Grade == null)
            {
                return NotFound();
            }

            return Page();
        }
        
        public async Task<IActionResult> OnPostAsync(int id)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            Console.WriteLine(Grade.GradeId);
            Console.WriteLine(Grade.GradeNumber);

            _context.Attach(Grade).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GradeExists(Grade.GradeId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            var grade = _context.Grades
                .Include(a => a.PersonSubjectSemester)
                .ThenInclude(b => b.SubjectSemester)
                .FirstOrDefaultAsync(a => a.GradeId == id).Result;
            var subjectGradeId = grade.PersonSubjectSemester.SubjectSemester.SubjectSemesterId;

            return RedirectToPage("./SubjectGrades", new {id = subjectGradeId});
        }

        private bool GradeExists(int id)
        {
            return _context.Grades.Any(e => e.GradeId == id);
        }
    }
}