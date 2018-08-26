using DeviceManager.Data.Infrastructure;
using DeviceManager.Model.Models;
using System.Collections.Generic;

namespace DeviceManager.Data.IRepositories
{
    public interface IDeviceRepository : IRepository<Device>
    {
        //IEnumerable<Device> GetAll();
    }
}
