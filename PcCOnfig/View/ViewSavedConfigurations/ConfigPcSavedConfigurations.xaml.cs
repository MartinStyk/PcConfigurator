using System.Windows;
using PcCOnfig.ViewModel.ViewModelSavedConfigurations;

namespace PcCOnfig.View.ViewSavedConfigurations
{
    /// <summary>
    /// Interaction logic for ConfigPcSavedConfigurations.xaml
    /// </summary>
    public partial class ConfigPcSavedConfigurations : Window
    {
        public ConfigPcSavedConfigurations()
        {
            InitializeComponent();
            DataContext = new ConfigPcSavedConfigurationsViewModel();
        }
    }
}
