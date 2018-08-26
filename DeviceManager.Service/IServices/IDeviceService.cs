using DeviceManager.Model.Models;
using System.Collections.Generic;

namespace DeviceManager.Service.IServices
{
    public interface IDeviceService
    {
        Device Add(Device device);

        Device Update(Device device);

        Device Delete(int id);

        IEnumerable<Device> GetAll();

        Device GetById(int id);

        void SaveChanges();
    }
}
