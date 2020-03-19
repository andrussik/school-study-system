using System.Collections.Generic;
using System.Linq;
using Domain;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace WebApp.Pages
{
    public class SubjectsHome : PageModel
    {
        private readonly DAL.AppDbContext _context;
        
        public SubjectsHome(DAL.AppDbContext context)
        {
            _context = context;
        }

        public ICollection<SubjectSemester> SubjectSemesters { get; set; }
        
        public void OnGet()
        {
            SubjectSemesters = _context.SubjectSemesters
                .Include(a => a.Semester)
                .Include(a => a.Subject)
                .Include(a => a.PersonSubjectSemesters).ThenInclude(b => b.Person)
                .Include(a => a.PersonSubjectSemesters).ThenInclude(b => b.Role)
                .ToList();
        }
    }
}