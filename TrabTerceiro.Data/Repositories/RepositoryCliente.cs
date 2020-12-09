using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace TrabTerceiro.Data.Repositories
{
    public class RepositoryCliente : IDisposable
    {
        private LojaprodutosContext odb;
        private bool RecebiContexto = false;

        public LojaprodutosContext Contexto
        {
            get { return odb; }
        }

        public RepositoryCliente(LojaprodutosContext _db)
        {
            RecebiContexto = true;
            odb = _db;
        }

        public RepositoryCliente()
        {
            
            odb = new LojaprodutosContext();
        }



        public Cliente Incluir(Cliente oCliente)
        {
            odb.Cliente.Add(oCliente);
            odb.SaveChanges();
            return oCliente;
        }

        public int Alterar(Cliente oCliente)
        {
            Cliente ClienteContexto = (from p in odb.Cliente where p.CliId == oCliente.CliId select p).FirstOrDefault();
            odb.Entry(ClienteContexto).State = Microsoft.EntityFrameworkCore.EntityState.Detached;

            odb.Entry(oCliente).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

            return odb.SaveChanges();
        }

        public int Excluir(int ID)
        {
            Cliente oCliente = (from p in odb.Cliente where p.CliId == ID select p).FirstOrDefault();
            odb.Remove(oCliente);

            return odb.SaveChanges();
        }

        public Cliente Selecionar(int ID)
        {
            return (from p in odb.Cliente where p.CliId == ID select p).FirstOrDefault();
        }

        public List<Cliente> SelecionarTodos()
        {
            return (from p in odb.Cliente select p).ToList();
        }

        public void Dispose()
        {
            odb.Dispose();
        }
    }
}
