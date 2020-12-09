using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace TrabTerceiro.Data.Repositories
{
    public class RepositoryVendaProduto
    {
        private LojaprodutosContext odb;
        private bool RecebiContexto = false;

        public LojaprodutosContext Contexto
        {
            get { return odb; }
        }

        public RepositoryVendaProduto(LojaprodutosContext _db)
        {
            RecebiContexto = true;
            odb = _db;
        }

        public VendaProduto Incluir(VendaProduto oVendaProduto)
        {
            odb.VendaProduto.Add(oVendaProduto);
            odb.SaveChanges();
            return oVendaProduto;
        }

        public int Alterar(VendaProduto oVendaProduto)
        {
            VendaProduto VendaProdutoContexto = (from p in odb.VendaProduto where p.VePId == oVendaProduto.VePId select p).FirstOrDefault();
            odb.Entry(VendaProdutoContexto).State = Microsoft.EntityFrameworkCore.EntityState.Detached;

            odb.Entry(oVendaProduto).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

            return odb.SaveChanges();
        }

        public int Excluir(int ID)
        {
            VendaProduto oVendaProduto = (from p in odb.VendaProduto where p.VePId == ID select p).FirstOrDefault();
            odb.Remove(oVendaProduto);

            return odb.SaveChanges();
        }

        public VendaProduto Selecionar(int ID)
        {
            return (from p in odb.VendaProduto where p.VePId == ID select p).FirstOrDefault();
        }
   

        public List<VendaProduto> SelecionarTodos()
        {
            return (from p in odb.VendaProduto select p).ToList();
        }

        public List<VendaProduto> SelecionarTodosPorVenda(int ID)
        {
            return (from p in odb.VendaProduto where p.IdVenda == ID select p).ToList();
        }

        public VendaProduto SelecionarPorIdVenda(int id)
        {
            return (from p in odb.VendaProduto where p.IdVenda == id select p).FirstOrDefault();
        }

        public void Dispose()
        {
            odb.Dispose();
        }
    }
}
