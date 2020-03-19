using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DAL;
using Domain;

namespace WebApp.Pages.SubjectSemesters
{
    public class DetailsModel : PageModel
    {
        private readonly DAL.AppDbContext _context;

        public DetailsModel(DAL.AppDbContext context)
        {
            _context = context;
        }

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
            return Page();
        }
    }
}
