using PcCOnfig.ViewModel.ViewModelDB;

namespace PcCOnfig.View.ViewDB
{
    /// <summary>
    /// Interaction logic for ConfigDbRam.xaml
    /// </summary>
    public partial class ConfigDbRam 
    {
        public ConfigDbRam()
        {
            InitializeComponent();
            DataContext = new RamDbViewModel();
        }
    }
}
