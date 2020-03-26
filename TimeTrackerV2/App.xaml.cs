using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using ShowMeTheXAML;

namespace TimeTrackerV2
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        static string databaseName = "TimeTrackerDB.db";
        static string folderPath = AppDomain.CurrentDomain.BaseDirectory;
        public static string databasePath = System.IO.Path.Combine(folderPath, databaseName);

        protected override void OnStartup(StartupEventArgs e)
        {
            //XamlDisplay.Init();
            base.OnStartup(e);

            MainWindow app = new MainWindow();
            MainWindowViewModel context = new MainWindowViewModel();

            app.DataContext = context;
            app.Show();

            app.Closing += context.OnWindowClosing;

        }
    }


}
