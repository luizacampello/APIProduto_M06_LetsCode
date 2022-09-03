using APIProdutos.Core.Model;

namespace APIProdutos.Core.Interface
{
    public interface IProdutoRepository
    {
        List<Produto> ConsultarProdutos();
    }
}
