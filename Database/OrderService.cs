using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MySql.Data.MySqlClient;
using System;
using  WpfApp1.Models;

namespace WpfApp1.Database
{
    public class OrderService
    {
        private MySqlDbContext _dbContext;

        public OrderService()
        {
            _dbContext = new MySqlDbContext();
        }

        public void CreateOrder(Order order)
        {
            using (var connection = _dbContext.GetConnection())
            {
                connection.Open();

                string query = "INSERT INTO `order` (OrderDate, TableID, EmployeeID, IsClosed, TotalPrice) VALUES (@OrderDate, @TableID, @EmployeeID, @IsClosed, @TotalPrice)";

                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@OrderDate", order.OrderDate);
                cmd.Parameters.AddWithValue("@TableID", order.TableID);
                cmd.Parameters.AddWithValue("@EmployeeID", order.EmployeeID);
                cmd.Parameters.AddWithValue("@IsClosed", order.IsClosed);
                cmd.Parameters.AddWithValue("@TotalPrice", order.TotalPrice);

                cmd.ExecuteNonQuery();
            }
        }
    }
}

