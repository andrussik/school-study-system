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

namespace WebApp.Pages.SubjectSemesters
{
    public class EditModel : PageModel
    {
        private readonly DAL.AppDbContext _context;

        public EditModel(DAL.AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public SubjectSemester SubjectSemester { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            SubjectSemester = await _context.SubjectSemesters
                .Include(s => s.Semester)
                .Include(s => s.Subject).FirstOrDefaultAsync(m => m.SubjectSemesterId == id);

            if (SubjectSemester == null)
            {
                return NotFound();
            }
           ViewData["SemesterId"] = new SelectList(_context.Semesters, "SemesterId", "SemesterName");
           ViewData["SubjectId"] = new SelectList(_context.Subjects, "SubjectId", "Description");
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

            _context.Attach(SubjectSemester).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SubjectSemesterExists(SubjectSemester.SubjectSemesterId))
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

        private bool SubjectSemesterExists(int id)
        {
            return _context.SubjectSemesters.Any(e => e.SubjectSemesterId == id);
        }
    }
}
