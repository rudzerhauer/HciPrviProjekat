using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System;
using System.Windows;

namespace WpfApp1
{
    public partial class App : Application
    {
        // This method is the entry point for the application
        [STAThread]
        public static void Main()
        {
            var app = new Application();
            var loginWindow = new LoginWindow();
            bool? result = loginWindow.ShowDialog();

            if (result == true)
            {
                var mainWindow = new MainWindow();
                mainWindow.Show();
            }

            app.Run();
        }
    }
}
