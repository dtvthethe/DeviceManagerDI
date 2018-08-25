using DeviceManager.Model.Models;
using System.Collections.Generic;

namespace DeviceManager.Service.IServices
{
    public interface IProviderService
    {
        Provider Add(Provider provider);

        Provider Update(Provider provider);

        Provider Delete(int id);

        IEnumerable<Provider> GetAll();

        Provider GetById(int id);

        void SaveChanges();
    }
}
