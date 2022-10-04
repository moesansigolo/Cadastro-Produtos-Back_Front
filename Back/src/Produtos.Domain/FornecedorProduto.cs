using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Produtos.Domain
{
    public class FornecedorProduto
    {
        public int FornecedorId { get; set; }
        public Fornecedor Fornecedor { get; set; }
        public int ProdutoId { get; set; }
        public Produto Produto { get; set; }
    }
}