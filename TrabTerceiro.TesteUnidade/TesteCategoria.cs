using NUnit.Framework;
using TrabTerceiro.Data;
using TrabTerceiro.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace TrabTerceiro.TesteUnidade
{
    public class TestCategoria
    {
        RepositoryCategoria _repository;
        private LojaprodutosContext context;


        [SetUp]
        public void Setup()
        {
            context = new LojaprodutosContext();
            _repository = new RepositoryCategoria(context);
        }

        [Test]
        public void IncluiCategoria()
        {
            Categoria oCategoriaIncluir = new Categoria();
            oCategoriaIncluir.CatNome = "Teste Novo";          
            _repository.Incluir(oCategoriaIncluir);
            Assert.Pass();
        }

        [Test]
        public void AlterarCategoria()
        {
            Categoria oCategoriaAlterar = new Categoria();
            List<Categoria> Categorias = _repository.SelecionarTodos();
            oCategoriaAlterar = Categorias.Last();
            oCategoriaAlterar.CatNome = "Teste Alterado";            
            _repository.Alterar(oCategoriaAlterar);
            Assert.Pass();
        }

        [Test]
        public void ExcluirCategoria()
        {
            Categoria oCategoriaExcluir = new Categoria();
            List<Categoria> Categorias = _repository.SelecionarTodos();
            oCategoriaExcluir = Categorias.Last();
            _repository.Excluir(oCategoriaExcluir.CatId);
            Assert.Pass();
        }
    }
}