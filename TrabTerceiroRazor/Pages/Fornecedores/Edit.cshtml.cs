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

namespace TrabTerceiroRazor.Pages.Fornecedores
{
    public class EditModel : PageModel
    {
        private readonly TrabTerceiro.Data.LojaprodutosContext _context;
        RepositoryFornecedor _repositoryFornecedor;

        public EditModel(TrabTerceiro.Data.LojaprodutosContext context)
        {
            _context = context;
            _repositoryFornecedor = new RepositoryFornecedor(_context);
        }

        [BindProperty]
        public Fornecedor Fornecedor { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Fornecedor = _repositoryFornecedor.Selecionar((int)id);

            if (Fornecedor == null)
            {
                return NotFound();
            }
            return Page();
        }
    
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _repositoryFornecedor.Alterar(Fornecedor);

           

            return RedirectToPage("./Index");
        }

        private bool FornecedorExists(int id)
        {
            return _context.Fornecedor.Any(e => e.ForId == id);
        }
    }
}
