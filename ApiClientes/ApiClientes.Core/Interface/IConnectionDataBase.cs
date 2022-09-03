using System.Data;

namespace ApiClientes.Interface
{
    public interface IConnectionDataBase
    {
        IDbConnection CreateConnection();
    }
}
