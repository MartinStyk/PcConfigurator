using PcCOnfig.ViewModel.ViewModelDB;

namespace PcCOnfig.View.ViewDB
{
    /// <summary>
    /// Interaction logic for ConfigDbHdd.xaml
    /// </summary>
    public partial class ConfigDbHdd
    {
        public ConfigDbHdd()
        {
            InitializeComponent();
            DataContext = new HddDbViewModel();
        }
    }
}
