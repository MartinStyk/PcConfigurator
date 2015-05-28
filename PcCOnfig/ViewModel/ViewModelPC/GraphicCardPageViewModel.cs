using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using PcCOnfig.Model;
using PcCOnfig.Model.ComputerConfiguration;
using PcCOnfig.Model.graphics;

namespace PcCOnfig.ViewModel.ViewModelPC
{
    class GraphicCardPageViewModel : PcWizardComponentSelectionPageViewModelBase
    {
     
        public GraphicCardPageViewModel(ComputerConfiguration configuration)
            : base(configuration)
        {
        }
        public override string DisplayName { get { return "Graphic cards"; } }
        internal override bool IsValid()
        {
            return true;
        }

        protected override void FillDataGrid()
        {
            using (var db = new ComponentContext())
            {
                var res = from GraphicCard x in db.GraphicCards where x.ConnectionType == Configuration.Motherboard.GraphicsConnectionType && x.IsDeleted == false select x;
                Data = new ObservableCollection<ComputerComponent>(res);
            }
        }

        protected override void AddComponentToConfiguration()
        {
            if (SelectedItem != null)
            {
                Configuration.GraphicCard = SelectedItem as GraphicCard;
                Configuration.GraphicCardId = SelectedItem.Id;
            }
        }

        public ICommand DeselectCommand
        {
            get { return new DelegateCommand(Deselect); }
        }

        private void Deselect()
        {
            SelectedItem = null;
        }
    }
}