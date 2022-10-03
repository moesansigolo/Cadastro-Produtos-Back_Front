using System;

namespace Produtos.API.Models
{
    public class Produto
    {
        public int ProdutoId { get; set; }
        public string NomeProduto { get; set; }
        public int QntUnitaria { get; set; }
        public double Preco { get; set; }
        public double Peso { get; set; }
        public DateTime DataInclusao { get; set; } 
        public DateTime DataValidade { get; set; }
        public string ImageUrl { get; set; }        
    
    }
}