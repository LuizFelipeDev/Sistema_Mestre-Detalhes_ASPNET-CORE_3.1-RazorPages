using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace TrabTerceiro.Data.Repositories
{
    public class RepositoryVenda
    {
        private LojaprodutosContext odb;
        private bool RecebiContexto = false;

        public LojaprodutosContext Contexto
        {
            get { return odb; }
        }

        public RepositoryVenda(LojaprodutosContext _db)
        {
            RecebiContexto = true;
            odb = _db;
        }

        public Venda Incluir(Venda oVenda)
        {
            odb.Venda.Add(oVenda);
            odb.SaveChanges();
            return oVenda;
        }

        public int Alterar(Venda oVenda)
        {
            Venda VendaContexto = (from p in odb.Venda where p.VenId == oVenda.VenId select p).FirstOrDefault();
            odb.Entry(VendaContexto).State = Microsoft.EntityFrameworkCore.EntityState.Detached;

            odb.Entry(oVenda).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

            return odb.SaveChanges();
        }

        public int Excluir(int ID)
        {
            Venda oVenda = (from p in odb.Venda where p.VenId == ID select p).FirstOrDefault();
            odb.Remove(oVenda);

            return odb.SaveChanges();
        }

        public Venda Selecionar(int ID)
        {
            return (from p in odb.Venda where p.VenId == ID select p).Include(v=> v.IdCliNavigation).FirstOrDefault();
        }

        public List<Venda> SelecionarTodos()
        {
            return (from p in odb.Venda select p).ToList();
        }

        public async Task<List<Venda>> SelecionarTodosAsync()
        {
            return await odb.Venda.Include(t => t.IdCliNavigation).ToListAsync();
        }

        public async Task<Venda> SelecionarAsync(int ID)
        {
            return await odb.Venda.Include(t => t.IdCliNavigation).FirstOrDefaultAsync(m => m.VenId == ID);
        }

        public void Dispose()
        {
            odb.Dispose();
        }
    }
}
