using DeviceManager.Data.Infrastructure;
using DeviceManager.Model.Models;

namespace DeviceManager.Data.IRepositories
{
    public class ReceiptDetailRepository : RepositoryBase<ReceiptDetail>, IReceiptDetailRepository
    {
        public ReceiptDetailRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}
