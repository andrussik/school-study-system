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
    public class IndexModel : PageModel
    {
        private readonly DAL.AppDbContext _context;

        public IndexModel(DAL.AppDbContext context)
        {
            _context = context;
        }

        public IList<SubjectSemester> SubjectSemester { get;set; }

        public async Task OnGetAsync()
        {
            SubjectSemester = await _context.SubjectSemesters
                .Include(s => s.Semester)
                .Include(s => s.Subject).ToListAsync();
        }
    }
}
