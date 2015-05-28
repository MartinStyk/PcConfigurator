using System;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using PcCOnfig.Model;
using PcCOnfig.Model.Box;
using PcCOnfig.Model.cpu;
using PcCOnfig.Model.ComputerConfiguration;
using PcCOnfig.Model.hdd;
using PcCOnfig.Model.Motherboard;
using PcCOnfig.Model.powersupply;
using PcCOnfig.Model.ram;

namespace PcCOnfig.ViewModel.ViewModelSavedConfigurations
{
    class ConfigPcSavedConfigurationsViewModel : ObservableObject
    {
        #region properties
        private ObservableCollection<ComputerConfiguration> _configurations;
        public ObservableCollection<ComputerConfiguration> Configuration
        {
            get
            {
                return _configurations;
            }
            set
            {
                _configurations = value;
                RaisePropertyChangedEvent("Configuration");
            }
        }

        private ComputerConfiguration _selected;
        public ComputerConfiguration Selected
        {
            get
            {
                return _selected;
            }
            set
            {
                _selected = value;
                RaisePropertyChangedEvent("Selected");
                RaisePropertyChangedEvent("SelectedText");
                RaisePropertyChangedEvent("NameText");
                RaisePropertyChangedEvent("MotherboardText");
                RaisePropertyChangedEvent("CpuText");
                RaisePropertyChangedEvent("RamText");
                RaisePropertyChangedEvent("HddText");
                RaisePropertyChangedEvent("PowerSupplyText");
                RaisePropertyChangedEvent("GraphicCardText");
                RaisePropertyChangedEvent("BoxText");
            }
        }
        public string SelectedText
        {
            get
            {
                if (_selected == null)
                    return "Select Configuration and then click to print it";
                else
                    return "Print configuration " + Selected.ConfigurationName;
            }
        }


        #region properties binding
        public string NameText
        {
            get
            {
                return Selected != null ? Selected.ConfigurationName : String.Empty;
            }
        }

        public string MotherboardText
        {
            get
            {
                if (Selected != null)
                {
                    Motherboard x = Selected.GetMotherboard();
                    return x.Manufacturer + " " + x.Name;
                }
                else
                {
                    return String.Empty;
                }
            }
        }
        public string CpuText
        {
            get
            {
                if (Selected != null)
                {
                    Cpu x = Selected.GetCpu();
                    return x.Manufacturer + " " + x.Name + " [" + x.Frequency + "GHz]" + " [" + x.NumberOfCores + " cores]";
                }
                else
                {
                    return String.Empty;
                }
            }
        }
        public string RamText
        {
            get
            {
                if (Selected != null)
                {
                    Ram x = Selected.GetRam();
                    return x.Manufacturer + " " + x.Name + " [" + x.Capacity + " GB]";
                }
                else
                {
                    return String.Empty;
                }
            }
        }
        public string HddText
        {
            get
            {
                if (Selected != null)
                {
                    Hdd x = Selected.GetHdd();
                    return x.Manufacturer + " " + x.Name + " [" + x.Capacity + " GB]";
                }
                else
                {
                    return String.Empty;
                }
            }
        }
        public string PowerSupplyText
        {
            get
            {
                if (Selected != null)
                {
                    PowerSupply x = Selected.GetPowerSupply();
                    return x.Manufacturer + " " + x.Name;
                }
                else
                {
                    return String.Empty;
                }
            }
        }
        public string GraphicCardText
        {
            get
            {
                 if (Selected != null && Selected.GraphicCardId != null)
                {
                    Ram x = Selected.GetRam();
                    return x.Manufacturer + " " + x.Name + " [" + x.Capacity + " GB]";
                }
                else
                {
                    return String.Empty;
                }

            }
        }
        public string BoxText
        {
            get
            {
                if (Selected != null)
                {
                    Box x = Selected.GetBox();
                    return x.Manufacturer + " " + x.Name;
                }
                else
                {
                    return String.Empty;
                }
            }
        }
        #endregion

        #endregion

        public ConfigPcSavedConfigurationsViewModel()
        {
            using (var db = new ComponentContext())
            {
                Configuration = new ObservableCollection<ComputerConfiguration>(db.ComputerConfigurations);
            }
        }
        #region Print Command
        public ICommand Print
        {
            get { return new DelegateCommand(DoPrint); }
        }

        private void DoPrint()
        {
            if (Selected == null)
            {
                return;
            }
            // Create the print dialog object and set options
            PrintDialog pDialog = new PrintDialog
            {
                PageRangeSelection = PageRangeSelection.AllPages,
                UserPageRangeEnabled = true
            };

            bool? print = pDialog.ShowDialog();
            if (print == true)
            {
                PrintDocument p = new PrintDocument(Selected);
                FlowDocument doc = p.CreateFlowDocument();
                doc.Name = "FlowDoc";

                IDocumentPaginatorSource idpSource = doc;

                pDialog.PrintDocument(idpSource.DocumentPaginator, "Hello WPF Printing.");
            }
        }
        #endregion
        #region Delete Command
        public ICommand Delete
        {
            get { return new DelegateCommand(DoDelete); }
        }

        private void DoDelete()
        {
            if (Selected == null)
            {
                return;
            }
            using (var db = new ComponentContext())
            {
                db.ComputerConfigurations.Attach(Selected);
                db.ComputerConfigurations.Remove(Selected);
                db.SaveChanges();
            }
            Configuration.Remove(Selected);
        }
        #endregion
    }
}

