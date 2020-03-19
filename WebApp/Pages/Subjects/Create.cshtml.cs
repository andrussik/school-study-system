using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using DAL;
using Domain;

namespace WebApp.Pages.Subjects
{
    public class CreateModel : PageModel
    {
        private readonly DAL.AppDbContext _context;

        public CreateModel(DAL.AppDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["SemesterId"] = new SelectList(_context.Semesters, "SemesterId", "SemesterName");
            
            return Page();
        }

        [BindProperty]
        public Subject Subject { get; set; }
        
        [BindProperty]
        [Display(Name = "Semester")]
        public int[] SemesterIds { get; set;}

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            
            foreach (var id in SemesterIds)
            {
                var semester = _context.Semesters.FindAsync(id).Result;
                
                var subjectSemester = new SubjectSemester()
                {
                    Subject = Subject,
                    Semester = semester
                };
                
                _context.SubjectSemesters.Add(subjectSemester);
            }

            _context.Subjects.Add(Subject);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
