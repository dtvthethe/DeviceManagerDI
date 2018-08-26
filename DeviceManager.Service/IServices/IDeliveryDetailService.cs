using DeviceManager.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeviceManager.Service.IServices
{
    public interface IDeliveryDetailService
    {
        DeliveryDetail Add(DeliveryDetail deliveryDetail);

        DeliveryDetail Update(DeliveryDetail deliveryDetail);

        DeliveryDetail Delete(int id);

        IEnumerable<DeliveryDetail> GetAll();

        DeliveryDetail GetById(int id);

        void SaveChanges();
    }
}
