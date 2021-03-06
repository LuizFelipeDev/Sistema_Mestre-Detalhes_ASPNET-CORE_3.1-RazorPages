﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TrabTerceiro.Data;

namespace TrabTerceiroRazor.Pages.Clientes
{
    public class DetailsModel : PageModel
    {
        private readonly TrabTerceiro.Data.LojaprodutosContext _context;

        public DetailsModel(TrabTerceiro.Data.LojaprodutosContext context)
        {
            _context = context;
        }

        public Cliente Cliente { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Cliente = await _context.Cliente.FirstOrDefaultAsync(m => m.CliId == id);

            if (Cliente == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
