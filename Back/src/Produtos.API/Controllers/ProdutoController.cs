using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Produtos.API.Data;
using Produtos.API.Models;

namespace Produtos.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProdutoController : ControllerBase
    {
        private readonly DataContext _context;

        public ProdutoController(DataContext context)
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
            return _context.Produtos.FirstOrDefault(p => p.ProdutoId == id);
        }
    }
}
