using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using WebAPI.Data;
using WebAPI.Interface;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    public class EmployeeController : ApiController
    {

        private IEmployeeRepository _repository;

        public EmployeeController()
        {
            this._repository = new EmployeeRepository();
        }

        public HttpResponseMessage Get()
        {
            List<Employee> departments = _repository.ListAll();
            return Request.CreateResponse(HttpStatusCode.OK, departments);
        }

        [Route("api/employee/getAllDepartmentNames")]
        [HttpGet]
        public HttpResponseMessage GetAllDepartmentNames()
        {
            List<string> departments = _repository.DepartmentNames();
            return Request.CreateResponse(HttpStatusCode.OK, departments);
        }

        public string Post(Employee employee)
        {
            bool result = _repository.CreateEmployee(employee);
            if (result)
            {
                return "Added Successfully!!";
            }
            else
            {
                return "Failed to Add!!";
            }
        }

        public string Put(Employee employee)
        {
            bool result = _repository.UpdateEmployee(employee);
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
            bool result = _repository.RemoveEmployee(id);
            if (result)
            {
                return "Deleted Successfully!!";
            }
            else
            {
                return "Failed to Deleted!!";
            }
        }

        [Route("api/employee/saveFile")]
        [HttpPost]
        public string SaveFile()
        {
            try
            {
                var httpRequest = HttpContext.Current.Request;
                var postedFile = httpRequest.Files[0];
                string filename = postedFile.FileName;
                var path = HttpContext.Current.Server.MapPath("~/Photos/" + filename);

                postedFile.SaveAs(path);

                return filename;
            }
            catch (System.Exception)
            {
                return "anonymous.png";
            }
        }

    }
}
