using CRUD_Cliente.src.context;
using CRUD_Cliente.src.dto;
using CRUD_Cliente.src.models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUD_Cliente.src.repositories.implements
{
    public class ClientRepository : IClient
    {
        #region Attribute
        private readonly ClientContext _context;
        #endregion

        #region Constructor
        public ClientRepository(ClientContext context)
        {
            _context = context;
        }


        #endregion

        #region Method
        public async Task<List<Client>> GetAllClient()
        {
            return await _context.Clients.ToListAsync();
        }

        public async Task<Client> GetById(int id)
        {
            if (!ExistId(id)) throw new Exception("Id não existe!");

            return await _context.Clients.FirstOrDefaultAsync(c => c.Id == id);

            bool ExistId(int id)
            {
                var aux = _context.Clients.FirstOrDefault(c => c.Id == id);
                return aux != null;
            }
        }

        public async Task<Client> GetByName(string name)
        {
            return await _context.Clients.FirstOrDefaultAsync(c => c.Nome == name);
        }

        public async Task<List<Client>> GetByNames(string name)
        {
            return await _context.Clients.Where(c => c.Nome.Contains(name)).ToListAsync();
        }

        public async Task Create(NewClientDTO client)
        {
            await _context.Clients.AddAsync(new Client
            {
                Nome = client.Nome,
                CPF = client.CPF,
                DataNascimento = client.DataNasciemento,
                Sexo = client.Sexo,
                Estado = client.Estado,
                Cidade = client.Cidade

            });
            await _context.SaveChangesAsync();
        }

        public async Task Update(UpdateClientDTO client)
        {
            var aux = await _context.Clients.FirstOrDefaultAsync(c => c.Id == client.Id);

            aux.Nome = client.Nome;
            aux.DataNascimento = client.DataNasciemento;
            aux.Sexo = client.Sexo;
            aux.Estado = client.Estado;
            aux.Cidade = client.Cidade;

            _context.Clients.Update(aux);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            _context.Clients.Remove(_context.Clients.FirstOrDefault(c => c.Id == id));
            await _context.SaveChangesAsync();
        }
        #endregion
    }
}
