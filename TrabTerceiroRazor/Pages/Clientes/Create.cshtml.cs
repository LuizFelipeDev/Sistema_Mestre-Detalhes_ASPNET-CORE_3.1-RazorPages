using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using TrabTerceiro.Data;
using TrabTerceiro.Data.Repositories;

namespace TrabTerceiroRazor.Pages.Clientes
{
    public class CreateModel : PageModel
    {
        private readonly TrabTerceiro.Data.LojaprodutosContext _context;
        private RepositoryCliente _repository;

        public CreateModel(TrabTerceiro.Data.LojaprodutosContext context)
        {
            _context = context;
            _repository = new RepositoryCliente(_context);
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Cliente Cliente { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
           
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _repository.Incluir(Cliente);

            return RedirectToPage("./Index");
        }
    }
}
