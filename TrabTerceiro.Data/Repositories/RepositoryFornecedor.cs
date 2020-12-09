using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace TrabTerceiro.Data.Repositories
{
    public class RepositoryFornecedor
    {
        private LojaprodutosContext odb;
        private bool RecebiContexto = false;

        public LojaprodutosContext Contexto
        {
            get { return odb; }
        }

        public RepositoryFornecedor(LojaprodutosContext _db)
        {
            RecebiContexto = true;
            odb = _db;
        }

        public Fornecedor Incluir(Fornecedor oFornecedor)
        {
            odb.Fornecedor.Add(oFornecedor);
            odb.SaveChanges();
            return oFornecedor;
        }

        public Fornecedor Alterar(Fornecedor oFornecedor)
        {
            Fornecedor FornecedorContexto = (from p in odb.Fornecedor where p.ForId == oFornecedor.ForId select p).FirstOrDefault();
            odb.Entry(FornecedorContexto).State = Microsoft.EntityFrameworkCore.EntityState.Detached;

            odb.Entry(oFornecedor).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            odb.SaveChanges();
            return oFornecedor;
        }

        public int Excluir(int ID)
        {
            Fornecedor oFornecedor = (from p in odb.Fornecedor where p.ForId == ID select p).FirstOrDefault();
            odb.Remove(oFornecedor);

            return odb.SaveChanges();
        }

        public Fornecedor Selecionar(int ID)
        {
            return (from p in odb.Fornecedor where p.ForId == ID select p).FirstOrDefault();
        }

        public List<Fornecedor> SelecionarTodos()
        {
            return (from p in odb.Fornecedor select p).ToList();
        }

        public void Dispose()
        {
            odb.Dispose();
        }

    }
}

