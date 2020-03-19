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

namespace WebApp.Pages.PersonSubjectSemesters
{
    public class CreateModel : PageModel
    {
        private readonly DAL.AppDbContext _context;

        public CreateModel(DAL.AppDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet(int? personId)
        {
            if (personId == null)
            {
                return NotFound();
            }
            
            ViewData["PersonId"] = new SelectList(_context.Persons, "PersonId", "FirstLastName", personId);
            ViewData["RoleId"] = new SelectList(_context.Roles, "RoleId", "RoleName");
            ViewData["SubjectSemesterId"] = new SelectList(_context.SubjectSemesters
                .Include(a => a.Semester)
                .Include(a => a.Subject), "SubjectSemesterId", "SubjectSemesterName");

            PersonId = personId.Value;
            
            return Page();
        }

        [BindProperty]
        public PersonSubjectSemester PersonSubjectSemester { get; set; }

        public int PersonId { get; set; }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int? personId)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.PersonSubjectSemesters.Add(PersonSubjectSemester);
            await _context.SaveChangesAsync();
            
            return RedirectToPage("./Index", new {id = personId});
        }
    }
}
