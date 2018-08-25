using DeviceManager.Model.Models;
using System.Collections.Generic;

namespace DeviceManager.Service.IServices
{
    public interface IDepartmentService
    {
        Department Add(Department department);

        Department Update(Department department);

        Department Delete(int id);

        IEnumerable<Department> GetAll();

        Department GetById(int id);

        void SaveChanges();
    }
}
