using System.Windows;
using PcCOnfig.ViewModel.ViewModelDB;

namespace PcCOnfig.View.ViewDB
{
    /// <summary>
    /// Interaction logic for ConfigDB.xaml
    /// </summary>
    public partial class ConfigDb : Window
    {
        public ConfigDb()
        {
            InitializeComponent();
            DataContext = new ConfigDbPresenter();
        }

    }
}
