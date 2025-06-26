using SuperShopApi.DTOs;
using System.Collections.Generic;

namespace SuperShopApi.Servicos
{
    public interface IProdutoService
    {
        IEnumerable<ProdutoDTO> GetProdutos();
        ProdutoDTO GetProdutoById(int id);
        ProdutoDTO AddProduto(ProdutoDTO produtoDto);
        void DeleteProduto(int id);
        ProdutoDTO UpdateProduto(ProdutoDTO produtoDto);
    }
}
