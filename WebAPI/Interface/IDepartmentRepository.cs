using System.Collections.Generic;
using WebAPI.Models;

namespace WebAPI.Interface
{
    interface IDepartmentRepository
    {

        List<Department> ListAll();
        Department GetById(int id);
        bool CreateDepartment(Department department);
        bool RemoveDepartment(int id);
        bool UpdateDepartment(Department department);

    }
}
