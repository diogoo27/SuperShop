using SuperShopApi.Data;
using SuperShopApi.DTOs;
using SuperShopApi.Models;
using System.Collections.Generic;
using System.Linq;

namespace SuperShopApi.Servicos
{
    public class ProdutoService : IProdutoService
    {
        private readonly AppDbContext _context;

        public ProdutoService(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<ProdutoDTO> GetProdutos()
        {
            return _context.Produtos.Select(p => new ProdutoDTO
            {
                Id = p.Id,
                Nome = p.Nome,
                Preco = p.Preco
            }).ToList();
        }

        public ProdutoDTO GetProdutoById(int id)
        {
            var p = _context.Produtos.FirstOrDefault(p => p.Id == id);
            if (p == null) return null;

            return new ProdutoDTO
            {
                Id = p.Id,
                Nome = p.Nome,
                Preco = p.Preco
            };
        }

        public ProdutoDTO AddProduto(ProdutoDTO produtoDto)
        {
            var produto = new Produto
            {
                Nome = produtoDto.Nome,
                Preco = produtoDto.Preco
            };
            

            _context.Produtos.Add(produto);
            _context.SaveChanges();

            produtoDto.Id = produto.Id;
            return produtoDto;
        }

        public void DeleteProduto(int id)
        {
            var produto = _context.Produtos.FirstOrDefault(p => p.Id == id);
            if (produto != null)
            {
                _context.Produtos.Remove(produto);
                _context.SaveChanges();
            }
        }

        public ProdutoDTO UpdateProduto(ProdutoDTO produtoDto)
        {
            var existente = _context.Produtos.FirstOrDefault(p => p.Id == produtoDto.Id);
            if (existente == null) return null;

            existente.Nome = produtoDto.Nome;
            existente.Preco = produtoDto.Preco;
            _context.SaveChanges();

            return produtoDto;
        }
    }
}

