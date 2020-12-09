using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TrabTerceiro.Data;

namespace TrabTerceiroRazor.Categorias
{
    public class DetailsModel : PageModel
    {
        private readonly TrabTerceiro.Data.LojaprodutosContext _context;

        public DetailsModel(TrabTerceiro.Data.LojaprodutosContext context)
        {
            _context = context;
        }

        public Categoria Categoria { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Categoria = await _context.Categoria.FirstOrDefaultAsync(m => m.CatId == id);

            if (Categoria == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
