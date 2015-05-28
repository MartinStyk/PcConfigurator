using System.Collections.ObjectModel;
using System.Linq;
using PcCOnfig.Model;
using PcCOnfig.Model.ComputerConfiguration;
using PcCOnfig.Model.Motherboard;

namespace PcCOnfig.ViewModel.ViewModelPC
{
    class MotherboardPageViewModel : PcWizardComponentSelectionPageViewModelBase
    {

        public MotherboardPageViewModel(ComputerConfiguration configuration)
            : base(configuration)
        {
        }
        public override string DisplayName { get { return "Motherboards"; } }
        internal override bool IsValid()
        {
            return Configuration.Motherboard != null;
        }

        protected override void FillDataGrid()
        {
            using (var db = new ComponentContext())
            {
                var res = from Motherboard x in db.MotherBoards where x.IsDeleted == false select x;
                Data = new ObservableCollection<ComputerComponent>(res);
            }
        }

        protected override void AddComponentToConfiguration()
        {
            if (SelectedItem != null)
            {
                Configuration.Motherboard = SelectedItem as Motherboard;
                Configuration.MotherboardId = SelectedItem.Id;
            }
        }
    }
}
