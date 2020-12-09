using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TrabTerceiro.Data;

namespace TrabTerceiroRazor.Pages.Vendas
{
    public class IndexModel : PageModel
    {
        private readonly TrabTerceiro.Data.LojaprodutosContext _context;
        private TrabTerceiro.Data.Services.ServiceVenda _servico;

        public IndexModel(TrabTerceiro.Data.LojaprodutosContext context)
        {
            _context = context;
            _servico = new TrabTerceiro.Data.Services.ServiceVenda(_context);
        }

        [BindProperty]
        public Venda Venda { get; set; }

        public IList<Venda> ListaVenda { get;set; }

        //public async Task OnGetAsync()
        //{
        //    Venda = await _context.Venda
        //        .Include(v => v.IdCliNavigation).ToListAsync();
        //}

        public async Task OnGetAsync()
        {
            ListaVenda = await _servico.RVenda.SelecionarTodosAsync();
        }
    }
}
