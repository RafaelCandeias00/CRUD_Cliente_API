using CRUD_Cliente.src.models;
using Microsoft.EntityFrameworkCore;

namespace CRUD_Cliente.src.context
{
    public class ClientContext : DbContext
    {
        #region Attribute
        public DbSet<Client> Clients { get; set; }
        #endregion

        #region Constructor
        public ClientContext(DbContextOptions<ClientContext> opt) : base(opt)
        {
        }
        #endregion

    }
}
