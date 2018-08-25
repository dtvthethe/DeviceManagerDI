using DeviceManager.Data.Infrastructure;
using DeviceManager.Data.IRepositories;
using DeviceManager.Model.Models;
using DeviceManager.Service.IServices;
using System.Collections.Generic;

namespace DeviceManager.Service.Services
{
    public class StatusService : IStatusService
    {
        private readonly IStatusRepository _statusRepository;
        private readonly IUnitOfWork _unitOfWork;

        public StatusService(IStatusRepository statusRepository, IUnitOfWork unitOfWork)
        {
            _statusRepository = statusRepository;
            _unitOfWork = unitOfWork;
        }

        public Status Add(Status status)
        {
            return _statusRepository.Add(status);
        }

        public Status Delete(int id)
        {
            return _statusRepository.Delete(id);
        }

        public IEnumerable<Status> GetAll()
        {
            return _statusRepository.GetAll();
        }

        public Status GetById(int id)
        {
            return _statusRepository.GetSingleById(id);
        }

        public Status Update(Status status)
        {
            return _statusRepository.Update(status);
        }

        public void SaveChanges()
        {
            _unitOfWork.Commit();
        }

    }
}
