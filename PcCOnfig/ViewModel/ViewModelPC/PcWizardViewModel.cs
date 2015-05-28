using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Windows.Input;
using PcCOnfig.Model;
using PcCOnfig.Model.ComputerConfiguration;

namespace PcCOnfig.ViewModel.ViewModelPC
{
    public class PcWizardViewModel : ObservableObject
    {

        #region Properties
        DelegateCommand _moveNextCommand;
        DelegateCommand _cancelCommand;
        ComputerConfiguration _configuration;
        PcWizardPageViewModelBase _currentPage;
        ReadOnlyCollection<PcWizardPageViewModelBase> _pages;

        public ComputerConfiguration Configuration
        {
            get { return _configuration; }
        }

        public PcWizardPageViewModelBase CurrentPage
        {
            get { return _currentPage; }
            private set
            {
                if (value == _currentPage)
                    return;

                if (_currentPage != null)
                    _currentPage.IsCurrentPage = false;

                _currentPage = value;

                if (_currentPage != null)
                    _currentPage.IsCurrentPage = true;

                RaisePropertyChangedEvent("CurrentPage");
                RaisePropertyChangedEvent("IsOnLastPage");
            }
        }


        public bool IsOnLastPage
        {
            get { return CurrentPageIndex == Pages.Count - 1; }
        }

        public ReadOnlyCollection<PcWizardPageViewModelBase> Pages
        {
            get
            {
                if (_pages == null)
                    CreatePages();

                return _pages;
            }
        }


        #endregion // Properties


        public PcWizardViewModel()
        {
            CurrentPage = Pages[0];
        }

        #region Commands

        #region CancelCommand

        public ICommand CancelCommand
        {
            get { return _cancelCommand ?? (_cancelCommand = new DelegateCommand(CancelOrder)); }
        }

        void CancelOrder()
        {
            _configuration = null;
            OnRequestClose();
        }

        #endregion // CancelCommand

        #region MoveNextCommand

        public ICommand MoveNextCommand
        {
            get
            {
                return _moveNextCommand ?? (_moveNextCommand = new DelegateCommand(
                    MoveToNextPage));
            }
        }

        bool CanMoveToNextPage
        {
            get { return CurrentPage != null && CurrentPage.IsValid(); }
        }

        void MoveToNextPage()
        {
            if (CanMoveToNextPage)
            {
                if (CurrentPageIndex < Pages.Count - 1)
                    CurrentPage = Pages[CurrentPageIndex + 1];
                else
                {
                    using (var db = new ComponentContext())
                    {
                        db.MotherBoards.Attach(Configuration.Motherboard);
                        db.Boxes.Attach(Configuration.Box);
                        db.Cpus.Attach(Configuration.Cpu);
                        db.HardDrives.Attach(Configuration.Hdd);
                        db.PowerSupplies.Attach(Configuration.PowerSupply);
                        db.Rams.Attach(Configuration.Ram);
                        if (Configuration.GraphicCardId != null)
                        {
                            db.GraphicCards.Attach(Configuration.GraphicCard);
                        }

                        db.ComputerConfigurations.Add(Configuration);
                        db.SaveChanges();
                    }
                    OnRequestClose();
                }

            }
        }

        #endregion // MoveNextCommand

        #endregion // Commands

        public event EventHandler RequestClose;

        void CreatePages()
        {

            _configuration = new ComputerConfiguration();
            var welcomeVm = new WelcomePageViewModel(Configuration);
            var motherboardVm = new MotherboardPageViewModel(Configuration);
            var cpuVm = new CpuPageViewModel(Configuration);
            var ramVm = new RamPageViewModel(Configuration);
            var hddVm = new HddPageViewModel(Configuration);
            var graphicVm = new GraphicCardPageViewModel(Configuration);
            var powerVm = new PowerSupplyPageViewModel(Configuration);
            var boxVm = new BoxPageViewModel(Configuration);
            var finalVm = new FinalPageViewModel(Configuration);
            var pages = new List<PcWizardPageViewModelBase>
            {
                welcomeVm,
                motherboardVm,
                cpuVm,
                ramVm,
                hddVm,
                graphicVm,
                powerVm,
                boxVm,
                finalVm
            };

            _pages = new ReadOnlyCollection<PcWizardPageViewModelBase>(pages);
        }

        int CurrentPageIndex
        {
            get
            {

                if (CurrentPage == null)
                {
                    Debug.Fail("Why is the current page null?");
                }

                return Pages.IndexOf(CurrentPage);
            }
        }

        void OnRequestClose()
        {
            EventHandler handler = RequestClose;
            if (handler != null)
                handler(this, EventArgs.Empty);
        }

    }
}