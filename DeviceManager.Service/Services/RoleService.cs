using DeviceManager.Data.Infrastructure;
using DeviceManager.Data.IRepositories;
using DeviceManager.Model.Models;
using DeviceManager.Service.IServices;
using System.Collections.Generic;

namespace DeviceManager.Service.Services
{
    public class RoleService : IRoleService
    {
        private readonly IRoleRepository _roleRepository;
        private readonly IUnitOfWork _unitOfWork;

        public RoleService(IRoleRepository roleRepository, IUnitOfWork unitOfWork)
        {
            _roleRepository = roleRepository;
            _unitOfWork = unitOfWork;
        }

        public Role Add(Role role)
        {
            return _roleRepository.Add(role);
        }

        public Role Delete(int id)
        {
            return _roleRepository.Delete(id);
        }

        public IEnumerable<Role> GetAll()
        {
            return _roleRepository.GetAll();
        }

        public Role GetById(int id)
        {
            return _roleRepository.GetSingleById(id);
        }

        public Role Update(Role role)
        {
            return _roleRepository.Update(role);
        }

        public void SaveChanges()
        {
            _unitOfWork.Commit();
        }

    }
}
