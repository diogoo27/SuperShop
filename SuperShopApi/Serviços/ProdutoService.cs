using SuperShopApi.Data;
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

        public IEnumerable<Produto> GetProdutos()
        {
            return _context.Produtos.ToList();
        }

        public Produto GetProdutoById(int id)
        {
            return _context.Produtos.FirstOrDefault(p => p.Id == id);
        }

        public Produto AddProduto(Produto produto)
        {
            _context.Produtos.Add(produto);
            _context.SaveChanges();
            return produto;
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

        public Produto UpdateProduto(Produto produto)
        {
            var existente = _context.Produtos.FirstOrDefault(p => p.Id == produto.Id);
            if (existente != null)
            {
                existente.Nome = produto.Nome;
                existente.Preco = produto.Preco;
                _context.SaveChanges();
            }
            return existente;
        }
    }
}

