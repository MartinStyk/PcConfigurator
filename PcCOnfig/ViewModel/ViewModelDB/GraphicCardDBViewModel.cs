
   using System;
   using System.Collections.ObjectModel;
   using System.Linq;
   using PcCOnfig.Model;
   using PcCOnfig.Model.graphics;

namespace PcCOnfig.ViewModel.ViewModelDB
{
     class GraphicCardDbViewModel : ConfigDbComponentsCommonPresenter
    {

        #region properties
     
        private string _connectionType;
        public string ConnectionType
        {
            get
            {
                return _connectionType;
            }
            set
            {
                _connectionType = value;
                RaisePropertyChangedEvent("ConnectionType");
            }
        }
        private string _capacity;
        public string Capacity
        {
            get
            {
                return _capacity;
            }
            set
            {
                _capacity = value;
                RaisePropertyChangedEvent("Capacity");
            }
        }
       
        #endregion Properties

        public GraphicCardDbViewModel()
        {
            using (var db = new ComponentContext())
            {
                var res = db.GraphicCards.Cast<GraphicCard>().Where(x => x.IsDeleted == false);
                Data = new ObservableCollection<ComputerComponent>(res);
            }
        }
       
        protected override void Add()
        {
            GraphicCard card = new GraphicCard();

            card.Manufacturer = Manufacturer;
            card.Name = Name;
            card.Info = Info;

            int powCons;
            if (!Int32.TryParse(PowerConsumption, out powCons))
            {
                return;
            }
            card.PowerConsumption = powCons;

            double cap;
            if (!Double.TryParse(Capacity, out cap))
            {
                return;
            }
            card.Capacity = cap;

            decimal price;
            if (!Decimal.TryParse(Price, out price))
            {
                return;
            }
            card.Price = price;

            GraphicsConnectionEnum connection;
            if (!Enum.TryParse(ConnectionType, out connection))
            {
                return;
            }
            card.ConnectionType = connection;

            using (var db = new ComponentContext())
            {
                db.GraphicCards.Add(card);
                db.SaveChanges();
                Data.Add(card);
            }
            Name = String.Empty;
            Manufacturer = String.Empty;
            Capacity = String.Empty;
            Price = String.Empty;
            Info = String.Empty;
            ConnectionType = String.Empty;
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

                    case "ConnectionType":
                        if (string.IsNullOrEmpty(ConnectionType))
                            errorMessage = "Enter socket";
                        else if (ConnectionType.Trim() == string.Empty)
                            errorMessage = "Enter valid socket";
                        else
                        {
                            GraphicsConnectionEnum tempConn;
                            if (!Enum.TryParse(ConnectionType, out tempConn))
                                errorMessage = "Invalid connection type";
                        }
                        break;
                    case "Capacity":
                        if (string.IsNullOrEmpty(Capacity))
                            errorMessage = "Enter capacity";
                        else if (Capacity.Trim() == string.Empty)
                            errorMessage = "Enter valid capacity";
                        else
                        {
                            double tempCapacity;
                            if (!Double.TryParse(Capacity, out tempCapacity))
                                errorMessage = "Invalid number format";
                        }
                        break;
                    
                }
                return errorMessage;
            }
        }
        #endregion validation
    }
}


