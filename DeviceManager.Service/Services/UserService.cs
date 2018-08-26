using System.Collections.Generic;
using DeviceManager.Common;
using DeviceManager.Data.Infrastructure;
using DeviceManager.Data.IRepositories;
using DeviceManager.Model.Models;
using DeviceManager.Service.IServices;

namespace DeviceManager.Service.Services
{
    public class UserService : IUserService
    {

        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UserService(IUserRepository userRepository, IUnitOfWork unitOfWork)
        {
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
        }

        public User Add(User user)
        {
            user = MapUser(user);
            return _userRepository.Add(user);
        }

        public User Update(User user)
        {
            user = MapUser(user);
            return _userRepository.Update(user);
        }

        public User Delete(string id)
        {
            var user = _userRepository.GetById(id);
            return _userRepository.Delete(user);
        }

        public IEnumerable<User> GetAll()
        {
            return _userRepository.GetAll();
        }

        public User GetById(string id)
        {
            return _userRepository.GetById(id);
        }

        public void SaveChanges()
        {
            _unitOfWork.Commit();
        }

        // Map User
        private User MapUser(User user)
        {
            if (string.IsNullOrEmpty(user.Password))
            {
                var us = _userRepository.GetById(user.Username);
                user.Password = us.Password;
            }
            else
            {
                user.Password = PasswordHelper.EncodePasswordMd5(user.Password);
            }

            return user;
        }

    }
}
