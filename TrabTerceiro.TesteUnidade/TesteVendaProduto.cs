using NUnit.Framework;
using TrabTerceiro.Data;
using TrabTerceiro.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace TrabTerceiro.TesteUnidade
{
    public class TestVendaVendaProduto
    {
        RepositoryVendaProduto _repository;
        private LojaprodutosContext context = new LojaprodutosContext();


        [SetUp]
        public void Setup()
        {
            _repository = new RepositoryVendaProduto(context);
        }
       

        [Test]
        public void AlterarVendaProduto()
        {
            VendaProduto oVendaProdutoAlterar = new VendaProduto();
            List<VendaProduto> VendaProdutos = _repository.SelecionarTodos();
            oVendaProdutoAlterar = VendaProdutos.First();
            oVendaProdutoAlterar.VePQtd = 2;
            oVendaProdutoAlterar.VePPrecoVenda = 1000;
            _repository.Alterar(oVendaProdutoAlterar);
            Assert.Pass();
        }     
    }
}