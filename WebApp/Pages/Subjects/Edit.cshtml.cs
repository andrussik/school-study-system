using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DAL;
using Domain;

namespace WebApp.Pages.Subjects
{
    public class EditModel : PageModel
    {
        private readonly DAL.AppDbContext _context;

        public EditModel(DAL.AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Subject Subject { get; set; }
        [BindProperty] 
        public int[] SemesterIds { get; set;}

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            
            ViewData["SemesterId"] = new SelectList(_context.Semesters, "SemesterId", "SemesterName");

            Subject = await _context.Subjects
                .Include(a => a.SubjectSemesters).ThenInclude(b => b.Semester)
                .Include(a => a.SubjectSemesters).ThenInclude(b => b.Subject)
                .FirstOrDefaultAsync(m => m.SubjectId == id);

            if (Subject == null)
            {
                return NotFound();
            }
            return Page();
        }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            
            var subjectSemesters = _context.SubjectSemesters.Where(a => a.SubjectId == Subject.SubjectId);

            foreach (var subjectSemester in subjectSemesters)
            {
                _context.SubjectSemesters.Remove(subjectSemester);
            }
            
            foreach (var semesterId in SemesterIds)
            {
                var semester = _context.Semesters.FindAsync(semesterId).Result;
                
                var subjectSemester = new SubjectSemester()
                {
                    Subject = Subject,
                    Semester = semester
                };

                _context.SubjectSemesters.Add(subjectSemester);
            }

            _context.Attach(Subject).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SubjectExists(Subject.SubjectId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool SubjectExists(int id)
        {
            return _context.Subjects.Any(e => e.SubjectId == id);
        }
    }
}
