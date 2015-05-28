using System.Collections.ObjectModel;
using System.Linq;
using PcCOnfig.Model;
using PcCOnfig.Model.Box;
using PcCOnfig.Model.ComputerConfiguration;

namespace PcCOnfig.ViewModel.ViewModelPC
{
    class BoxPageViewModel : PcWizardComponentSelectionPageViewModelBase
    {

        public BoxPageViewModel(ComputerConfiguration configuration)
            : base(configuration)
        {
        }
        public override string DisplayName { get { return "Boxes"; } }
        internal override bool IsValid()
        {
            return Configuration.Box != null;
        }

        protected override void FillDataGrid()
        {
            using (var db = new ComponentContext())
            {
                var res = from Box x in db.Boxes where x.IsDeleted == false select x;
                Data = new ObservableCollection<ComputerComponent>(res);
            }
        }
        protected override void AddComponentToConfiguration()
        {
            if (SelectedItem != null)
            {
                Configuration.Box = SelectedItem as Box;
                Configuration.BoxId = SelectedItem.Id;
            }
        }
    }
}