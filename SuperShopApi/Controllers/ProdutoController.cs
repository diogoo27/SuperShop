using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace SuperShopApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProdutoController : ControllerBase
    {
        private static List<Produto> produtos = new List<Produto>
        {
            new Produto { Id = 1, Nome = "Rato", Descricao = "Rato sem fio", Quantidade = 10, Preco = 25.99M },
            new Produto { Id = 2, Nome = "Teclado", Descricao = "Teclado inteligente", Quantidade = 5, Preco = 99.90M }
        };

        [HttpGet]
        public IEnumerable<Produto> Get()
        {
            return produtos;
        }

        [HttpGet("{id}")]
        public ActionResult<Produto> Get(int id)
        {
            var produto = produtos.FirstOrDefault(p => p.Id == id);
            if (produto == null)
                return NotFound();

            return produto;
        }

        [HttpPost]
        public IActionResult Post([FromBody] Produto produto)
        {
            produto.Id = produtos.Max(p => p.Id) + 1;
            produtos.Add(produto);
            return CreatedAtAction(nameof(Get), new { id = produto.Id }, produto);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Produto produtoAtualizado)
        {
            var produto = produtos.FirstOrDefault(p => p.Id == id);
            if (produto == null)
                return NotFound();

            produto.Nome = produtoAtualizado.Nome;
            produto.Descricao = produtoAtualizado.Descricao;
            produto.Quantidade = produtoAtualizado.Quantidade;
            produto.Preco = produtoAtualizado.Preco;

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var produto = produtos.FirstOrDefault(p => p.Id == id);
            if (produto == null)
                return NotFound();

            produtos.Remove(produto);
            return NoContent();
        }
    }
}
