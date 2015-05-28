using System.Collections.ObjectModel;
using System.Linq;
using PcCOnfig.Model;
using PcCOnfig.Model.ComputerConfiguration;
using PcCOnfig.Model.powersupply;

namespace PcCOnfig.ViewModel.ViewModelPC
{
    class PowerSupplyPageViewModel : PcWizardComponentSelectionPageViewModelBase
    {
        public PowerSupplyPageViewModel(ComputerConfiguration configuration)
            : base(configuration)
        {
        }
        public override string DisplayName { get { return "Power Supplies"; } }
        internal override bool IsValid()
        {
            return Configuration.PowerSupply != null;
        }

        protected override void FillDataGrid()
        {
            int consumption = GetTotalPowerConsumption();
            using (var db = new ComponentContext())
            {
                var res = from PowerSupply x in db.PowerSupplies where x.MaximumPower >= consumption && !x.IsDeleted select x;
                Data = new ObservableCollection<ComputerComponent>(res);
            }
        }

        protected override void AddComponentToConfiguration()
        {
            if (SelectedItem != null)
            {
                Configuration.PowerSupply = SelectedItem as PowerSupply;
                Configuration.PowerSupplyId = SelectedItem.Id;
            }
        }
        private int GetTotalPowerConsumption()
        {
            var total = Configuration.Cpu.PowerConsumption +
                    Configuration.Ram.PowerConsumption +
                    Configuration.Hdd.PowerConsumption +
                    Configuration.Motherboard.PowerConsumption;
            if (Configuration.GraphicCard != null) total += Configuration.GraphicCard.PowerConsumption;
            return total;
        }
    }
}