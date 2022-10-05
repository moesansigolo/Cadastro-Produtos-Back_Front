using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Produtos.Aplication.Contratos;
using Produtos.Domain;
using Produtos.Persistence;

namespace Produtos.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoService _produtoService;

        public ProdutoController(IProdutoService produtoService)
        {
            _produtoService = produtoService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var produtos = await _produtoService.GetAllProdutosAsync(true);
                if (produtos == null) return NotFound("Nenhum produto encontrado.");
                return Ok(produtos);                    
            }
            catch (Exception ex)
            {
                
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar recuperar produtos. Erro: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                 var produto = await _produtoService.GetProdutoByIdAsync(id, true);
                 if(produto == null) return NotFound("Produto não encontrado");
                 return Ok(produto);
            }
            catch (Exception ex)
            {                
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar recuperar produtos. Erro: {ex.Message}");
            }
        }

        [HttpGet("{nome}/nome")]
        public async Task<IActionResult> GetByNome(string nome)
        {
            try
            {
                 var produto = await _produtoService.GetAllProdutosByNomeAsync(nome, true);
                 if(produto == null) return NotFound("Produto não encontrado");
                 return Ok(produto);
            }
            catch (Exception ex)
            {                
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar recuperar produtos. Erro: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(Produto model)
        {
            try
            {
                var produto = await _produtoService.AddProduto(model); 
                if(produto == null) return BadRequest("Erro ao tentar adicionar o produto.");
                return Ok(produto);
            }
            catch (Exception ex)
            {
                
                 return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar adicionar o produto. Erro: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Produto model)
        {
            try
            {
                var produto = await _produtoService.UpdateProduto(id, model);
                if(produto == null) return BadRequest("Produto não encontrado.");
                return Ok(produto);                 
            }
            catch (Exception ex)
            {
                
                 return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar atualizar o produto. Erro: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                if(await _produtoService.DeleteProduto(id))
                {
                return Ok("Deletado");
                } else
                {
                return BadRequest("Produto não deletado");
                }
            }
            catch (Exception ex)
            {                
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar deletar o produto. Erro: {ex.Message}");
            }
        }
           
    }
}
