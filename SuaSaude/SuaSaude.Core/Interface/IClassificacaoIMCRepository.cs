using SuaSaude.Core.Model;

namespace SuaSaude.Core.Interface
{
    public interface IClassificacaoIMCRepository
    {
        Task<List<ClassificacaoIMC>> ConsultarClassificacaoAsync();
    }
}
