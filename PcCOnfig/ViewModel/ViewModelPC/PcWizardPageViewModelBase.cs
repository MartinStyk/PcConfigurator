using PcCOnfig.Model.ComputerConfiguration;

namespace PcCOnfig.ViewModel.ViewModelPC
{
    public abstract class PcWizardPageViewModelBase : ObservableObject
    {
        #region Properties

        readonly ComputerConfiguration _configuration;
        bool _isCurrentPage;

        public ComputerConfiguration Configuration
        {
            get { return _configuration; }
        }

        public abstract string DisplayName { get; }

        public bool IsCurrentPage
        {
            get { return _isCurrentPage; }
            set
            {
                if (value == _isCurrentPage)
                    return;

                _isCurrentPage = value;
                RaisePropertyChangedEvent("IsCurrentPage");
            }
        }

        #endregion


        protected PcWizardPageViewModelBase(ComputerConfiguration configuration)
        {
            _configuration = configuration;
        }

        internal abstract bool IsValid();

    }
}