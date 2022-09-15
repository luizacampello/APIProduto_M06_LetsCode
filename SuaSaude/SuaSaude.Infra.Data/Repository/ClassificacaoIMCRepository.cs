
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using SuaSaude.Core.Interface;
using SuaSaude.Core.Model;

namespace SuaSaude.Infra.Data.Repository
{
    public class ClassificacaoIMCRepository : IClassificacaoIMCRepository
    {
        public IConfiguration _configuration;
        public ClassificacaoIMCRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task<List<ClassificacaoIMC>> ConsultarClassificacaoAsync()
        {
            var query = "SELECT * FROM classificacaoIMC";

            using var conn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));

            return (await conn.QueryAsync<ClassificacaoIMC>(query)).ToList();
        }
    }
}