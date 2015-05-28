using System.Windows.Controls;
using PcCOnfig.ViewModel.ViewModelDB;

namespace PcCOnfig.View.ViewDB
{
    /// <summary>
    /// Interaction logic for ConfigDbBox.xaml
    /// </summary>
    public partial class ConfigDbBox : UserControl
    {
        public ConfigDbBox()
        {
            InitializeComponent();
            DataContext = new BoxDbViewModel();
        }
    }
}
