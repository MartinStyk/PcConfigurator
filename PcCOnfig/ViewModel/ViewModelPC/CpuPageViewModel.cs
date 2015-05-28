using System.Collections.ObjectModel;
using System.Linq;
using PcCOnfig.Model;
using PcCOnfig.Model.cpu;
using PcCOnfig.Model.ComputerConfiguration;

namespace PcCOnfig.ViewModel.ViewModelPC
{
    class CpuPageViewModel : PcWizardComponentSelectionPageViewModelBase
    {

        public CpuPageViewModel(ComputerConfiguration configuration)
            : base(configuration)
        {
        }
        public override string DisplayName { get { return "Cpus"; } }
        internal override bool IsValid()
        {
            return Configuration.Cpu != null;
        }

        protected override void FillDataGrid()
        {
            using (var db = new ComponentContext())
            {
                var res = from Cpu x in db.Cpus where (x.Socket == Configuration.Motherboard.CpuConnectionType) && (x.IsDeleted == false) select x;
                Data = new ObservableCollection<ComputerComponent>(res);
            }
        }

        protected override void AddComponentToConfiguration()
        {
            if (SelectedItem != null)
            {
                Configuration.Cpu = SelectedItem as Cpu;
                Configuration.CpuId = SelectedItem.Id;
            }
        }
    }
}
