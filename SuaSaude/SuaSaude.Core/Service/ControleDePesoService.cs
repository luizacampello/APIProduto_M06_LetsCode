using SuaSaude.Core.Dto;
using SuaSaude.Core.Interface;
using SuaSaude.Core.Model;

namespace SuaSaude.Core.Service
{
    public class ControleDePesoService : IControleDePeso
    {
        public IClassificacaoIMCRepository _classificacaoIMCRepository;
        public ControleDePesoService(IClassificacaoIMCRepository classificacaoIMCRepository)
        {
            _classificacaoIMCRepository = classificacaoIMCRepository;
        }

        public double CalcularIMC(double peso, double altura)
        {
            return peso / Math.Pow(altura, 2);
        }

        //public string ClassificarIMC(double imc)
        //{
        //    switch (imc)
        //    {
        //        case < 18.5:
        //            return "Magreza";
        //        case < 24.9:
        //            return "Normal";
        //        case < 29.9:
        //            return "Sobrepeso";
        //        case < 34.9:
        //            return "Obesidade Grau I";
        //        case < 39.9:
        //            return "Obesidade Grau II";
        //        default:
        //            return "Obesidade Grau III";
        //    }
        //}

        public async Task<string> ClassificarIMCAsync(double imc)
        {
            List<ClassificacaoIMC> classificacoes = await _classificacaoIMCRepository
                                                            .ConsultarClassificacaoAsync();

            var classificacao = classificacoes.FirstOrDefault(x => imc > x.IMCInicial &&
                                                                   imc < x.IMCFinal);

            if (classificacao == null)
            {
                return "IMC não identificado";
            }

            return classificacao.Descricao;
        }

        public async Task<DtoVerificarSaudeResponse> VerificarSaudeAsync(double peso, double altura)
        {
            var imc = CalcularIMC(peso, altura);

            return new DtoVerificarSaudeResponse()
            {
                imc = imc,
                descricao = await ClassificarIMCAsync(imc)
            };

            //var response = new DtoVerificarSaudeResponse()
            //{
            //    imc = CalcularIMC(peso, altura)                
            //};
            //response.descricao = await ClassificarIMCAsync(response.imc);

            //return response;
        }
    }
}
