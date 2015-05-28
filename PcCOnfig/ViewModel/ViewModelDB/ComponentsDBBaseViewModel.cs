using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using PcCOnfig.Model;
using PcCOnfig.Model.Box;
using PcCOnfig.Model.cpu;
using PcCOnfig.Model.graphics;
using PcCOnfig.Model.hdd;
using PcCOnfig.Model.Motherboard;
using PcCOnfig.Model.powersupply;
using PcCOnfig.Model.ram;

namespace PcCOnfig.ViewModel.ViewModelDB
{
    public abstract class ConfigDbComponentsCommonPresenter : ObservableObject, IDataErrorInfo
    {
        #region DeleteCommand
        public ICommand DeleteCommand
        {
            get { return new DelegateCommand(Delete); }
        }
        private void Delete()
        {
            if (SelectedItem == null)
            {
                return;
            }

            using (var db = new ComponentContext())
            {
                ComputerComponent original = null;
                if (SelectedItem.GetType() == typeof(Cpu))
                {
                    original = db.Cpus.Find(SelectedItem.Id);
                }
                else if (SelectedItem.GetType() == typeof(Box))
                {
                    original = db.Boxes.Find(SelectedItem.Id);
                }
                else if (SelectedItem.GetType() == typeof(GraphicCard))
                {
                    original = db.GraphicCards.Find(SelectedItem.Id);
                }
                else if (SelectedItem.GetType() == typeof(Hdd))
                {
                    original = db.HardDrives.Find(SelectedItem.Id);
                }
                else if (SelectedItem.GetType() == typeof(Motherboard))
                {
                    original = db.MotherBoards.Find(SelectedItem.Id);
                }
                else if (SelectedItem.GetType() == typeof(PowerSupply))
                {
                    original = db.PowerSupplies.Find(SelectedItem.Id);
                }
                else if (SelectedItem.GetType() == typeof(Ram))
                {
                    original = db.Rams.Find(SelectedItem.Id);
                }

                if (original == null) return;

                original.IsDeleted = true;
                db.SaveChanges();
                Data.Remove(SelectedItem);
            }
        }
        #endregion

        #region AddCommand
        public ICommand AddCommand
        {
            get { return new DelegateCommand(Add); }
        }

        protected abstract void Add();
        #endregion

        #region shared properties

        private ObservableCollection<ComputerComponent> _data;

        public ObservableCollection<ComputerComponent> Data
        {
            get { return _data; }
            set
            {
                _data = value;
                RaisePropertyChangedEvent("Data");
            }
        }

        private ComputerComponent _selectedItem;

        public ComputerComponent SelectedItem
        {
            get { return _selectedItem; }
            set
            {
                _selectedItem = value;
                RaisePropertyChangedEvent("SelectedItem");
            }
        }

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
                RaisePropertyChangedEvent("Name");
            }
        }
        private string _manufacturer;
        public string Manufacturer
        {
            get
            {
                return _manufacturer;
            }
            set
            {
                _manufacturer = value;
                RaisePropertyChangedEvent("Manufacturer");
            }
        }
        private string _price;
        public string Price
        {
            get
            {
                return _price;
            }
            set
            {
                _price = value;
                RaisePropertyChangedEvent("Price");
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
                RaisePropertyChangedEvent("Info");
            }
        }

        private string _powerConsumption;
        public string PowerConsumption
        {
            get
            {
                return _powerConsumption;
            }
            set
            {
                _powerConsumption = value;
                RaisePropertyChangedEvent("PowerConsumption");
            }
        }
        #endregion Properties

        #region shared validation

        protected string ValidateManufacturer()
        {
            string errorMessage = String.Empty;
            if (string.IsNullOrEmpty(Manufacturer))
                errorMessage = "Enter manufacturer name";
            else if (Manufacturer.Trim() == string.Empty)
                errorMessage = "Enter valid manufacturer name";
            return errorMessage;
        }
        protected string ValidateName()
        {
            string errorMessage = String.Empty;
            if (string.IsNullOrEmpty(Name))
                errorMessage = "Enter name";
            else if (Name.Trim() == string.Empty)
                errorMessage = "Enter valid  name";
            return errorMessage;
        }

        protected string ValidatePrice()
        {
            string errorMessage = String.Empty;
            decimal tempDecimal;
            if (string.IsNullOrEmpty(Price))
                errorMessage = "Enter price";
            else if (Price.Trim() == string.Empty)
                errorMessage = "Enter valid price";
            else if (!Decimal.TryParse(Price, out tempDecimal))
                errorMessage = "Invalid price format";
            return errorMessage;
        }
        protected string ValidatePowerComsumption()
        {
            string errorMessage = String.Empty;
            int temp;
            if (string.IsNullOrEmpty(PowerConsumption))
                errorMessage = "Enter consumption";
            else if (PowerConsumption.Trim() == string.Empty)
                errorMessage = "Enter valid consumption";
            else if (!Int32.TryParse(PowerConsumption, out temp))
                errorMessage = "Invalid format";
            return errorMessage;
        }
        protected string ValidateÌnfo()
        {
            string errorMessage = String.Empty;
            if (string.IsNullOrEmpty(Info))
                errorMessage = "Enter info";
            else if (Info.Trim() == string.Empty)
                errorMessage = "Enter valid  info";
            return errorMessage;
        }

        public string Error
        {
            get { throw new NotImplementedException(); }
        }

        public virtual string this[string columnName]
        {
            get { throw new NotImplementedException(); }
        }
    }
        #endregion validation
}

