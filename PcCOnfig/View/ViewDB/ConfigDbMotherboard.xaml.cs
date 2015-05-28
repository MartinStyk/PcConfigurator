using System.Windows.Controls;
using PcCOnfig.ViewModel.ViewModelDB;

namespace PcCOnfig.View.ViewDB
{
    /// <summary>
    /// Interaction logic for ConfigDbMotherboard.xaml
    /// </summary>
    public partial class ConfigDbMotherboard : UserControl
    {
        public ConfigDbMotherboard()
        {
            InitializeComponent();
            DataContext = new MotherboardDbViewModel();
        }
    }
}
