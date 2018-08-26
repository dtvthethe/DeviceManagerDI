using System.Collections.Generic;
using DeviceManager.Data.Infrastructure;
using DeviceManager.Model.Models;
using System.Data.Entity;

namespace DeviceManager.Data.IRepositories
{
    public class DeviceRepository : RepositoryBase<Device>, IDeviceRepository
    {
        public DeviceRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }

        //public IEnumerable<Device> GetAll()
        //{
        //    return DbContext.Devices.Include(d => d.Category).Include(d => d.Status).Include(d => d.Unit);
        //}
    }
}
