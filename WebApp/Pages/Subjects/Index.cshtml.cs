using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DAL;
using Domain;

namespace WebApp.Pages.Subjects
{
    public class IndexModel : PageModel
    {
        private readonly DAL.AppDbContext _context;

        public IndexModel(DAL.AppDbContext context)
        {
            _context = context;
        }

        public IList<Subject> Subject { get;set; }
        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }

        public async Task OnGetAsync()
        {
            Subject = await _context.Subjects.ToListAsync();
        }
        
        public async Task OnGetSearchAsync()
        {
            Subject = await _context.Subjects.ToListAsync();
            
            var search = SearchString;
            
            if (!string.IsNullOrWhiteSpace(search))
            {
                search = SearchString.ToLower().Trim();
            }
            
            var subjectQuery = _context.Subjects
                .AsQueryable();

            if (!string.IsNullOrEmpty(search))
            {
                subjectQuery = subjectQuery.Where(s =>
                    s.SubjectName.ToLower().Contains(search)
                );

                subjectQuery = subjectQuery.OrderBy(a => a.SubjectName);

                Subject = await subjectQuery.ToListAsync();
            }
        }
    }
}
