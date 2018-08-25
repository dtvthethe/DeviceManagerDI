using DeviceManager.Data.Infrastructure;
using DeviceManager.Model.Models;

namespace DeviceManager.Data.IRepositories
{
    public class StatusRepository : RepositoryBase<Status>, IStatusRepository
    {
        public StatusRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}
