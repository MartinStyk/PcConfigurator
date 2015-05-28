using System;
using System.Collections.ObjectModel;
using System.Linq;
using PcCOnfig.Model;
using PcCOnfig.Model.powersupply;

namespace PcCOnfig.ViewModel.ViewModelDB
{
    class PowerSupplyDbViewModel : ConfigDbComponentsCommonPresenter
    {

        public PowerSupplyDbViewModel()
        {
            using (var db = new ComponentContext())
            {
                var res = db.PowerSupplies.Cast<PowerSupply>().Where(x => x.IsDeleted == false);
                Data = new ObservableCollection<ComputerComponent>(res);
            }
        }
       
        protected override void Add()
        {
            PowerSupply supply = new PowerSupply();

            supply.Manufacturer = Manufacturer;
            supply.Name = Name;
            supply.Info = Info;

            int power;
            if (!Int32.TryParse(PowerConsumption, out power))
            {
                return;
            }
            supply.MaximumPower = power;

            decimal price;
            if (!Decimal.TryParse(Price, out price))
            {
                return;
            }
            supply.Price = price;

            using (var db = new ComponentContext())
            {
                db.PowerSupplies.Add(supply);
                db.SaveChanges();
                Data.Add(supply);
            }
            Name = String.Empty;
            Manufacturer = String.Empty;
            Price = String.Empty;
            Info = String.Empty;
            PowerConsumption = String.Empty;
        }
       
        #region validation

        public override string this[string columnName]
        {
            get
            {
                string errorMessage = string.Empty;

                switch (columnName)
                {
                    case "Manufacturer":
                        errorMessage = ValidateManufacturer();
                        break;

                    case "Name":
                        errorMessage = ValidateName();
                        break;

                    case "Price":
                        errorMessage = ValidatePrice();
                        break;

                    case "PowerConsumption":
                        errorMessage = ValidatePowerComsumption();
                        break;

                    case "Info":
                        errorMessage = ValidateÌnfo();
                        break;
                }
                return errorMessage;
            }
        }
        #endregion validation
    }
}

