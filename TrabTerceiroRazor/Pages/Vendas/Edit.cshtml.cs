using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TrabTerceiro.Data;
using TrabTerceiro.Data.Services;

namespace TrabTerceiroRazor.Pages.Vendas
{
    public class EditModel : PageModel
    {
        private readonly TrabTerceiro.Data.LojaprodutosContext _context;
        ServiceVenda _service;

        public EditModel(TrabTerceiro.Data.LojaprodutosContext context)
        {
            _context = context;
            _service = new ServiceVenda(_context);
        }

        [BindProperty]
        public Venda Venda { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //Venda = await _context.Venda.Include(v => v.IdCliNavigation).FirstOrDefaultAsync(m => m.VenId == id);
            Venda = Venda = _service.RVenda.Selecionar((int)id);
            if (Venda == null)
            {
                return NotFound();
            }
            ViewData["IdCli"] = new SelectList(_service.RCliente.SelecionarTodos(), "CliId", "CliNome");
            return Page();
        }
   
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _service.RVenda.Alterar(Venda);
          

            return RedirectToPage("./Index");
        }

        private bool VendaExists(int id)
        {
            return _context.Venda.Any(e => e.VenId == id);
        }
    }
}
