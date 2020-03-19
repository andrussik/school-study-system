using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using DAL;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace WebApp.Pages.Grades
{
    public class CreateModel : PageModel
    {
        private readonly DAL.AppDbContext _context;

        public CreateModel(DAL.AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> OnGetAsync(int? subjectSemesterId)
        { 
            ViewData["PersonSubjectSemesterId"] = new SelectList(_context.PersonSubjectSemesters
            .Include(a => a.Grades).ThenInclude(b => b.PersonSubjectSemester). ThenInclude(c => c.SubjectSemester)
            .Include(a => a.Person)
            .Include(a => a.SubjectSemester).ThenInclude(b => b.Subject)
            .Include(a => a.SubjectSemester).ThenInclude(b => b.Semester)
            .Where(a => a.SubjectSemesterId == subjectSemesterId)
            .Where(a => a.Role.RoleName == "Student"), "PersonSubjectSemesterId", "PersonName");
            
            SubjectSemester = await _context.SubjectSemesters
                .Include(a => a.Subject)
                .Include(a => a.Semester)
                .FirstOrDefaultAsync(a => a.SubjectSemesterId == subjectSemesterId);

            if (SubjectSemester == null)
            {
                return NotFound();
            }
            
            return Page();
        }

        [BindProperty]
        public Grade Grade { get; set; }

        public SubjectSemester SubjectSemester { get; set; }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int? subjectSemesterId)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Grades.Add(Grade);
            await _context.SaveChangesAsync();

            return RedirectToPage("/SubjectGrades", new {id = subjectSemesterId});
        }
    }
}
