using Microsoft.AspNetCore.Mvc;
using SuperShopApi.DTOs;
using SuperShopApi.Servicos;

namespace SuperShopApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoService _produtoService;

        public ProdutoController(IProdutoService produtoService)
        {
            _produtoService = produtoService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var produtos = _produtoService.GetProdutos();
            return Ok(produtos);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var produto = _produtoService.GetProdutoById(id);
            if (produto == null)
                return NotFound();

            return Ok(produto);
        }

        [HttpPost]
        public IActionResult Post([FromBody] ProdutoDTO produtoDto)
        {
            var novoProduto = _produtoService.AddProduto(produtoDto);
            return CreatedAtAction(nameof(GetById), new { id = novoProduto.Id }, novoProduto);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] ProdutoDTO produtoDto)
        {
            if (id != produtoDto.Id)
                return BadRequest();

            var atualizado = _produtoService.UpdateProduto(produtoDto);
            if (atualizado == null)
                return NotFound();

            return Ok(atualizado);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _produtoService.DeleteProduto(id);
            return NoContent();
        }
    }
}
