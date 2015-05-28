using PcCOnfig.ViewModel.ViewModelDB;

namespace PcCOnfig.View.ViewDB
{
    /// <summary>
    /// Interaction logic for ConfigDbPowerSuply.xaml
    /// </summary>
    public partial class ConfigDbPowerSuply
    {
        public ConfigDbPowerSuply()
        {
            InitializeComponent();
            DataContext = new PowerSupplyDbViewModel();
        }
    }
}
