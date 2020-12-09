using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TrabTerceiro.Data;
using TrabTerceiro.Data.Repositories;

namespace TrabTerceiroRazor.Pages.Produtos
{
    public class DeleteModel : PageModel
    {
        private readonly TrabTerceiro.Data.LojaprodutosContext _context;
        RepositoryProduto _repositoryProduto;

        public DeleteModel(TrabTerceiro.Data.LojaprodutosContext context)
        {
            _context = context;
            _repositoryProduto = new RepositoryProduto(_context);
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Produto = await _context.Produto.FindAsync(id);

            if (Produto != null)
            {
                _repositoryProduto.Excluir(Produto.ProId);
            }

            return RedirectToPage("./Index");
        }
    }
}
