using DeviceManager.Data.Infrastructure;
using DeviceManager.Model.Models;

namespace DeviceManager.Data.IRepositories
{
    public class DepartmentRepository : RepositoryBase<Department>, IDepartmentRepository
    {
        public DepartmentRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}
