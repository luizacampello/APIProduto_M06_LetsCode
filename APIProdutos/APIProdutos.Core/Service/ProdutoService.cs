using APIProdutos.Core.Interface;
using APIProdutos.Core.Model;

namespace APIProdutos.Core.Service
{
    public class ProdutoService : IProdutoService
    {
        public IProdutoRepository _produtoRepository;
        public ProdutoService(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }
        public List<Produto> ConsultarProdutos()
        {
            return _produtoRepository.ConsultarProdutos();
        }
    }
}