using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using TrabTerceiro.Data;
using TrabTerceiro.Data.Services;
using TrabTerceiroRazor.Models;

namespace TrabTerceiroRazor.Pages.Vendas
{
    public class IncluirAlterarModel : PageModel
    {
        private readonly TrabTerceiro.Data.LojaprodutosContext _context;
        private ServiceVenda _service;

        public IncluirAlterarModel(TrabTerceiro.Data.LojaprodutosContext context)
        {
            _context = context;
            _service = new ServiceVenda(_context);
        }

        [BindProperty]
        public Venda Venda { get; set; }
        public VendaProduto VP { get; set; }
        public VendaProduto VP2 { get; set; }
        public Produto Produto { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                Venda = new Venda();

            }
            else
            {
                Venda = await _service.RVenda.SelecionarAsync((int)id);
                ListaProdutos((int)id);
                if (Venda == null)
                {
                    return NotFound();
                }
            }
            ViewData["IdCli"] = new SelectList(_service.RCliente.SelecionarTodos(), "CliId", "CliNome");
            ViewData["ProId"] = new SelectList(_service.RProduto.SelecionarTodos(), "ProId", "ProNome");
            decimal total = 0;
            if (id != null)
            {
                List<VendaProduto> vp = _service.RVendaProduto.SelecionarTodosPorVenda((int)id);

                foreach (var item in vp)
                {
                    total += item.VePPrecoVenda;
                }
            }

            ViewData["total"] = total.ToString("N2");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            string strBotao = Request.Form["BtnSalvar"].ToString();
            var VendaId = Venda.VenId;

            if (strBotao == "Salvar")
            {
                if (VendaId > 0)
                {
                    _service.RVenda.Alterar(Venda);
                    return RedirectToPage("Index");
                }
                else
                {
                    Venda V = new Venda();
                    V.IdCli = Venda.IdCli;
                    V.VenData = Venda.VenData;
                    V.VenFechada = Venda.VenFechada;
                    _service.RVenda.Incluir(V);
                    return RedirectToPage("Index");
                }
            }
            else if (strBotao == "Adicionar")
            {
                if (Venda.VenId > 0)
                {
                    Produto p = new Produto();
                    VP = new VendaProduto();
                    VP.IdProduto = Convert.ToInt32(Request.Form["Produto.ProId"].ToString());
                    VP.VePQtd = Convert.ToInt32(Request.Form["VP2.VePQtd"].ToString());
                    VP.IdVenda = VendaId;
                    p = _service.RProduto.Selecionar(VP.IdProduto);
                    VP.VePPrecoVenda = VP.VePQtd * p.ProPreco;
                    _service.RVendaProduto.Incluir(VP);
                }
                else
                {
                    Venda V = new Venda();
                    V.IdCli = Venda.IdCli;
                    V.VenData = Venda.VenData;
                    V.VenFechada = Venda.VenFechada;

                    _service.RVenda.Incluir(V);

                    Produto p = new Produto();
                    VP = new VendaProduto();
                    VP.IdProduto = Convert.ToInt32(Request.Form["Produto.ProId"].ToString()); ;
                    VP.VePQtd = Convert.ToInt32(Request.Form["VP2.VePQtd"].ToString());
                    VP.IdVenda = V.VenId;
                    p = _service.RProduto.Selecionar(VP.IdProduto);
                    VP.VePPrecoVenda = VP.VePQtd * p.ProPreco;
                    _service.RVendaProduto.Incluir(VP);

                    return RedirectToAction("OnGetAsync", new { id = V.VenId });
                }

                return RedirectToAction("OnGetAsync", new { id = VendaId });
            }           
            else if (Request.Form["RemoverProduto"].ToString() != null)
            {
                var idExcluir = Convert.ToInt32(Request.Form["RemoverProduto"].ToString());
                int VepId = idExcluir;

                VendaProduto venp = new VendaProduto();
                venp = _service.RVendaProduto.Selecionar(VepId);
                _service.RVendaProduto.Excluir(VepId);

                return RedirectToAction("OnGetAsync", new { id = VendaId });
            }
            else
            {
                return RedirectToAction("OnGetAsync", new { id = 161 });
            }

            //_context.Attach(Venda).State = EntityState.Modified;                     
        }

        private bool VendaExists(int id)
        {
            return _context.Venda.Any(e => e.VenId == id);
        }


        public void criarVendaProduto(int idVendaCriada, int idProduto, int qtd)
        {
            VP = new VendaProduto();
            VP.IdVenda = idVendaCriada;
            VP.IdProduto = idProduto;
            VP.VePQtd = qtd;

            Produto = new Produto();

            Produto = _service.RProduto.Selecionar(idProduto);
            VP.VePPrecoVenda = Produto.ProPreco * qtd;

            _service.RVendaProduto.Incluir(VP);         
        }

        public void ListaProdutos(int idVenda)
        {
            List<VendaProduto> oListVendaProduto = _service.RVendaProduto.SelecionarTodosPorVenda(idVenda);
            List<VendaProdutoView> oListVendaProdutoView = new List<VendaProdutoView>();

            foreach (var i in oListVendaProduto)
            {
                int idPro = i.IdProduto;

                Produto p = new Produto();
                p = _service.RProduto.Selecionar(idPro);

                Categoria c = new Categoria();
                c = _service.RCategoria.Selecionar(p.ProCategoria);

                Fornecedor f = new Fornecedor();
                f = _service.RFornecedor.Selecionar(p.ProFornecedor);

                VendaProdutoView venp = new VendaProdutoView();
                venp.IdProduto = i.IdProduto;
                venp.ProdutoName = p.ProNome;
                venp.VePPrecoVenda = Convert.ToDecimal(p.ProPreco.ToString("N2"));
                venp.CategoriaNome = c.CatNome;
                venp.FornecedorNome = f.ForNome;
                venp.VePQtd = i.VePQtd;
                venp.VePId = i.VePId;

                oListVendaProdutoView.Add(venp);
            }
            ViewData["ListaProdutos"] = oListVendaProdutoView;
        }
    }
}
