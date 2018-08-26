using DeviceManager.Data.Infrastructure;
using DeviceManager.Data.IRepositories;
using DeviceManager.Model.Models;
using DeviceManager.Service.IServices;
using System.Collections.Generic;

namespace DeviceManager.Service.Services
{
    public class ReceiptDetailService : IReceiptDetailService
    {

        private readonly IReceiptDetailRepository _receiptDetailRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ReceiptDetailService(IReceiptDetailRepository receiptDetailRepository, IUnitOfWork unitOfWork)
        {
            _receiptDetailRepository = receiptDetailRepository;
            _unitOfWork = unitOfWork;
        }

        public ReceiptDetail Add(ReceiptDetail receiptDetail)
        {
            return _receiptDetailRepository.Add(receiptDetail);
        }

        public ReceiptDetail Delete(int id)
        {
            return _receiptDetailRepository.Delete(id);
        }

        public IEnumerable<ReceiptDetail> GetAll()
        {
            return _receiptDetailRepository.GetAll();
        }

        public ReceiptDetail GetById(int id)
        {
            return _receiptDetailRepository.GetSingleById(id);
        }

        public void SaveChanges()
        {
            _unitOfWork.Commit();
        }

        public ReceiptDetail Update(ReceiptDetail receiptDetail)
        {
            return _receiptDetailRepository.Update(receiptDetail);
        }
    }
}
