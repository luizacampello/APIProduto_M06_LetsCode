using APIProdutos.Core.Model;

namespace APIProdutos.Core.Interface
{
    public interface IProdutoService
    {
        List<Produto> ConsultarProdutos();
    }
}
