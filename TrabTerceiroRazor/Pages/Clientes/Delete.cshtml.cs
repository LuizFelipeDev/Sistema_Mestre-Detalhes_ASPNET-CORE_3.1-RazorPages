using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TrabTerceiro.Data;
using TrabTerceiro.Data.Repositories;

namespace TrabTerceiroRazor.Pages.Clientes
{
    public class DeleteModel : PageModel
    {
        private readonly TrabTerceiro.Data.LojaprodutosContext _context;
        private RepositoryCliente _repository;

        public DeleteModel(TrabTerceiro.Data.LojaprodutosContext context)
        {
            _context = context;
            _repository = new RepositoryCliente(_context);
        }

        [BindProperty]
        public Cliente Cliente { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Cliente = _repository.Selecionar((int)id);

            if (Cliente == null)
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

            Cliente = _repository.Selecionar((int)id);

            if (Cliente != null)
            {
                _repository.Excluir(Cliente.CliId);
                
            }

            return RedirectToPage("./Index");
        }
    }
}
