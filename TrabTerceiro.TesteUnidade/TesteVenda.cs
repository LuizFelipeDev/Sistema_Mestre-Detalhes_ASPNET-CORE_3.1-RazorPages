using NUnit.Framework;
using TrabTerceiro.Data;
using TrabTerceiro.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using TrabTerceiro.Data.Services;

namespace TrabTerceiro.TesteUnidade
{
    public class TestVenda
    {
        ServiceVenda _service;
        private LojaprodutosContext context = new LojaprodutosContext();


        [SetUp]
        public void Setup()
        {
            _service = new ServiceVenda(context);
        }

        [Test]
        public void IncluiVenda()
        {
            Venda oVendaIncluir = new Venda();
            oVendaIncluir.IdCli = _service.RCliente.SelecionarTodos().First().CliId;
            oVendaIncluir.VenData = DateTime.Today;
            oVendaIncluir.VenFechada = true;
            _service.RVenda.Incluir(oVendaIncluir);

            VendaProduto oVendaProdutoIncluir = new VendaProduto();
            oVendaProdutoIncluir.IdVenda = oVendaIncluir.VenId;

            List<Produto> oProd = _service.RProduto.SelecionarTodos();

            oVendaProdutoIncluir.IdProduto = oProd.First().ProId;
            oVendaProdutoIncluir.VePQtd = 5;
            oVendaProdutoIncluir.VePPrecoVenda = oProd.First().ProPreco * oVendaProdutoIncluir.VePQtd;
            _service.RVendaProduto.Incluir(oVendaProdutoIncluir);


            Assert.Pass();
        }

        [Test]
        public void AlterarVenda()
        {
            Venda oVendaAlterar = new Venda();
            List<Venda> Vendas = _service.RVenda.SelecionarTodos();
            oVendaAlterar = Vendas.Last();
            oVendaAlterar.VenData = DateTime.Today;
            oVendaAlterar.VenFechada = false;
            _service.RVenda.Alterar(oVendaAlterar);
            Assert.Pass();
        }

        [Test]
        public void ExcluirVenda()
        {
            Venda oVendaExcluir = new Venda();
            List<Venda> Vendas = _service.RVenda.SelecionarTodos();
            oVendaExcluir = Vendas.Last();

            VendaProduto oVendaProdutoExcluir = new VendaProduto();          
            oVendaProdutoExcluir = _service.RVendaProduto.SelecionarPorIdVenda(oVendaExcluir.VenId);
            _service.RVendaProduto.Excluir(oVendaProdutoExcluir.VePId);

            _service.RVenda.Excluir(oVendaExcluir.VenId);
            Assert.Pass();
        }
    }
}