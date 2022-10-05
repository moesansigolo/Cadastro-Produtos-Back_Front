using System;
using System.Threading.Tasks;
using Produtos.Aplication.Contratos;
using Produtos.Domain;
using Produtos.Persistence;

namespace Produtos.Aplication
{
    public class ProdutoService : IProdutoService
    {
        private readonly IProdutosPersistence _produtosPersistence;
        public ProdutoService(IProdutosPersistence produtosPersistence)
        {
            _produtosPersistence = produtosPersistence;
            
        }

        public async Task<Produto> AddProduto(Produto model)
        {
            try
            {
                _produtosPersistence.Add<Produto>(model);
                if (await _produtosPersistence.SaveChangesAsync())
                {
                return await _produtosPersistence.GetProdutoByIdAsync(model.Id, false);
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        
        public async Task<Produto> UpdateProduto(int produtoId, Produto model)
        {
            try
            {
                 var produto = await _produtosPersistence.GetProdutoByIdAsync(produtoId, false);
                 if (produto == null) return null;

                 model.Id = produto.Id;
                 
                 _produtosPersistence.Update(model);
                 if (await _produtosPersistence.SaveChangesAsync())
                 {
                     return await _produtosPersistence.GetProdutoByIdAsync(model.Id, false);
                 }
                 return null;                    
                 
            }
            catch (Exception ex)
            {
                
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> DeleteProduto(int produtoId)
        {
            try
            {
                var produto = await _produtosPersistence.GetProdutoByIdAsync(produtoId, false);
                if (produto == null) throw new Exception("Produto não encontrado.");
                
                _produtosPersistence.Delete<Produto>(produto);
                return await _produtosPersistence.SaveChangesAsync();             
                  
            }
            catch (Exception ex)
            {
                
                throw new Exception(ex.Message);
            }
            
        }

        public async Task<Produto[]> GetAllProdutosAsync(bool incluiFornecedores = false)
        {
            try
            {
                var produtos = await _produtosPersistence.GetAllProdutosAsync(incluiFornecedores = false);
                if (produtos == null) return null;

                return produtos;             
                
            }
            catch (Exception ex)
            {
                
                throw new Exception(ex.Message);
            }
        }

        public async Task<Produto> GetProdutoByIdAsync(int produtoId, bool incluiFornecedores = false)
        {
             try
            {
                var produtos = await _produtosPersistence.GetProdutoByIdAsync(produtoId, incluiFornecedores = false);
                if (produtos == null) return null;

                return produtos;             
                
            }
            catch (Exception ex)
            {
                
                throw new Exception(ex.Message);
            }
        }
        public async Task<Produto[]> GetAllProdutosByNomeAsync(string nome, bool incluiFornecedores = false)
        {
            try
            {
                 var produtos = await _produtosPersistence.GetAllProdutosByNomeAsync(nome, incluiFornecedores);
                 if(produtos == null) return null;

                 return produtos;
            }
            catch (Exception ex)
            {
                
                throw new Exception(ex.Message);
            }
        }


    }
}