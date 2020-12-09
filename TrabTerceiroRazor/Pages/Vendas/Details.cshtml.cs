using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TrabTerceiro.Data;

namespace TrabTerceiroRazor.Pages.Vendas
{
    public class DetailsModel : PageModel
    {
        private readonly TrabTerceiro.Data.LojaprodutosContext _context;

        public DetailsModel(TrabTerceiro.Data.LojaprodutosContext context)
        {
            _context = context;
        }

        public Venda Venda { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Venda = await _context.Venda
                .Include(v => v.IdCliNavigation).FirstOrDefaultAsync(m => m.VenId == id);

            if (Venda == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
