using DeviceManager.Model.Models;
using System.Collections.Generic;

namespace DeviceManager.Service.IServices
{
    public interface IReceiptService
    {
        Receipt Add(Receipt receipt);

        Receipt Update(Receipt receipt);

        Receipt Delete(int id);

        IEnumerable<Receipt> GetAll();

        Receipt GetById(int id);

        void SaveChanges();
    }
}
