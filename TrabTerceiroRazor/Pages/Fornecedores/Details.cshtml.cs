using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TrabTerceiro.Data;

namespace TrabTerceiroRazor.Pages.Fornecedores
{
    public class DetailsModel : PageModel
    {
        private readonly TrabTerceiro.Data.LojaprodutosContext _context;

        public DetailsModel(TrabTerceiro.Data.LojaprodutosContext context)
        {
            _context = context;
        }

        public Fornecedor Fornecedor { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Fornecedor = await _context.Fornecedor.FirstOrDefaultAsync(m => m.ForId == id);

            if (Fornecedor == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
