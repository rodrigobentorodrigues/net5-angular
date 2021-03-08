using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using WebAPI.Interface;
using WebAPI.Models;

namespace WebAPI.Data
{
    public class EmployeeRepository : IEmployeeRepository
    {

        private SqlConnection connection;

        public EmployeeRepository()
        {
            this.connection = ConFactory.getConnection();
        }

        public bool CreateEmployee(Employee employee)
        {
            bool result = false;
            try
            {
                string query = "INSERT INTO Employee VALUES (@Name, @Department, @Date, @Photo)";

                connection.Open();

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Name", employee.EmployeeName);
                command.Parameters.AddWithValue("@Department", employee.Department);
                command.Parameters.AddWithValue("@Date", employee.DateOfJoining);
                command.Parameters.AddWithValue("@Photo", employee.PhotoFileName);

                result = command.ExecuteNonQuery() > 0 ? true : false;
                command.Dispose();
            }
            catch (Exception)
            {

            }
            finally
            {
                connection.Close();
            }
            return result;
        }

        public Employee GetById(int id)
        {
            Employee employee = new Employee();
            try
            {

            }
            catch (Exception)
            {

            }
            finally
            {
                connection.Close();
            }
            return employee;
        }

        public List<Employee> ListAll()
        {
            List<Employee> employees = new List<Employee>();
            try
            {
                string query = "SELECT * FROM Employee";

                connection.Open();

                SqlCommand command = new SqlCommand(query, connection);
                command.CommandType = CommandType.Text;

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable data = new DataTable();
                adapter.Fill(data);

                foreach (DataRow row in data.Rows)
                {
                    Employee employee = new Employee
                    {
                        EmployeeId = Convert.ToInt32(row["EmployeeId"]), 
                        EmployeeName = Convert.ToString(row["EmployeeName"]),
                        Department = Convert.ToString(row["Department"]),
                        DateOfJoining = Convert.ToString(row["DateOfJoining"]),
                        PhotoFileName = Convert.ToString(row["PhotoFileName"])
                    };

                    employees.Add(employee);
                }

                command.Dispose();
                adapter.Dispose();
                data.Dispose();
            }
            catch (Exception)
            {

            }
            finally
            {
                connection.Close();
            }
            return employees;
        }

        public List<string> DepartmentNames()
        {
            List<string> departmentNames = new List<string>();
            try
            {
                string query = "SELECT DepartmentName FROM Department";

                connection.Open();

                SqlCommand command = new SqlCommand(query, connection);
                command.CommandType = CommandType.Text;

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable data = new DataTable();
                adapter.Fill(data);

                foreach (DataRow row in data.Rows)
                {
                    departmentNames.Add(Convert.ToString(row["DepartmentName"]));
                }

                command.Dispose();
                adapter.Dispose();
                data.Dispose();
            }
            catch (Exception)
            {

            }
            finally
            {
                connection.Close();
            }
            return departmentNames;
        }

        public bool RemoveEmployee(int id)
        {
            bool result = false;
            try
            {
                string query = "DELETE FROM Employee WHERE EmployeeId = @Id";

                connection.Open();

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Id", id);

                result = command.ExecuteNonQuery() > 0 ? true : false;
                command.Dispose();
            }
            catch (Exception)
            {

            }
            finally
            {
                connection.Close();
            }
            return result;
        }

        public bool UpdateEmployee(Employee employee)
        {
            bool result = false;
            try
            {
                string query = "UPDATE Employee " +
                    "SET EmployeeName = @Name, Department = @Department, " +
                    "DateOfJoining = @Date, PhotoFileName = @Photo " +
                    "WHERE EmployeeId = @Id";

                connection.Open();

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Id", employee.EmployeeId);
                command.Parameters.AddWithValue("@Name", employee.EmployeeName);
                command.Parameters.AddWithValue("@Department", employee.Department);
                command.Parameters.AddWithValue("@Date", employee.DateOfJoining);
                command.Parameters.AddWithValue("@Photo", employee.PhotoFileName);

                result = command.ExecuteNonQuery() > 0 ? true : false;
                command.Dispose();
            }
            catch (Exception)
            {

            }
            finally
            {
                connection.Close();
            }
            return result;
        }
    }
}