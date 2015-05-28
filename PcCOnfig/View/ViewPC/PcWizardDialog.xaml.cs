using System;
using System.Windows;
using PcCOnfig.Model.ComputerConfiguration;
using PcCOnfig.ViewModel.ViewModelPC;

namespace PcCOnfig.View.ViewPC
{
    /// <summary>
    /// Interaction logic for PcWizardDialog.xaml
    /// </summary>
    public partial class PcWizardDialog : Window
    {

        readonly PcWizardViewModel _pcWizardViewModel;
        public PcWizardDialog()
        {
            InitializeComponent();
            _pcWizardViewModel = new PcWizardViewModel();
            _pcWizardViewModel.RequestClose += OnViewModelRequestClose;
            DataContext = _pcWizardViewModel;        
        }
        public ComputerConfiguration Result
        {
            get { return _pcWizardViewModel.Configuration; }
        }

        void OnViewModelRequestClose(object sender, EventArgs e)
        {
            DialogResult = Result != null;
        }
    }
}
