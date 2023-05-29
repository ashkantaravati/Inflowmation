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
    public class DetailsModel : PageModel
    {
        private readonly Inflowmation.Data.InflowmationContext _context;

        public DetailsModel(Inflowmation.Data.InflowmationContext context)
        {
            _context = context;
        }

      public Issue Issue { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Issues == null)
            {
                return NotFound();
            }

            var issue = await _context.Issues.FirstOrDefaultAsync(m => m.Id == id);
            if (issue == null)
            {
                return NotFound();
            }
            else 
            {
                Issue = issue;
            }
            return Page();
        }
    }
}
