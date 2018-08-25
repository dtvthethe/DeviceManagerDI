using DeviceManager.Data.Infrastructure;
using DeviceManager.Data.IRepositories;
using DeviceManager.Model.Models;
using DeviceManager.Service.IServices;
using System.Collections.Generic;

namespace DeviceManager.Service.Services
{
    public class UnitService : IUnitService
    {
        private readonly IUnitRepository _unitRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UnitService(IUnitRepository unitRepository, IUnitOfWork unitOfWork)
        {
            _unitRepository = unitRepository;
            _unitOfWork = unitOfWork;
        }

        public Unit Add(Unit unit)
        {
            return _unitRepository.Add(unit);
        }

        public Unit Delete(int id)
        {
            return _unitRepository.Delete(id);
        }

        public IEnumerable<Unit> GetAll()
        {
            return _unitRepository.GetAll();
        }

        public Unit GetById(int id)
        {
            return _unitRepository.GetSingleById(id);
        }

        public Unit Update(Unit unit)
        {
            return _unitRepository.Update(unit);
        }

        public void SaveChanges()
        {
            _unitOfWork.Commit();
        }

    }
}
