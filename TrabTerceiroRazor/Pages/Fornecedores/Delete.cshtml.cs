using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TrabTerceiro.Data;
using TrabTerceiro.Data.Repositories;

namespace TrabTerceiroRazor.Pages.Fornecedores
{
    public class DeleteModel : PageModel
    {
        private readonly TrabTerceiro.Data.LojaprodutosContext _context;
        RepositoryFornecedor _repositoryFornecedor;

        public DeleteModel(TrabTerceiro.Data.LojaprodutosContext context)
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Fornecedor = _repositoryFornecedor.Selecionar((int)id);

            if (Fornecedor != null)
            {
                _repositoryFornecedor.Excluir(Fornecedor.ForId);
            }

            return RedirectToPage("./Index");
        }
    }
}
