using PcCOnfig.Model.ComputerConfiguration;

namespace PcCOnfig.ViewModel.ViewModelPC
{
    class WelcomePageViewModel : PcWizardPageViewModelBase
    {
        private string _name;
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
                Configuration.ConfigurationName = _name;
                RaisePropertyChangedEvent("Name");
            }
        }
        private string _info;
        public string Info
        {
            get
            {
                return _info;
            }
            set
            {
                _info = value;
                Configuration.Info = _info;
                RaisePropertyChangedEvent("Info");
            }
        }

        public WelcomePageViewModel(ComputerConfiguration configuration)
            : base(configuration)
        {
        }

        public override string DisplayName
        {
            get { return "Welcome"; }
        }

        internal override bool IsValid()
        {
            return !string.IsNullOrEmpty(Configuration.ConfigurationName);
        }
    }
}