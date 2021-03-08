using System.Collections.Generic;
using WebAPI.Models;

namespace WebAPI.Interface
{
    interface IEmployeeRepository
    {

        List<Employee> ListAll();
        List<string> DepartmentNames();
        Employee GetById(int id);
        bool CreateEmployee(Employee employee);
        bool RemoveEmployee(int id);
        bool UpdateEmployee(Employee employee);

    }
}