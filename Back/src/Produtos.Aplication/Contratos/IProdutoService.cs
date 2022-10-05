using System.Threading.Tasks;
using Produtos.Domain;

namespace Produtos.Aplication.Contratos
{
    public interface IProdutoService
    {
        Task<Produto> AddProduto(Produto model);
        Task<Produto> UpdateProduto(int produtoId, Produto model);
        Task<bool> DeleteProduto(int produtoId);

        Task<Produto[]> GetAllProdutosAsync(bool incluiFornecedores = false);
        Task<Produto[]> GetAllProdutosByNomeAsync(string nome, bool incluiFornecedor = false);
        Task<Produto> GetProdutoByIdAsync(int produtoId, bool incluiFornecedores = false);
    }
}