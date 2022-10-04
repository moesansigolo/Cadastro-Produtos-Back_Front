using Microsoft.EntityFrameworkCore;
using Produtos.Domain;

namespace Produtos.Persistence
{
    public class ProdutosContext : DbContext
    {
        public ProdutosContext(DbContextOptions<ProdutosContext> options) : base(options){}
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Fornecedor> Fornecedores { get; set; }
        public DbSet<FornecedorProduto> FornecedoresProdutos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FornecedorProduto>()
                .HasKey(FP => new { FP.ProdutoId, FP.FornecedorId});
        }
    }
}