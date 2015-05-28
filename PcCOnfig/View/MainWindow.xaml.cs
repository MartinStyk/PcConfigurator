using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading;
using System.Windows;
using PcCOnfig.Model;
using PcCOnfig.Model.Box;
using PcCOnfig.Model.ComputerConfiguration;
using PcCOnfig.ViewModel;

namespace PcCOnfig.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainWindowViewModel();
            SplashScreen splash = new SplashScreen("Resources/icon.png");
            splash.Show(false);
            //Get initial access to database to check connection
            try
            {
                using (var db = new ComponentContext())
                {
                    var res = db.ComputerConfigurations.Cast<ComputerConfiguration>();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Unable to access database. Application will close.", "Confirmation", MessageBoxButton.OK, MessageBoxImage.Error);
                Close();
            }
            splash.Close(new TimeSpan(0,0,1));
        }


    }
}
