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
    public class IndexModel : PageModel
    {
        private readonly TrabTerceiro.Data.LojaprodutosContext _context;

        public IndexModel(TrabTerceiro.Data.LojaprodutosContext context)
        {
            _context = context;
        }

        public IList<Produto> Produto { get;set; }

        public async Task OnGetAsync()
        {
            Produto = await _context.Produto
                .Include(p => p.ProCategoriaNavigation)
                .Include(p => p.ProFornecedorNavigation).ToListAsync();
        }
    }
}
