using DeviceManager.Data.Infrastructure;
using DeviceManager.Model.Models;

namespace DeviceManager.Data.IRepositories
{
    public class DeliveryDetailRepository : RepositoryBase<DeliveryDetail>, IDeliveryDetailRepository
    {
        public DeliveryDetailRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}
