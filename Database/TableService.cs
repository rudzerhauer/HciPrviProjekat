using System;
using System.Collections.Generic;
using System.Windows;
using MySql.Data.MySqlClient;
using WpfApp1.Models;

namespace WpfApp1.Database
{
    public class TableService
    {
        private MySqlDbContext _dbContext;

        public TableService()
        {
            _dbContext = new MySqlDbContext();
        }

        // Fetch all tables from the database
        public List<CafeTable> GetAllTables()
        {
            List<CafeTable> tables = new List<CafeTable>();

            string query = "SELECT * FROM cafe_table";

            using (var connection = _dbContext.GetConnection())
            {
                connection.Open();
                var command = new MySqlCommand(query, connection);
                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    CafeTable table = new CafeTable
                    {
                        TableID = reader.GetInt32("TableID"),
                        Capacity = reader.GetInt32("Capacity"),
                        IsOccupied = reader.GetBoolean("IsOccupied")
                    };
                    tables.Add(table);
                }
            }

            MessageBox.Show($"Retrieved {tables.Count} tables from the database.");
            return tables;
        }


        // Update the table's status (occupied or free) in the database
        public void UpdateTableStatusInDatabase(CafeTable table)
        {
            string query = "UPDATE cafe_table SET IsOccupied = @IsOccupied WHERE TableID = @TableID";

            using (var connection = _dbContext.GetConnection())
            {
                connection.Open();
                var command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@IsOccupied", table.IsOccupied);
                command.Parameters.AddWithValue("@TableID", table.TableID);
                command.ExecuteNonQuery();
            }
        }

    }
}
