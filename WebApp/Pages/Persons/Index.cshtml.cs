using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DAL;
using Domain;

namespace WebApp.Pages.Persons
{
    public class IndexModel : PageModel
    {
        private readonly DAL.AppDbContext _context;

        public IndexModel(DAL.AppDbContext context)
        {
            _context = context;
        }

        public IList<Person> Person { get;set; }
        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }

        public async Task OnGetAsync()
        {
            Person = await _context.Persons.ToListAsync();
        }

        public async Task OnGetSearchAsync()
        {
            Person = await _context.Persons.ToListAsync();
            
            var search = SearchString;
            
            if (!string.IsNullOrWhiteSpace(search))
            {
                search = SearchString.ToLower().Trim();
            }
            
            var personQuery = _context.Persons
                .Include(a => a.PersonSubjectSemesters)
                .AsQueryable();

            if (!string.IsNullOrEmpty(search))
            {
                personQuery = personQuery.Where(s =>
                    s.FirstName.ToLower().Contains(search) ||
                    s.LastName.ToLower().Contains(search) ||
                    s.IdCode.ToLower().Contains(search) ||
                    s.StudentCode.ToLower().Contains(search)
                );

                personQuery = personQuery.OrderBy(a => a.FirstName);

                Person = await personQuery.ToListAsync();
            }
        }
    }
}
