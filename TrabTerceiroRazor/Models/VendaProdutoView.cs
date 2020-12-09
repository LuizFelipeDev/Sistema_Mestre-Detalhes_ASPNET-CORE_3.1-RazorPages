using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrabTerceiro.Data;

namespace TrabTerceiroRazor.Models
{
    public class VendaProdutoView : VendaProduto
    {
        public string ProdutoName { get; set; }

        public string CategoriaNome { get; set; }

        public string FornecedorNome { get; set; }
    }
}
