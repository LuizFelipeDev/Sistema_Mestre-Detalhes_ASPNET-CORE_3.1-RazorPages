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
    public class IndexModel : PageModel
    {
        private readonly TrabTerceiro.Data.LojaprodutosContext _context;
        RepositoryCategoria _repositoryCategoria;

        public IndexModel(TrabTerceiro.Data.LojaprodutosContext context)
        {
            _context = context;
            _repositoryCategoria = new RepositoryCategoria(_context);
        }

        public IList<Categoria> Categoria { get;set; }

        public async Task OnGetAsync()
        {
            Categoria = _repositoryCategoria.SelecionarTodos();
        }
    }
}
