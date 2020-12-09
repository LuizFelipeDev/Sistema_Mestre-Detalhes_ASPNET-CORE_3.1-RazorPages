using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TrabTerceiro.Data;
using TrabTerceiro.Data.Repositories;

namespace TrabTerceiroRazor.Categorias
{
    public class DeleteModel : PageModel
    {
        private readonly TrabTerceiro.Data.LojaprodutosContext _context;
        RepositoryCategoria _repositoryCategoria;

        public DeleteModel(TrabTerceiro.Data.LojaprodutosContext context)
        {
            _context = context;
            _repositoryCategoria = new RepositoryCategoria(_context);
        }

        [BindProperty]
        public Categoria Categoria { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Categoria = _repositoryCategoria.Selecionar((int)id);

            if (Categoria == null)
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

            Categoria = _repositoryCategoria.Selecionar((int)id);

            if (Categoria != null)
            {
                _repositoryCategoria.Excluir(Categoria.CatId);
            }

            return RedirectToPage("./Index");
        }
    }
}
