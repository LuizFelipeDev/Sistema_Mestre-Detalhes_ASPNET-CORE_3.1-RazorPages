using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using TrabTerceiro.Data;
using TrabTerceiro.Data.Repositories;

namespace TrabTerceiroRazor.Pages.Fornecedores
{
    public class CreateModel : PageModel
    {
        private readonly TrabTerceiro.Data.LojaprodutosContext _context;
        RepositoryFornecedor _repositoryFornecedor;

        public CreateModel(TrabTerceiro.Data.LojaprodutosContext context)
        {
            _context = context;
            _repositoryFornecedor = new RepositoryFornecedor(_context);
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Fornecedor Fornecedor { get; set; }

       
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _repositoryFornecedor.Incluir(Fornecedor);

            return RedirectToPage("./Index");
        }
    }
}
