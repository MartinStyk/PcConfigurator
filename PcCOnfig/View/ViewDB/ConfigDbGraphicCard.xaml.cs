using PcCOnfig.ViewModel.ViewModelDB;

namespace PcCOnfig.View.ViewDB
{
    /// <summary>
    /// Interaction logic for ConfigDbRam.xaml
    /// </summary>
    public partial class ConfigDbGraphicCard
    {
        public ConfigDbGraphicCard()
        {
            InitializeComponent();
            DataContext = new GraphicCardDbViewModel();
        }
    }
}
