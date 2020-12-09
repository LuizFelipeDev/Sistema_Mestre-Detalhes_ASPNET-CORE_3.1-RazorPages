using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace TrabTerceiro.Data.Repositories
{
    public class RepositoryProduto
    {
        private LojaprodutosContext odb;
        private bool RecebiContexto = false;

        public LojaprodutosContext Contexto
        {
            get { return odb; }
        }

        public RepositoryProduto(LojaprodutosContext _db)
        {
            RecebiContexto = true;
            odb = _db;
        }

        public Produto Incluir(Produto oProduto)
        {
            odb.Produto.Add(oProduto);
            odb.SaveChanges();
            return oProduto;
        }

        public Produto Alterar(Produto oProduto)
        {
            Produto ProdutoContexto = (from p in odb.Produto where p.ProId == oProduto.ProId select p).FirstOrDefault();
            odb.Entry(ProdutoContexto).State = Microsoft.EntityFrameworkCore.EntityState.Detached;

            odb.Entry(oProduto).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            odb.SaveChanges();
            return oProduto;
        }

        public int Excluir(int ID)
        {
            Produto oProduto = (from p in odb.Produto where p.ProId == ID select p).FirstOrDefault();
            odb.Remove(oProduto);

            return odb.SaveChanges();
        }

        public Produto Selecionar(int ID)
        {
            return (from p in odb.Produto where p.ProId == ID select p).FirstOrDefault();
        }

        public List<Produto> SelecionarTodos()
        {
            return (from p in odb.Produto select p).ToList();
        }

        public void Dispose()
        {
            odb.Dispose();
        }
    }
}
