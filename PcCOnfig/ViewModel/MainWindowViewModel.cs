using System;
using System.IO;
using System.Windows.Input;
using PcCOnfig.View.ViewDB;
using PcCOnfig.View.ViewPC;
using PcCOnfig.View.ViewSavedConfigurations;

namespace PcCOnfig.ViewModel
{
    class MainWindowViewModel : ObservableObject
    {
        public MainWindowViewModel()
        {
            var directoryInfo = Directory.GetParent(Directory.GetCurrentDirectory()).Parent;
            if (directoryInfo != null)
                AppDomain.CurrentDomain.SetData("DataDirectory", directoryInfo.FullName);
        }

        #region Database windows
        public ICommand ShowDbWindow
        {
            get { return new DelegateCommand(ShowDb); }
        }

        private void ShowDb()
        {
            ConfigDb db = new ConfigDb();
            db.Show();
        }
        #endregion

        #region Pc configuration wizard windows
        public ICommand ShowPcWindow
        {
            get { return new DelegateCommand(ShowPc); }
        }

        private void ShowPc()
        {
            var dialog = new PcWizardDialog();
            dialog.ShowDialog();
        }
        #endregion

        #region Configured Pc table
        public ICommand ShowConfiguredWindow
        {
            get { return new DelegateCommand(ShowConfigured); }
        }

        private void ShowConfigured()
        {
            ConfigPcSavedConfigurations savedConfigurations = new ConfigPcSavedConfigurations();
            savedConfigurations.Show();
        }
        #endregion
    }
}
