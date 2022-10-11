using CRUD_Cliente.src.dto;
using CRUD_Cliente.src.models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CRUD_Cliente.src.repositories
{
    /// <summary>
    /// <para>Resumo: Resposável por representar ações de CRUD</para>
    /// </summary>
    public interface IClient
    {
        Task<List<Client>> GetAllClient();

        Task<Client> GetById(int id);
        Task<Client> GetByName(string name);
        Task<List<Client>> GetByNames(string name);

        Task Create(NewClientDTO client);
        Task Update(UpdateClientDTO client);

        Task Delete(int id);
    }
}
