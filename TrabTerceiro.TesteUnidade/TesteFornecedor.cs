using NUnit.Framework;
using TrabTerceiro.Data;
using TrabTerceiro.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace TrabTerceiro.TesteUnidade
{
    public class TestFornecedor
    {
        RepositoryFornecedor _repository;
        private LojaprodutosContext context;


        [SetUp]
        public void Setup()
        {
            context = new LojaprodutosContext();
            _repository = new RepositoryFornecedor(context);
        }

        [Test]
        public void IncluiFornecedor()
        {
            Fornecedor oFornecedorIncluir = new Fornecedor();
            oFornecedorIncluir.ForNome = "Teste Novo";
            oFornecedorIncluir = _repository.Incluir(oFornecedorIncluir);

            Assert.Pass(oFornecedorIncluir.ForNome.ToString());
        }

        [Test]
        public void AlterarFornecedor()
        {
            Fornecedor oFornecedorAlterar = new Fornecedor();
            List<Fornecedor> Fornecedores = _repository.SelecionarTodos();
            oFornecedorAlterar = Fornecedores.Last();
            oFornecedorAlterar.ForNome = "Teste Alterado";
            oFornecedorAlterar = _repository.Alterar(oFornecedorAlterar);

            Assert.Pass(oFornecedorAlterar.ForNome.ToString());
        }

        [Test]
        public void ExcluirFornecedor()
        {
            Fornecedor oFornecedorExcluir = new Fornecedor();
            List<Fornecedor> Fornecedores = _repository.SelecionarTodos();
            oFornecedorExcluir = Fornecedores.Last();
            _repository.Excluir(oFornecedorExcluir.ForId);

            Assert.Pass(oFornecedorExcluir.ForNome.ToString());
        }
    }
}