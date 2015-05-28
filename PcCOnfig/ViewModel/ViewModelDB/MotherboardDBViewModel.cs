using System;
using System.Collections.ObjectModel;
using System.Linq;
using PcCOnfig.Model;
using PcCOnfig.Model.cpu;
using PcCOnfig.Model.graphics;
using PcCOnfig.Model.hdd;
using PcCOnfig.Model.Motherboard;
using PcCOnfig.Model.ram;

namespace PcCOnfig.ViewModel.ViewModelDB
{
    class MotherboardDbViewModel : ConfigDbComponentsCommonPresenter
    {

        #region properties

        private string _hdConnection;
        public string HdConnection
        {
            get
            {
                return _hdConnection;
            }
            set
            {
                _hdConnection = value;
                RaisePropertyChangedEvent("HdConnection");
            }
        }
        private string _cpuConnection;
        public string CpuConnection
        {
            get
            {
                return _cpuConnection;
            }
            set
            {
                _cpuConnection = value;
                RaisePropertyChangedEvent("CpuConnection");
            }
        }
        private string _ramConnection;
        public string RamConnection
        {
            get
            {
                return _ramConnection;
            }
            set
            {
                _ramConnection = value;
                RaisePropertyChangedEvent("RamConnection");
            }
        }
        private string _ramConnectionNumber;
        public string RamConnectionNumber
        {
            get
            {
                return _ramConnectionNumber;
            }
            set
            {
                _ramConnectionNumber = value;
                RaisePropertyChangedEvent("RamConnectionNumber");
            }
        }
        private string _graphicConnection;
        public string GraphicConnection
        {
            get
            {
                return _graphicConnection;
            }
            set
            {
                _graphicConnection = value;
                RaisePropertyChangedEvent("GraphicConnection");
            }
        }


        #endregion Properties

        public MotherboardDbViewModel()
        {
            using (var db = new ComponentContext())
            {
                var res = db.MotherBoards.Cast<Motherboard>().Where(x => x.IsDeleted == false);
                Data = new ObservableCollection<ComputerComponent>(res);
            }
        }
        
        protected override void Add()
        {
            Motherboard motherboard = new Motherboard();

            motherboard.Manufacturer = Manufacturer;
            motherboard.Name = Name;
            motherboard.Info = Info;
            motherboard.IsDeleted = false;

            int power;
            if (!Int32.TryParse(PowerConsumption, out power))
            {
                return;
            }
            motherboard.PowerConsumption = power;

            decimal price;
            if (!Decimal.TryParse(Price, out price))
            {
                return;
            }
            motherboard.Price = price;

            int ramSlots;
            if (!Int32.TryParse(RamConnectionNumber, out ramSlots))
            {
                return;
            }
            motherboard.RamConnectionNumber = ramSlots;

            HardDriveConnectionEnum hdConn;
            if (!Enum.TryParse(HdConnection, out hdConn))
            {
                return;
            }
            motherboard.HardDriveConnectionType = hdConn;

            CpuSocketEnum cpuConn;
            if (!Enum.TryParse(CpuConnection, out cpuConn))
            {
                return;
            }
            motherboard.CpuConnectionType = cpuConn;

            RamConnectionEnum ramConn;
            if (!Enum.TryParse(RamConnection, out ramConn))
            {
                return;
            }
            motherboard.RamConnectionType = ramConn;

            GraphicsConnectionEnum graphConn;
            if (!Enum.TryParse(GraphicConnection, out graphConn))
            {
                return;
            }
            motherboard.GraphicsConnectionType = graphConn;

            using (var db = new ComponentContext())
            {
                db.MotherBoards.Add(motherboard);
                db.SaveChanges();
                Data.Add(motherboard);
            }
            Name = String.Empty;
            Manufacturer = String.Empty;
            Price = String.Empty;
            Info = String.Empty;
            PowerConsumption = String.Empty;
            CpuConnection = String.Empty;
            RamConnection = String.Empty;
            GraphicConnection = String.Empty;
            RamConnectionNumber = String.Empty;
            HdConnection = String.Empty;
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

                    case "RamConnectionNumber":
                        if (string.IsNullOrEmpty(RamConnectionNumber))
                            errorMessage = "Enter number of ram slots";
                        else if (RamConnectionNumber.Trim() == string.Empty)
                            errorMessage = "Enter valid  number of ram slots";
                        else
                        {
                            int temp;
                            if (!Int32.TryParse(RamConnectionNumber, out temp))
                                errorMessage = "Invalid number";
                        }
                        break;

                    case "RamConnection":
                        if (string.IsNullOrEmpty(RamConnection))
                            errorMessage = "Enter ram connection type";
                        else if (RamConnection.Trim() == string.Empty)
                            errorMessage = "Enter valid ram connection type";
                        else
                        {
                            RamConnectionEnum tempRam;
                            if (!Enum.TryParse(RamConnection, out tempRam))
                                errorMessage = "Invalid ram connection type";
                        }
                        break;

                    case "CpuConnection":
                        if (string.IsNullOrEmpty(CpuConnection))
                            errorMessage = "Enter cpu connection type";
                        else if (CpuConnection.Trim() == string.Empty)
                            errorMessage = "Enter valid cpu connection type";
                        else
                        {
                            CpuSocketEnum tempCpu;
                            if (!Enum.TryParse(CpuConnection, out tempCpu))
                                errorMessage = "Invalid cpu connection type";
                        }
                        break;
                    case "GraphicConnection":
                        if (string.IsNullOrEmpty(GraphicConnection))
                            errorMessage = "Enter cpu connection type";
                        else if (GraphicConnection.Trim() == string.Empty)
                            errorMessage = "Enter valid graphic connection type";
                        else
                        {
                            GraphicsConnectionEnum tempGraph;
                            if (!Enum.TryParse(GraphicConnection, out tempGraph))
                                errorMessage = "Invalid graphic connection type";
                        }
                        break;


                    case "HdConnection":
                        if (string.IsNullOrEmpty(HdConnection))
                            errorMessage = "Enter hd connection type";
                        else if (HdConnection.Trim() == string.Empty)
                            errorMessage = "Enter valid hd connection type";
                        else
                        {
                            HardDriveConnectionEnum tempHd;
                            if (!Enum.TryParse(HdConnection, out tempHd))
                                errorMessage = "Invalid hd connection type";
                        }
                        break;
                }
                return errorMessage;
            }
        }
        #endregion validation
    }
}

