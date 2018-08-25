using DeviceManager.Data.Infrastructure;
using DeviceManager.Model.Models;

namespace DeviceManager.Data.IRepositories
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}
