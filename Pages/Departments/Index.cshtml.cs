﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Inflowmation.Data;
using Inflowmation.Models;

namespace Inflowmation.Pages.Departments
{
    public class IndexModel : PageModel
    {
        private readonly Inflowmation.Data.InflowmationContext _context;

        public IndexModel(Inflowmation.Data.InflowmationContext context)
        {
            _context = context;
        }

        public IList<Department> Department { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Departments != null)
            {
                Department = await _context.Departments.ToListAsync();
            }
        }
    }
}
