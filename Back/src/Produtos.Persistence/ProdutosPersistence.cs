using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Produtos.Domain;

namespace Produtos.Persistence
{
    public class ProdutosPersistence : IProdutosPersistence
    {
        private readonly ProdutosContext _context;
        public ProdutosPersistence(ProdutosContext context)
        {
            _context = context;
            _context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            
        }
        public void Add<T>(T entity) where T : class
        {
           _context.Add(entity);
        }        

        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public void DeleteRange<T>(T entityArray) where T : class
        {
            _context.RemoveRange(entityArray);
        }
        
        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }

         public async Task<Produto[]> GetAllProdutosAsync(bool incluiFornecedores = false)
        {
            IQueryable<Produto> query = _context.Produtos;

            if (incluiFornecedores)
            {
                query = query.Include(p => p.FornecedoresProdutos)
                             .ThenInclude(fp => fp.Fornecedor);
            }
            query = query.OrderBy(p => p.Id);
            return await query.ToArrayAsync();
        }
        
        public async Task<Produto[]> GetAllProdutosByNomeAsync(string nome, bool incluiFornecedor = false)
        {
            IQueryable<Produto> query = _context.Produtos;

            if (incluiFornecedor)
            {
                query = query.Include(p => p.FornecedoresProdutos)
                             .ThenInclude(fp => fp.Fornecedor);
            }
            query = query.OrderBy(p => p.Id).Where(p => p.NomeProduto.ToLower().Contains(nome.ToLower()));

            return await query.ToArrayAsync();
            
        }

         public async Task<Produto> GetProdutoByIdAsync(int produtoId, bool incluiFornecedor = false)
        {
            IQueryable<Produto> query = _context.Produtos;

            if (incluiFornecedor)
            {
                query = query.Include(p => p.FornecedoresProdutos)
                             .ThenInclude(fp => fp.Fornecedor);
            }
            query = query.OrderBy(p => p.Id).Where(p => p.Id == produtoId);

            return await query.FirstOrDefaultAsync();
            
        }

        public async Task<Fornecedor[]> GetAllFornecedoresAsync(bool incluiProdutos = false)
        {
            IQueryable<Fornecedor> query = _context.Fornecedores.Include(f => f.Telefone).Include(f => f.Email);

            if (incluiProdutos)
            {
                query = query.Include(f => f.FornecedoresProdutos).ThenInclude(fp => fp.Produto);
            }
            query = query.OrderBy(p => p.Id);
            return await query.ToArrayAsync();

        }

        public async Task<Fornecedor[]> GetAllFornecedoresByNomeAsync(string nome, bool incluiProdutos)
        {
            IQueryable<Fornecedor> query = _context.Fornecedores.Include(f => f.Telefone).Include(f => f.Email);

            if (incluiProdutos)
            {
                query = query.Include(f => f.FornecedoresProdutos).ThenInclude(fp => fp.Produto);
            }
            query = query.OrderBy(p => p.Id).Where(f => f.Nome.ToLower().Contains(nome.ToLower()));
            return await query.ToArrayAsync();
        }

        public async Task<Fornecedor> GetAllFornecedorByIdAsync(int fornecedorId, bool incluiProdutos = false)
        {
             IQueryable<Fornecedor> query = _context.Fornecedores.Include(f => f.Telefone).Include(f => f.Email);

            if (incluiProdutos)
            {
                query = query.Include(f => f.FornecedoresProdutos).ThenInclude(fp => fp.Produto);
            }
            query = query.OrderBy(p => p.Id).Where(f => f.Id == fornecedorId);
            return await query.FirstOrDefaultAsync();
        }
    }
}