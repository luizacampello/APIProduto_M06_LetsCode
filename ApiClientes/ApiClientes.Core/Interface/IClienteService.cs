using ApiClientes.Models;

namespace ApiClientes.Interface
{
    public interface IClienteService
    {
        Task<List<Cliente>> GetAllAsync();
        Task<Cliente> GetByCpf(string cpf);
        Task<bool> Insert(Cliente cliente);
        Task<bool> Update(long id, Cliente cliente);
        Task<bool> Delete(long id);
    }
}
