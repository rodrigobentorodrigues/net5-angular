using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using WebAPI.Interface;
using WebAPI.Models;

namespace WebAPI.Data
{
    public class DepartmentRepository : IDepartmentRepository
    {

        private SqlConnection connection;

        public DepartmentRepository()
        {
            this.connection = ConFactory.getConnection();
        }

        public List<Department> ListAll()
        {
            List<Department> departments = new List<Department>();

            try
            {
                string query = "SELECT * FROM Department";

                connection.Open();

                SqlCommand command = new SqlCommand(query, connection);
                command.CommandType = CommandType.Text;

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable data = new DataTable();
                adapter.Fill(data);

                foreach (DataRow row in data.Rows)
                {
                    Department department = new Department
                    {
                        DepartmentId = Convert.ToInt32(row["DepartmentId"]),
                        DepartmentName = Convert.ToString(row["DepartmentName"])
                    };
                    departments.Add(department);
                }

                command.Dispose();
                adapter.Dispose();
                data.Dispose();
            } catch (Exception)
            {

            } finally
            {
                connection.Close();
            }

            return departments;
        }

        public Department GetById(int id)
        {
            throw new NotImplementedException();
        }

        public bool CreateDepartment(Department department)
        {
            bool result = false;
            try
            {
                string query = "INSERT INTO Department VALUES (@Name)";

                connection.Open();

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Name", department.DepartmentName);

                result = command.ExecuteNonQuery() > 0 ? true : false;
                command.Dispose();
            }
            catch (Exception)
            {

            } finally
            {
                connection.Close();
            }
            return result;
        }

        public bool RemoveDepartment(int id)
        {
            bool result = false;
            try
            {
                string query = "DELETE FROM Department " +
                    "WHERE DepartmentId = @Id";

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

        public bool UpdateDepartment(Department department)
        {
            bool result = false;
            try
            {
                string query = "UPDATE Department SET DepartmentName = @Name " +
                    "WHERE DepartmentId = @Id";

                connection.Open();

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Name", department.DepartmentName);
                command.Parameters.AddWithValue("@Id", department.DepartmentId);

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