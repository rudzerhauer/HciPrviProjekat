using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System;

namespace WpfApp1.Database
{
   public class MySqlDbContext
    {
        private string connectionString = "server=localhost;port=3306;user=root;password=rutgerhauer;database=cafemanagement";

        public MySqlConnection GetConnection() {

            var connection = new MySqlConnection(connectionString);
            return connection;
        }
    }
}
