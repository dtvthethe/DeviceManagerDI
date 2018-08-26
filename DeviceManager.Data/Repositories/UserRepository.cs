using System.Collections.Generic;
using DeviceManager.Data.Infrastructure;
using DeviceManager.Model.Models;
using System.Data.Entity;

namespace DeviceManager.Data.IRepositories
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }

        public IEnumerable<User> GetAll()
        {
            return DbContext.Users.Include(r => r.Department).Include(u => u.Role);
        }

        public User GetById(string id)
        {
            return DbContext.Users.Find(id);
        }
    }
}
