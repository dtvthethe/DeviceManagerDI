using DeviceManager.Data.Infrastructure;
using DeviceManager.Model.Models;
using System.Collections.Generic;

namespace DeviceManager.Data.IRepositories
{
    public interface IUserRepository : IRepository<User>
    {
        User GetById(string id);
        IEnumerable<User> GetAll();
    }
}
