using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TrabTerceiro.Data;
using TrabTerceiro.Data.Repositories;

namespace TrabTerceiroRazor.Pages.Produtos
{
    public class EditModel : PageModel
    {
        private readonly TrabTerceiro.Data.LojaprodutosContext _context;
        RepositoryProduto _repositoryProduto;
        RepositoryFornecedor _repositoryFornecedor;
        RepositoryCategoria _repositoryCategoria;

        public EditModel(TrabTerceiro.Data.LojaprodutosContext context)
        {
            _context = context;
            _repositoryProduto = new RepositoryProduto(_context);
            _repositoryFornecedor = new RepositoryFornecedor(_context);
            _repositoryCategoria = new RepositoryCategoria(_context);
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
           ViewData["ProCategoria"] = new SelectList(_repositoryCategoria.SelecionarTodos(), "CatId", "CatNome");
           ViewData["ProFornecedor"] = new SelectList(_repositoryFornecedor.SelecionarTodos(), "ForId", "ForNome");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _repositoryProduto.Alterar(Produto);

            

            return RedirectToPage("./Index");
        }

        private bool ProdutoExists(int id)
        {
            return _context.Produto.Any(e => e.ProId == id);
        }
    }
}
