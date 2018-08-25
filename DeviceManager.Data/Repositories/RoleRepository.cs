using DeviceManager.Data.Infrastructure;
using DeviceManager.Model.Models;

namespace DeviceManager.Data.IRepositories
{
    public class RoleRepository : RepositoryBase<Role>, IRoleRepository
    {
        public RoleRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}
