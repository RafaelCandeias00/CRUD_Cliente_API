using CRUD_Cliente.src.models;
using Microsoft.EntityFrameworkCore;

namespace CRUD_Cliente.src.context
{
    public class ClientContext : DbContext
    {
        public DbSet<Client> Clients { get; set; }

        public ClientContext(DbContextOptions<ClientContext> opt) : base(opt)
        {
        }

    }
}
