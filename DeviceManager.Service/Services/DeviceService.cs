using DeviceManager.Data.Infrastructure;
using DeviceManager.Model.Models;
using DeviceManager.Service.IServices;
using System.Collections.Generic;

namespace DeviceManager.Service.Services
{
    public class DeviceService : IDeviceService
    {

        private readonly IDeviceService _deviceService;
        private readonly IUnitOfWork _unitOfWork;

        public DeviceService(IDeviceService deviceService, IUnitOfWork unitOfWork)
        {
            _deviceService = deviceService;
            _unitOfWork = unitOfWork;
        }

        public Device Add(Device device)
        {
            return _deviceService.Add(device);
        }

        public Device Delete(int id)
        {
            return _deviceService.Delete(id);
        }

        public IEnumerable<Device> GetAll()
        {
            return _deviceService.GetAll();
        }

        public Device GetById(int id)
        {
            return _deviceService.GetById(id);
        }

        public void SaveChanges()
        {
            _unitOfWork.Commit();
        }

        public Device Update(Device device)
        {
            return _deviceService.Update(device);
        }
    }
}
