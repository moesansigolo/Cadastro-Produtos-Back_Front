using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Produtos.Domain;
using Produtos.Persistence;

namespace Produtos.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProdutoController : ControllerBase
    {
        private readonly ProdutosContext _context;

        public ProdutoController(ProdutosContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<Produto> Get()
        {
            return _context.Produtos;
        }

        [HttpGet("{id}")]
        public Produto GetById(int id)
        {
            return _context.Produtos.FirstOrDefault(p => p.Id == id);
        }
    }
}
