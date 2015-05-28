using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using PcCOnfig.View.ViewDB;

namespace PcCOnfig.ViewModel.ViewModelDB
{
    class ConfigDbPresenter : ObservableObject
    {
        private static readonly Color SelectedColor = Colors.LightBlue;
        public ConfigDbPresenter()
        {
            CurrentView = null;
        }

        private UserControl _currentView;
        public UserControl CurrentView
        {
            get
            {
                return _currentView;
            }
            set
            {
                if (value != null && !value.Equals(_currentView))
                {
                    _currentView = value;
                    RaisePropertyChangedEvent("CurrentView");
                }
            }
        }
        private readonly List<SolidColorBrush> _tempColorBrushes = new List<SolidColorBrush>(7)
        {
            new SolidColorBrush(Colors.Transparent),
            new SolidColorBrush(Colors.Transparent),
            new SolidColorBrush(Colors.Transparent),
            new SolidColorBrush(Colors.Transparent),
            new SolidColorBrush(Colors.Transparent),
            new SolidColorBrush(Colors.Transparent),
            new SolidColorBrush(Colors.Transparent),
        };

        private  List<SolidColorBrush> _btnColorBrushes;
        public List<SolidColorBrush> BtnColorBrushes
        {
            get { return _btnColorBrushes; }
        }

        #region cpu
        public ICommand ShowCpuView
        {
            get { return new DelegateCommand(ShowCpu); }
        }

        private void ShowCpu()
        {
            if (CurrentView == null || CurrentView.GetType() != typeof(ConfigDbCpu))
            {
                CurrentView = new ConfigDbCpu();
               _btnColorBrushes= new List<SolidColorBrush>(_tempColorBrushes);
               _btnColorBrushes[0] = new SolidColorBrush(SelectedColor);
                RaisePropertyChangedEvent("BtnColorBrushes");
            }
        }
        #endregion

        #region ram
        public ICommand ShowRamView
        {
            get { return new DelegateCommand(ShowRam); }
        }

        private void ShowRam()
        {
            if (CurrentView == null || CurrentView.GetType() != typeof(ConfigDbRam))
            {
                CurrentView = new ConfigDbRam();
                _btnColorBrushes = new List<SolidColorBrush>(_tempColorBrushes);
                _btnColorBrushes[1] = new SolidColorBrush(SelectedColor);
                RaisePropertyChangedEvent("BtnColorBrushes");
            }
        }

        #endregion

        #region hdd
        public ICommand ShowHddView
        {
            get { return new DelegateCommand(ShowHdd); }
        }

        private void ShowHdd()
        {
            if (CurrentView == null || CurrentView.GetType() != typeof(ConfigDbHdd))
            {

                CurrentView = new ConfigDbHdd();
                _btnColorBrushes = new List<SolidColorBrush>(_tempColorBrushes);
                _btnColorBrushes[3] = new SolidColorBrush(SelectedColor);
                RaisePropertyChangedEvent("BtnColorBrushes");
            }
        }

        #endregion

        #region power
        public ICommand ShowPowerSuppliesView
        {
            get { return new DelegateCommand(ShowPowerSupply); }
        }

        private void ShowPowerSupply()
        {
            if (CurrentView == null || CurrentView.GetType() != typeof(ConfigDbPowerSuply))
            {
                CurrentView = new ConfigDbPowerSuply();
                _btnColorBrushes = new List<SolidColorBrush>(_tempColorBrushes);
                _btnColorBrushes[4] = new SolidColorBrush(SelectedColor);
                RaisePropertyChangedEvent("BtnColorBrushes");
            }
        }

        #endregion

        #region motherboard
        public ICommand ShowMotherboardView
        {
            get { return new DelegateCommand(ShowMotherboard); }
        }

        private void ShowMotherboard()
        {
            if (CurrentView == null || CurrentView.GetType() != typeof(ConfigDbMotherboard))
            {
                CurrentView = new ConfigDbMotherboard();
                _btnColorBrushes = new List<SolidColorBrush>(_tempColorBrushes);
                _btnColorBrushes[2] = new SolidColorBrush(SelectedColor);
                RaisePropertyChangedEvent("BtnColorBrushes");
            }
        }
        #endregion

        #region graphic
        public ICommand ShowGraphicCardView
        {
            get { return new DelegateCommand(ShowGraphicCard); }
        }

        private void ShowGraphicCard()
        {
            if (CurrentView == null || CurrentView.GetType() != typeof(ConfigDbGraphicCard))
            {
                CurrentView = new ConfigDbGraphicCard();
                _btnColorBrushes = new List<SolidColorBrush>(_tempColorBrushes);
                _btnColorBrushes[5] = new SolidColorBrush(SelectedColor);
                RaisePropertyChangedEvent("BtnColorBrushes");
            }
        }
        #endregion

        #region box
        public ICommand ShowBoxView
        {
            get { return new DelegateCommand(ShowBox); }
        }

        private void ShowBox()
        {
            if (CurrentView == null || CurrentView.GetType() != typeof(ConfigDbBox))
            {
                CurrentView = new ConfigDbBox();
                _btnColorBrushes = new List<SolidColorBrush>(_tempColorBrushes);
                _btnColorBrushes[6] = new SolidColorBrush(SelectedColor);
                RaisePropertyChangedEvent("BtnColorBrushes");
            }
        }
        #endregion

    }
}
