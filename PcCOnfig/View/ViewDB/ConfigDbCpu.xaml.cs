using PcCOnfig.ViewModel.ViewModelDB;

namespace PcCOnfig.View.ViewDB
{
    /// <summary>
    /// Interaction logic for ConfigDbCpu.xaml
    /// </summary>
    public partial class ConfigDbCpu 
    {
        public ConfigDbCpu()
        {
            InitializeComponent();
            DataContext = new CpuDbViewModel();
        }
    }
}
