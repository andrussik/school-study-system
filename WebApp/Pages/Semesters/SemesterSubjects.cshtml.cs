using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace WebApp.Pages.Semesters
{
    public class SemesterSubjects : PageModel
    {
        private readonly DAL.AppDbContext _context;

        public SemesterSubjects(DAL.AppDbContext context)
        {
            _context = context;
        }

        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }
        public Semester Semester { get; set; }
        public ICollection<SubjectSemester> SubjectSemesters { get; set; }
        
        public async Task<ActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Console.WriteLine("ID is: " + id);
            
            Semester = await _context.Semesters.FirstOrDefaultAsync(a => a.SemesterId == id);

            if (Semester == null)
            {
                return NotFound();
            }

            SubjectSemesters = _context.SubjectSemesters
                .Include(a => a.Subject)
                .Include(a => a.Semester)
                .Where(a => a.SemesterId == id)
                .ToList();
            
            return Page();
        }
        
        public async Task OnGetSearchAsync(int? id)
        {
            SubjectSemesters = await _context.SubjectSemesters
                .Where(a => a.SemesterId == id)
                .Include(a => a.Subject)
                .Include(a => a.Semester)
                .ToListAsync();
            
            Semester = await _context.Semesters.FirstOrDefaultAsync(a => a.SemesterId == id);
            
            var search = SearchString;
            
            if (!string.IsNullOrWhiteSpace(search))
            {
                search = SearchString.ToLower().Trim();
            }
            
            var subjectSemestersQuery = _context.SubjectSemesters
                .Include(a => a.Subject)
                .Include(a => a.Semester)
                .Where(a => a.SemesterId == id)
                .AsQueryable();

            if (!string.IsNullOrEmpty(search))
            {
                subjectSemestersQuery = subjectSemestersQuery.Where(s =>
                    s.Subject.SubjectName.ToLower().Contains(search)
                );

                subjectSemestersQuery = subjectSemestersQuery.OrderBy(a => a.Subject.SubjectName);

                SubjectSemesters = await subjectSemestersQuery.ToListAsync();
            }
        }
    }
}