using DeviceManager.Model.Models;
using System.Collections.Generic;

namespace DeviceManager.Service.IServices
{
    public interface IUserService
    {
        User Add(User user);

        User Update(User user);

        User Delete(string id);

        IEnumerable<User> GetAll();

        User GetById(string id);

        void SaveChanges();
    }
}
