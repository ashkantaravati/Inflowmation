using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Inflowmation.Data;
using Inflowmation.Models;

namespace Inflowmation.Pages.Issues
{
    public class CreateModel : PageModel
    {
        private readonly Inflowmation.Data.InflowmationContext _context;

        public CreateModel(Inflowmation.Data.InflowmationContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            AvailableDepartments = _context.Departments.Select(d => new SelectListItem
            {
                Value = d.Id.ToString(),
                Text = d.Name
            }).ToList();
            return Page();
        }

        [BindProperty]
        public Issue Issue { get; set; } = default!;

        [BindProperty]
        public int IssuedForId { get; set; }

        public List<SelectListItem> AvailableDepartments { get; set; }


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || _context.Issues == null || Issue == null)
            {
                return Page();
            }
            var destinationDepartment = _context.Departments.FirstOrDefault(d => d.Id == IssuedForId);

            Issue.IssuedFor = destinationDepartment;

            Issue.CreatedAt = DateTime.Now;

            Issue.UpdatedAt = DateTime.Now;

            _context.Issues.Add(Issue);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
