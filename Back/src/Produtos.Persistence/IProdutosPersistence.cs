using System.Threading.Tasks;
using Produtos.Domain;

namespace Produtos.Persistence
{
    public interface IProdutosPersistence
    {
        //GERAL
        void Add<T>(T entity) where T: class;
        void Update<T>(T entity) where T: class;
        void Delete<T>(T entity) where T: class;
        void DeleteRange<T>(T entity) where T: class;
        Task<bool> SaveChangesAsync();

        //EVENTOS
        Task<Produto[]> GetAllProdutosByNomeAsync(string nome, bool incluiFornecedor);
        Task<Produto[]> GetAllProdutosAsync( bool incluiFornecedor);
        Task<Produto> GetAllProdutoByIdAsync(int ProdutoId, bool incluiFornecedor);

        //FORNECEDORES
        Task<Fornecedor[]> GetAllFornecedoresByNomeAsync(string nome, bool incluiProdutos);
        Task<Fornecedor[]> GetAllFornecedoresAsync( bool incluiProdutos);
        Task<Fornecedor> GetAllFornecedorByIdAsync(int FornecedorId, bool incluiProdutos);


    }
}