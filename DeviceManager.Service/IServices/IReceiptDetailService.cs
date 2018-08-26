using DeviceManager.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeviceManager.Service.IServices
{
    public interface IReceiptDetailService
    {
        ReceiptDetail Add(ReceiptDetail receiptDetail);

        ReceiptDetail Update(ReceiptDetail receiptDetail);

        ReceiptDetail Delete(int id);

        IEnumerable<ReceiptDetail> GetAll();

        ReceiptDetail GetById(int id);

        void SaveChanges();
    }
}
