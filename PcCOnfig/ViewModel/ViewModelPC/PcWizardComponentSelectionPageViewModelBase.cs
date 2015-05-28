using System.Collections.ObjectModel;
using PcCOnfig.Model;
using PcCOnfig.Model.ComputerConfiguration;

namespace PcCOnfig.ViewModel.ViewModelPC
{
    public abstract class PcWizardComponentSelectionPageViewModelBase : PcWizardPageViewModelBase
    {
        private ComputerComponent _selectedItem;

        public ComputerComponent SelectedItem
        {
            get { return _selectedItem; }
            set
            {
                _selectedItem = value;
                RaisePropertyChangedEvent("SelectedItem");
                AddComponentToConfiguration();
            }
        }
        private ObservableCollection<ComputerComponent> _data;
        public ObservableCollection<ComputerComponent> Data
        {
            set { _data = value; RaisePropertyChangedEvent("Data"); }
            get
            {
                if (_data == null)
                {
                    FillDataGrid();
                }
                return _data;
            }
        }

        protected PcWizardComponentSelectionPageViewModelBase(ComputerConfiguration configuration)
            : base(configuration)
        {
        }
        protected abstract void FillDataGrid();
        protected abstract void AddComponentToConfiguration();
    }
}
