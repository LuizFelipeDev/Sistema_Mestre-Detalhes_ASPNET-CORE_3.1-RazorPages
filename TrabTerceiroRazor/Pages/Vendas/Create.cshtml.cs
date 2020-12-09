using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using TrabTerceiro.Data;
using TrabTerceiro.Data.Services;

namespace TrabTerceiroRazor.Pages.Vendas
{
    public class CreateModel : PageModel
    {
        private readonly TrabTerceiro.Data.LojaprodutosContext _context;
        ServiceVenda _service;

        public CreateModel(TrabTerceiro.Data.LojaprodutosContext context)
        {
            _context = context;
            _service = new ServiceVenda(_context);
        }

        public IActionResult OnGet()
        {
            ViewData["IdCli"] = new SelectList(_service.RCliente.SelecionarTodos(), "CliId", "CliNome");
            return Page();
        }

        [BindProperty]
        public Venda Venda { get; set; }
     
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _service.RVenda.Incluir(Venda);

            return RedirectToPage("./Index");
        }
    }
}
