using DeviceManager.Data.Infrastructure;
using DeviceManager.Data.IRepositories;
using DeviceManager.Model.Models;
using DeviceManager.Service.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeviceManager.Service.Services
{
    public class DeliveryDetailService : IDeliveryDetailService
    {

        private readonly IDeliveryDetailRepository _deliveryDetailRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DeliveryDetailService(IDeliveryDetailRepository deliveryDetailRepository, IUnitOfWork unitOfWork)
        {
            _deliveryDetailRepository = deliveryDetailRepository;
            _unitOfWork = unitOfWork;
        }

        public DeliveryDetail Add(DeliveryDetail deliveryDetail)
        {
            return _deliveryDetailRepository.Add(deliveryDetail);
        }

        public DeliveryDetail Delete(int id)
        {
            return _deliveryDetailRepository.Delete(id);
        }

        public IEnumerable<DeliveryDetail> GetAll()
        {
            return _deliveryDetailRepository.GetAll();
        }

        public DeliveryDetail GetById(int id)
        {
            return _deliveryDetailRepository.GetSingleById(id);
        }

        public void SaveChanges()
        {
            _unitOfWork.Commit();
        }

        public DeliveryDetail Update(DeliveryDetail deliveryDetail)
        {
            return _deliveryDetailRepository.Update(deliveryDetail);
        }
    }
}
