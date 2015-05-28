using System.Collections.ObjectModel;
using System.Linq;
using PcCOnfig.Model;
using PcCOnfig.Model.ComputerConfiguration;
using PcCOnfig.Model.hdd;

namespace PcCOnfig.ViewModel.ViewModelPC
{
    class HddPageViewModel : PcWizardComponentSelectionPageViewModelBase
    {
    
        public HddPageViewModel(ComputerConfiguration configuration)
            : base(configuration)
        {
        }
        public override string DisplayName { get { return "Hard Drives"; } }
        internal override bool IsValid()
        {
            return Configuration.Hdd != null;
        }

        protected override void FillDataGrid()
        {
            using (var db = new ComponentContext())
            {
                var query = from Hdd r in db.HardDrives where r.ConnectionType == Configuration.Motherboard.HardDriveConnectionType && r.IsDeleted == false select r;
                Data = new ObservableCollection<ComputerComponent>(query);
            }
        }

        protected override void AddComponentToConfiguration()
        {
            if (SelectedItem != null)
            {
                Configuration.Hdd = SelectedItem as Hdd;
                Configuration.HddId = SelectedItem.Id;
            }
        }
    }
}