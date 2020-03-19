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

namespace WebApp.Pages.PersonSubjectSemesters
{
    public class EditModel : PageModel
    {
        private readonly DAL.AppDbContext _context;

        public EditModel(DAL.AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public PersonSubjectSemester PersonSubjectSemester { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            PersonSubjectSemester = await _context.PersonSubjectSemesters
                .Include(p => p.Person)
                .Include(p => p.Role)
                .Include(p => p.SubjectSemester).ThenInclude(b => b.Subject)
                .Include(p => p.SubjectSemester).ThenInclude(b => b.Semester)
                .FirstOrDefaultAsync(m => m.PersonSubjectSemesterId == id);

            if (PersonSubjectSemester == null)
            {
                return NotFound();
            }
           ViewData["PersonId"] = new SelectList(_context.Persons, "PersonId", "FirstLastName");
           ViewData["RoleId"] = new SelectList(_context.Roles, "RoleId", "RoleName");
           ViewData["SubjectSemesterId"] = new SelectList(_context.SubjectSemesters
               .Include(a => a.Semester)
               .Include(a => a.Subject), "SubjectSemesterId", "SubjectSemesterName");
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

            _context.Attach(PersonSubjectSemester).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PersonSubjectSemesterExists(PersonSubjectSemester.PersonSubjectSemesterId))
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

        private bool PersonSubjectSemesterExists(int id)
        {
            return _context.PersonSubjectSemesters.Any(e => e.PersonSubjectSemesterId == id);
        }
    }
}
