using Microsoft.Extensions.Configuration;
using SuaSaude.Core.Interface;
using SuaSaude.Infra.Client.Advice.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace SuaSaude.Infra.Client.Advice
{
    public class ComunicaAdviceClient : IComunicaAdviceClient
    {
        public IHttpClientFactory _clientFactory;
        public IConfiguration _configuration;

        public ComunicaAdviceClient(IHttpClientFactory clientFactory, IConfiguration configuration)
        {
            _clientFactory = clientFactory;
            _configuration = configuration;
        }

        public async Task BuscarConselhoAsync1()
        {
            var client = _clientFactory.CreateClient("APIAdvice");

            var response = await client.GetAsync("/advice");

            Console.WriteLine(response.StatusCode);
            Console.WriteLine(response.IsSuccessStatusCode);
        }

        public async Task<string> BuscarConselhoAsync2()
        {
            var client = _clientFactory.CreateClient("APIAdvice");

            var response = await client.GetAsync("/advice");

            if (!response.IsSuccessStatusCode)
            {
                return "Conselho indisponível no momento";
            }

            var content = await response.Content?.ReadAsStringAsync();

            var advice = JsonSerializer.Deserialize<DtoBuscaConselhoGetResponse>(content);

            if (advice == null)
            {
                return "Não foi possível te aconselhar";
            }

            return advice.slip.advice;
        }
        public async Task<string> BuscarConselhoAsync()
        {
            var client = _clientFactory.CreateClient("APIAdvice");

            HttpResponseMessage response;
            try
            {
                response = await client.GetAsync(_configuration["APIAdviceAddressGet"]);
            }
            catch (HttpRequestException)
            {
                return "Houve um erro no serviço de conselhos";
            }
            catch (TaskCanceledException)
            {
                return "Não houve retorno no serviço de conselhos";
            }
            catch (Exception)
            {
                return "Erro inesperado no retorno do serviço de conselhos";
            }

            if (response == null)
            {
                return "Não foi possível obter um conselho";
            }

            if (!response.IsSuccessStatusCode)
            {
                return "Retorno sem sucesso do serviço de conselhos";
            }

            var content = await response.Content?.ReadAsStringAsync();

            var objectResponse = new DtoBuscaConselhoGetResponse();
            try
            {
                objectResponse = JsonSerializer.Deserialize<DtoBuscaConselhoGetResponse>(content);
            }
            catch (Exception ex)
            {
                return "Não foi possível te aconselhar";
            }

            return objectResponse.slip.advice;
        }
    }
}
