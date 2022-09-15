using SuaSaude.Core.Dto;

namespace SuaSaude.Core.Interface
{
    public interface IControleDePeso
    {
        double CalcularIMC(double peso, double altura);
        Task<string> ClassificarIMCAsync(double imc);
        Task<DtoVerificarSaudeResponse> VerificarSaudeAsync(double peso, double altura);
    }
}
