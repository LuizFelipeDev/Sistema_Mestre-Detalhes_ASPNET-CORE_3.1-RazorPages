using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using TrabTerceiro.Data;
using TrabTerceiro.Data.Repositories;

namespace TrabTerceiroRazor.Categorias
{
    public class CreateModel : PageModel
    {
        private RepositoryCategoria _repository;
        private readonly TrabTerceiro.Data.LojaprodutosContext _context;

        public CreateModel(TrabTerceiro.Data.LojaprodutosContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Categoria Categoria { get; set; }
      
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            _repository = new RepositoryCategoria(_context);
            _repository.Incluir(Categoria);

            return RedirectToPage("./Index");
        }
    }
}
