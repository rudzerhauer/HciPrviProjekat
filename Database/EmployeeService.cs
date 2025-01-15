using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using WpfApp1.Models;

namespace WpfApp1.Database
{
    public class EmployeeService
    {
        private MySqlDbContext _dbContext;

        public EmployeeService()
        {
            _dbContext = new MySqlDbContext();
        }
        //get all employees
        public List<Employee> GetAllEmployees()
        {
            List<Employee> employees = new List<Employee>();

            using (var connection = _dbContext.GetConnection())
            {
                connection.Open();

                string query = "SELECT * FROM employee";

                MySqlCommand cmd = new MySqlCommand(query, connection);
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        employees.Add(new Employee
                        {
                            EmployeeId = reader.GetInt32("EmployeeID"),
                            FullName = reader.GetString("FullName"),
                            Username = reader.GetString("Username"),
                            Role = reader.GetString("Role"),
                            Email = reader.GetString("Email"),
                            PhoneNumber = reader.GetString("PhoneNumber")
                        });
                    }
                }
            }

            return employees;
        }
        //insert employee into database
        public void CreateEmployee(Employee employee)
        {
            using (var connection = _dbContext.GetConnection())
            {
                connection.Open();

                string query = "INSERT INTO employee (FullName, Username, PasswordHash, Role, Email, PhoneNumber) " +
                               "VALUES (@FullName, @Username, @PasswordHash, @Role, @Email, @PhoneNumber)";

                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@FullName", employee.FullName);
                cmd.Parameters.AddWithValue("@Username", employee.Username);
                cmd.Parameters.AddWithValue("@PasswordHash", employee.PasswordHash);  // Ensure password is hashed before insertion
                cmd.Parameters.AddWithValue("@Role", employee.Role);
                cmd.Parameters.AddWithValue("@Email", employee.Email);
                cmd.Parameters.AddWithValue("@PhoneNumber", employee.PhoneNumber);

                cmd.ExecuteNonQuery();
            }
        }
        //Get Employee by ID
        // Read - Get employee by ID
        public Employee GetEmployeeById(int employeeId)
        {
            Employee employee = null;

            using (var connection = _dbContext.GetConnection())
            {
                connection.Open();

                string query = "SELECT * FROM employee WHERE EmployeeID = @EmployeeID";

                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@EmployeeID", employeeId);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        employee = new Employee
                        {
                            EmployeeId = reader.GetInt32("EmployeeID"),
                            FullName = reader.GetString("FullName"),
                            Username = reader.GetString("Username"),
                            Role = reader.GetString("Role"),
                            Email = reader.GetString("Email"),
                            PhoneNumber = reader.GetString("PhoneNumber")
                        };
                    }
                }
            }

            return employee;
        }
        //update Employee
        // Update - Update an employee's information
        public void UpdateEmployee(Employee employee)
        {
            using (var connection = _dbContext.GetConnection())
            {
                connection.Open();

                string query = "UPDATE employee SET FullName = @FullName, Username = @Username, PasswordHash = @PasswordHash, " +
                               "Role = @Role, Email = @Email, PhoneNumber = @PhoneNumber WHERE EmployeeID = @EmployeeID";

                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@EmployeeID", employee.EmployeeId);
                cmd.Parameters.AddWithValue("@FullName", employee.FullName);
                cmd.Parameters.AddWithValue("@Username", employee.Username);
                cmd.Parameters.AddWithValue("@PasswordHash", employee.PasswordHash);  // Ensure password is hashed before update
                cmd.Parameters.AddWithValue("@Role", employee.Role);
                cmd.Parameters.AddWithValue("@Email", employee.Email);
                cmd.Parameters.AddWithValue("@PhoneNumber", employee.PhoneNumber);

                cmd.ExecuteNonQuery();
            }
        }
        //Delete, remove an employee
        // Delete - Remove an employee
        public void DeleteEmployee(int employeeId)
        {
            using (var connection = _dbContext.GetConnection())
            {
                connection.Open();

                string query = "DELETE FROM employee WHERE EmployeeID = @EmployeeID";

                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@EmployeeID", employeeId);

                cmd.ExecuteNonQuery();
            }
        }



    }
}
