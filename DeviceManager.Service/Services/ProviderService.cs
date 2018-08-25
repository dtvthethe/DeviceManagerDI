using DeviceManager.Data.Infrastructure;
using DeviceManager.Data.IRepositories;
using DeviceManager.Model.Models;
using DeviceManager.Service.IServices;
using System.Collections.Generic;

namespace DeviceManager.Service.Services
{
    public class ProviderService : IProviderService
    {
        private readonly IProviderRepository _providerRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ProviderService(IProviderRepository providerRepository, IUnitOfWork unitOfWork)
        {
            _providerRepository = providerRepository;
            _unitOfWork = unitOfWork;
        }

        public Provider Add(Provider provider)
        {
            return _providerRepository.Add(provider);
        }

        public Provider Delete(int id)
        {
            return _providerRepository.Delete(id);
        }

        public IEnumerable<Provider> GetAll()
        {
            return _providerRepository.GetAll();
        }

        public Provider GetById(int id)
        {
            return _providerRepository.GetSingleById(id);
        }

        public Provider Update(Provider provider)
        {
            return _providerRepository.Update(provider);
        }

        public void SaveChanges()
        {
            _unitOfWork.Commit();
        }

    }
}
