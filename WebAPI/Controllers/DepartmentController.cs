using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI.Data;
using WebAPI.Interface;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    public class DepartmentController : ApiController
    {

        private IDepartmentRepository _repository;

        public DepartmentController()
        {
            this._repository = new DepartmentRepository();
        }
        
        public HttpResponseMessage Get()
        {
            List<Department> departments = _repository.ListAll();
            return Request.CreateResponse(HttpStatusCode.OK, departments);
        }

        public string Post(Department department)
        {
            bool result = _repository.CreateDepartment(department);
            if (result)
            {
                return "Added Successfully!!";
            } else
            {
                return "Failed to Add!!";
            }
        }

        public string Put(Department department)
        {
            bool result = _repository.UpdateDepartment(department);
            if (result)
            {
                return "Update Successfully!!";
            }
            else
            {
                return "Failed to Update!!";
            }
        }

        public string Delete(int id)
        {
            bool result = _repository.RemoveDepartment(id);
            if (result)
            {
                return "Deleted Successfully!!";
            }
            else
            {
                return "Failed to Deleted!!";
            }
        }

    }
}