using DeviceManager.Model.Models;
using System.Collections.Generic;

namespace DeviceManager.Service.IServices
{
    public interface IDeliveryService
    {
        Delivery Add(Delivery delivery);

        Delivery Update(Delivery delivery);

        Delivery Delete(int id);

        IEnumerable<Delivery> GetAll();

        Delivery GetById(int id);

        void SaveChanges();
    }
}
