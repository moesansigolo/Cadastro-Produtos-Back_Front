using Microsoft.EntityFrameworkCore;
using Produtos.API.Models;

namespace Produtos.API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options){}
        public DbSet<Produto> Produtos { get; set; }
    }
}