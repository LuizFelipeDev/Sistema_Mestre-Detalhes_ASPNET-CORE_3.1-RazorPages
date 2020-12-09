using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TrabTerceiro.Data;

namespace TrabTerceiroRazor.Pages.Produtos
{
    public class DetailsModel : PageModel
    {
        private readonly TrabTerceiro.Data.LojaprodutosContext _context;

        public DetailsModel(TrabTerceiro.Data.LojaprodutosContext context)
        {
            _context = context;
        }

        public Produto Produto { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Produto = await _context.Produto
                .Include(p => p.ProCategoriaNavigation)
                .Include(p => p.ProFornecedorNavigation).FirstOrDefaultAsync(m => m.ProId == id);

            if (Produto == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
