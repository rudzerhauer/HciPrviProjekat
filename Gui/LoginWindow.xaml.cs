using System;
using System.Windows;
using MySql.Data.MySqlClient;
using WpfApp1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfApp1.Database;


namespace WpfApp1
{
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            string username = UsernameTextBox.Text;
            string password = PasswordBox.Password;

            var employee = AuthenticateUser(username, password);
            if (employee != null)
            {
                // Redirect based on role
                NavigateToRoleBasedView(employee);
            }
            else
            {
                MessageBox.Show("Invalid credentials!");
            }
        }

        private Employee AuthenticateUser(string username, string password)
        {
            string connectionString = "server=localhost;port=3306;user=root;password=rutgerhauer;database=cafemanagement"; // Modify with your MySQL connection string
            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM employee WHERE Username = @username AND PasswordHash = @password";
                var command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@username", username);
                command.Parameters.AddWithValue("@password", password); // In a real scenario, hash the password

                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        // Return the Employee object with role information
                        return new Employee
                        {
                            EmployeeId = reader.GetInt32("EmployeeID"),
                            FullName = reader.GetString("FullName"),
                            Role = reader.GetString("Role")
                        };
                    }
                }
            }
            return null; // Return null if the user is not found
        }

        private void NavigateToRoleBasedView(Employee employee)
        {
            if (employee.Role == "Waiter")
            {
                new WaiterWindow().Show();
            }
            else if (employee.Role == "Manager")
            {
                new ManagerWindow().Show();
            }
            else if (employee.Role == "Admin")
            {
                new AdminWindow().Show();
            }
            else
            {
                MessageBox.Show("Unknown role.");
            }

            this.DialogResult = true; // Indicate successful login
            this.Close(); // Close the login window
        }
    }
}
