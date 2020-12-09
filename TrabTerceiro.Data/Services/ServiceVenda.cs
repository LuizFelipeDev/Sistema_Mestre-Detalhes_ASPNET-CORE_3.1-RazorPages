using System;
using System.Collections.Generic;
using System.Text;
using TrabTerceiro.Data.Repositories;

namespace TrabTerceiro.Data.Services
{
    public class ServiceVenda : IDisposable
    {
        private LojaprodutosContext odb;

        RepositoryCliente _RepositoryCliente;
        RepositoryProduto _RepositoryProduto;
        RepositoryVenda _RepositoryVenda;
        RepositoryVendaProduto _RepositoryVendaProduto;
        RepositoryCategoria _RepositoryCategoria;
        RepositoryFornecedor _RepositoryFornecedor;

        public RepositoryCliente RCliente
        {
            get { return _RepositoryCliente; }
        }

        public RepositoryProduto RProduto
        {
            get { return _RepositoryProduto; }
        }

        public RepositoryVenda RVenda
        {
            get { return _RepositoryVenda; }
        }

        public RepositoryVendaProduto RVendaProduto
        {
            get { return _RepositoryVendaProduto; }
        }

        public RepositoryCategoria RCategoria
        {
            get { return _RepositoryCategoria; }
        }

        public RepositoryFornecedor RFornecedor
        {
            get { return _RepositoryFornecedor; }
        }

        public ServiceVenda(LojaprodutosContext _db)
        {
            odb = _db;

            _RepositoryCliente = new RepositoryCliente(odb);
            _RepositoryProduto = new RepositoryProduto(odb);
            _RepositoryVenda = new RepositoryVenda(odb);
            _RepositoryVendaProduto = new RepositoryVendaProduto(odb);
            _RepositoryCategoria = new RepositoryCategoria(odb);
            _RepositoryFornecedor = new RepositoryFornecedor(odb);
        }


        public void Dispose()
        {
            _RepositoryCliente.Dispose();
            _RepositoryProduto.Dispose();
            _RepositoryVenda.Dispose();
            _RepositoryVendaProduto.Dispose();
            _RepositoryCategoria.Dispose();
            _RepositoryFornecedor.Dispose();
        }
    }
}
