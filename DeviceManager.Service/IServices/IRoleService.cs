using DeviceManager.Model.Models;
using System.Collections.Generic;

namespace DeviceManager.Service.IServices
{
    public interface IRoleService
    {
        Role Add(Role role);

        Role Update(Role role);

        Role Delete(int id);

        IEnumerable<Role> GetAll();

        Role GetById(int id);

        void SaveChanges();
    }
}
