using DeviceManager.Data.Infrastructure;
using DeviceManager.Data.IRepositories;
using DeviceManager.Model.Models;
using DeviceManager.Service.IServices;
using System.Collections.Generic;

namespace DeviceManager.Service.Services
{
    public class ReceiptService : IReceiptService
    {
        private readonly IReceiptRepository _receiptRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ReceiptService(IReceiptRepository receiptRepository, IUnitOfWork unitOfWork)
        {
            _receiptRepository = receiptRepository;
            _unitOfWork = unitOfWork;
        }

        public Receipt Add(Receipt receipt)
        {
            return _receiptRepository.Add(receipt);
        }

        public Receipt Delete(int id)
        {
            return _receiptRepository.Delete(id);
        }

        public IEnumerable<Receipt> GetAll()
        {
            return _receiptRepository.GetAll();
        }

        public Receipt GetById(int id)
        {
            return _receiptRepository.GetSingleById(id);
        }

        public void SaveChanges()
        {
            _unitOfWork.Commit();
        }

        public Receipt Update(Receipt receipt)
        {
            return _receiptRepository.Update(receipt);
        }
    }
}
