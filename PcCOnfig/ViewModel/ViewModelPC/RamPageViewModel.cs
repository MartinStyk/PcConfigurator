using System.Collections.ObjectModel;
using System.Linq;
using PcCOnfig.Model;
using PcCOnfig.Model.ComputerConfiguration;
using PcCOnfig.Model.ram;

namespace PcCOnfig.ViewModel.ViewModelPC
{
    class RamPageViewModel : PcWizardComponentSelectionPageViewModelBase
    {
    
        public RamPageViewModel(ComputerConfiguration configuration)
            : base(configuration)
        {
        }
        public override string DisplayName { get { return "Rams"; } }
        internal override bool IsValid()
        {
            return Configuration.Ram != null;
        }

        protected override void FillDataGrid()
        {
            using (var db = new ComponentContext())
            {
                var query = from Ram r in db.Rams where r.ConnectionType == Configuration.Motherboard.RamConnectionType && !r.IsDeleted select r;
                Data = new ObservableCollection<ComputerComponent>(query);
            }
        }

        protected override void AddComponentToConfiguration()
        {
            if (SelectedItem != null)
            {
                Configuration.Ram = SelectedItem as Ram;
                Configuration.RamId = SelectedItem.Id;
            }
        }
    }
}