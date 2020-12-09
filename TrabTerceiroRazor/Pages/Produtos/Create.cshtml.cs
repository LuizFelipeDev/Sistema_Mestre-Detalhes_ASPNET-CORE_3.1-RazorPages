using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using TrabTerceiro.Data;
using TrabTerceiro.Data.Repositories;

namespace TrabTerceiroRazor.Pages.Produtos
{
    public class CreateModel : PageModel
    {
        private readonly TrabTerceiro.Data.LojaprodutosContext _context;
        RepositoryProduto _repositoryProduto;
        RepositoryFornecedor _repositoryFornecedor;
        RepositoryCategoria _repositoryCategoria;

        public CreateModel(TrabTerceiro.Data.LojaprodutosContext context)
        {
            _context = context;
            _repositoryProduto = new RepositoryProduto(_context);
            _repositoryFornecedor = new RepositoryFornecedor(_context);
            _repositoryCategoria = new RepositoryCategoria(_context);
        }

        public IActionResult OnGet()
        {
        ViewData["ProCategoria"] = new SelectList(_repositoryCategoria.SelecionarTodos(), "CatId", "CatNome");
        ViewData["ProFornecedor"] = new SelectList(_repositoryFornecedor.SelecionarTodos(), "ForId", "ForNome");
            return Page();
        }

        [BindProperty]
        public Produto Produto { get; set; }
     
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _repositoryProduto.Incluir(Produto);

            return RedirectToPage("./Index");
        }
    }
}
