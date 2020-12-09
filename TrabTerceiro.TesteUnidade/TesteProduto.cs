using NUnit.Framework;
using TrabTerceiro.Data;
using TrabTerceiro.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace TrabTerceiro.TesteUnidade
{
    public class TestProduto
    {
        RepositoryProduto _repositoryProduto;
        RepositoryCategoria _repositoryCategoria;
        RepositoryFornecedor _repositoryFornecedor;
        private LojaprodutosContext context = new LojaprodutosContext();


        [SetUp]
        public void Setup()
        {
            _repositoryProduto = new RepositoryProduto(context);
            _repositoryCategoria = new RepositoryCategoria(context);
            _repositoryFornecedor = new RepositoryFornecedor(context);
        }

        [Test]
        public void IncluiProduto()
        {
            Produto oProdutoIncluir = new Produto();
            oProdutoIncluir.ProNome = "Teste Novo";
            oProdutoIncluir.ProPreco = 25;

            Categoria oCategoria = new Categoria();
            oCategoria = _repositoryCategoria.SelecionarTodos().First();
            Fornecedor oFornecedor = new Fornecedor();
            oFornecedor = _repositoryFornecedor.SelecionarTodos().First();

            oProdutoIncluir.ProCategoria = oCategoria.CatId;
            oProdutoIncluir.ProFornecedor = oFornecedor.ForId;

            _repositoryProduto.Incluir(oProdutoIncluir);

            Assert.Pass();
        }

        [Test]
        public void AlterarProduto()
        {
            Produto oProdutoAlterar = new Produto();
            List<Produto> Produtos = _repositoryProduto.SelecionarTodos();
            oProdutoAlterar = Produtos.First();
            oProdutoAlterar.ProNome = "Teste Alterado";

            oProdutoAlterar = _repositoryProduto.Alterar(oProdutoAlterar);

            Assert.Pass(oProdutoAlterar.ProNome.ToString());
        }

        [Test]
        public void ExcluirProduto()
        {
            Produto oProdutoExcluir = new Produto();
            List<Produto> Produtos = _repositoryProduto.SelecionarTodos();
            oProdutoExcluir = Produtos.Last();
            _repositoryProduto.Excluir(oProdutoExcluir.ProId);
            Assert.Pass();
        }
    }
}