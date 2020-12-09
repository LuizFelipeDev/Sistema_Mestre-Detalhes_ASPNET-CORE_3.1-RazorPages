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

namespace TrabTerceiroRazor.Pages.Clientes
{
    public class EditModel : PageModel
    {
        private readonly TrabTerceiro.Data.LojaprodutosContext _context;
        private RepositoryCliente _repository;

        public EditModel(TrabTerceiro.Data.LojaprodutosContext context)
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

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _repository.Alterar(Cliente);

            

            return RedirectToPage("./Index");
        }

        private bool ClienteExists(int id)
        {
            return _context.Cliente.Any(e => e.CliId == id);
        }
    }
}
