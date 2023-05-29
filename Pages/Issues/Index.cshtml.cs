using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Inflowmation.Data;
using Inflowmation.Models;

namespace Inflowmation.Pages.Issues
{
    public class IndexModel : PageModel
    {
        private readonly Inflowmation.Data.InflowmationContext _context;

        public IndexModel(Inflowmation.Data.InflowmationContext context)
        {
            _context = context;
        }

        public IList<Issue> Issues { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Issues != null)
            {
                Issues = await _context.Issues.Include(r=>r.IssuedFor).ToListAsync();
            }
        }
    }
}
