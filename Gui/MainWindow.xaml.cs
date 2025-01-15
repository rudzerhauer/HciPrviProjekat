using System;
using System.Collections.Generic;
using System.Windows;
using WpfApp1.Models;
using WpfApp1.Database;
using MySql.Data.MySqlClient;
using System.Windows.Controls;
using System.Windows.Media;

namespace WpfApp1
{
    public partial class MainWindow : Window
    {
        private TableService _tableService;

        public MainWindow()
        {
            InitializeComponent();
            _tableService = new TableService();  // Initialize the TableService to interact with the database

            // Load tables when the window is initialized
            LoadTables();
        }

        // Load the tables from the database
        private void LoadTables()
        {
            List<CafeTable> tables = _tableService.GetAllTables();
            TablesGrid.Children.Clear();
            // Dynamically create buttons for each table and bind them to the Grid (UI)
            foreach (var table in tables)
            {
                Console.WriteLine(table);
                Button tableButton = new Button
                {
                    Content = $"Table {table.TableID}",
                    Height = 50,
                    Width = 100,
                    Background = table.IsOccupied ? Brushes.Red : Brushes.Green,
                    Margin = new Thickness(10)
                };
                tableButton.Click += (sender, e) => TableButton_Click(sender, e, table);  // Associate the table with its button
                TablesGrid.Children.Add(tableButton);  // Add the button to the grid
            }
        }

        // Button click event for toggling the table's occupied status
        private void TableButton_Click(object sender, RoutedEventArgs e, CafeTable table)
        {
            // Toggle the table's occupancy
            table.IsOccupied = !table.IsOccupied;

            // Update the table status in the database
            _tableService.UpdateTableStatusInDatabase(table);

            // Update the button color based on the new status
            Button clickedButton = sender as Button;
            clickedButton.Background = table.IsOccupied ? Brushes.Red : Brushes.Green;
        }
    }
}
