using SuperShopApi.Models;
using System.Collections.Generic;

namespace SuperShopApi.Servicos
{
    public interface IProdutoService
    {
        IEnumerable<Produto> GetProdutos();
        Produto GetProdutoById(int id);
        Produto AddProduto(Produto produto);
        void DeleteProduto(int id);
        Produto UpdateProduto(Produto produto);
    }
}
