using DeviceManager.Data.Infrastructure;
using DeviceManager.Model.Models;

namespace DeviceManager.Data.IRepositories
{
    public class ProviderRepository : RepositoryBase<Provider>, IProviderRepository
    {
        public ProviderRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}
