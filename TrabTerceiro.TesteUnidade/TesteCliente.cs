using NUnit.Framework;
using TrabTerceiro.Data;
using TrabTerceiro.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace TrabTerceiro.TesteUnidade
{
    public class TestCliente
    {
        RepositoryCliente _repository;
        private LojaprodutosContext context = new LojaprodutosContext();

        [SetUp]
        public void Setup()
        {
            _repository = new RepositoryCliente();
        }

        [Test]
        public void IncluiCliente()
        {
            Cliente oClienteIncluir = new Cliente();
            oClienteIncluir.CliNome = "Teste Novo";
            oClienteIncluir.CliEmail = "teste@gmail.com";
            oClienteIncluir.CliCpf = "11111100010";
            _repository.Incluir(oClienteIncluir);
            Assert.Pass();
        }

        [Test]
        public void AlterarCliente()
        {
            Cliente oClienteAlterar = new Cliente();
            List<Cliente> Clientes = _repository.SelecionarTodos();
            oClienteAlterar = Clientes.Last();
            oClienteAlterar.CliNome = "Teste Alterado";
            oClienteAlterar.CliEmail = "teste2@gmail.com";
            oClienteAlterar.CliCpf = "55555555551";

            _repository.Alterar(oClienteAlterar);


            Assert.Pass(oClienteAlterar.CliNome.ToString());
        }

        [Test]
        public void ExcluirCliente()
        {
            Cliente oClienteExcluir = new Cliente();
            List<Cliente> Clientes = _repository.SelecionarTodos();
            oClienteExcluir = Clientes.Last();
            _repository.Excluir(oClienteExcluir.CliId);
            Assert.Pass();
        }
    }
}