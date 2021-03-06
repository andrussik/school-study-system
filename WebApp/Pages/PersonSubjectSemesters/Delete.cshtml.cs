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
    public class DeleteModel : PageModel
    {
        private readonly DAL.AppDbContext _context;

        public DeleteModel(DAL.AppDbContext context)
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
                .Include(p => p.SubjectSemester).FirstOrDefaultAsync(m => m.PersonSubjectSemesterId == id);

            if (PersonSubjectSemester == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            PersonSubjectSemester = await _context.PersonSubjectSemesters.FindAsync(id);

            if (PersonSubjectSemester != null)
            {
                _context.PersonSubjectSemesters.Remove(PersonSubjectSemester);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
