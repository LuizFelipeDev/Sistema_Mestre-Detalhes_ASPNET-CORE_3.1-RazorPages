using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace TrabTerceiro.Data.Repositories
{
    public class RepositoryCategoria
    {
        private LojaprodutosContext odb;
        private bool RecebiContexto = false;

        public LojaprodutosContext Contexto
        {
            get { return odb; }
        }

        public RepositoryCategoria(LojaprodutosContext _db)
        {
            RecebiContexto = true;
            odb = _db;
        }

        public Categoria Incluir(Categoria oCategoria)
        {
            odb.Categoria.Add(oCategoria);
            odb.SaveChanges();
            return oCategoria;
        }

        public int Alterar(Categoria oCategoria)
        {
            Categoria CategoriaContexto = (from p in odb.Categoria where p.CatId == oCategoria.CatId select p).FirstOrDefault();
            odb.Entry(CategoriaContexto).State = Microsoft.EntityFrameworkCore.EntityState.Detached;

            odb.Entry(oCategoria).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

            return odb.SaveChanges();
        }

        public int Excluir(int ID)
        {
            Categoria oCategoria = (from p in odb.Categoria where p.CatId == ID select p).FirstOrDefault();
            odb.Remove(oCategoria);

            return odb.SaveChanges();
        }

        public Categoria Selecionar(int ID)
        {
            return (from p in odb.Categoria where p.CatId == ID select p).FirstOrDefault();
        }

        public List<Categoria> SelecionarTodos()
        {
            return (from p in odb.Categoria select p).ToList();
        }

        public void Dispose()
        {
            odb.Dispose();
        }
    }
}
