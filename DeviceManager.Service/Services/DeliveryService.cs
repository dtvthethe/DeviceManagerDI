using DeviceManager.Data.Infrastructure;
using DeviceManager.Model.Models;
using DeviceManager.Service.IServices;
using System;
using System.Collections.Generic;

namespace DeviceManager.Service.Services
{
    public class DeliveryService : IDeliveryService
    {

        private readonly IDeliveryService _deliveryService;
        private readonly IUnitOfWork _unitOfWork;

        public DeliveryService(IDeliveryService deliveryService, IUnitOfWork unitOfWork)
        {
            _deliveryService = deliveryService;
            _unitOfWork = unitOfWork;
        }

        public Delivery Add(Delivery delivery)
        {
            return _deliveryService.Add(delivery);
        }

        public Delivery Delete(int id)
        {
            return _deliveryService.Delete(id);
        }

        public IEnumerable<Delivery> GetAll()
        {
            return _deliveryService.GetAll();
        }

        public Delivery GetById(int id)
        {
            return _deliveryService.GetById(id);
        }

        public void SaveChanges()
        {
            _unitOfWork.Commit();
        }

        public Delivery Update(Delivery delivery)
        {
            return _deliveryService.Update(delivery);
        }
    }
}
