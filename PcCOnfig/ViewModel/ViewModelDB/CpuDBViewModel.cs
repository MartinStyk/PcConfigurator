using System;
using System.Collections.ObjectModel;
using System.Linq;
using PcCOnfig.Model;
using PcCOnfig.Model.cpu;

namespace PcCOnfig.ViewModel.ViewModelDB
{
    internal class CpuDbViewModel : ConfigDbComponentsCommonPresenter
    {
        #region properties

        private string _numberOfCores;

        public string NumberOfCores
        {
            get { return _numberOfCores; }
            set
            {
                _numberOfCores = value;
                RaisePropertyChangedEvent("NumberOfCores");
            }
        }

        private string _architecture;

        public string Architecture
        {
            get { return _architecture; }
            set
            {
                _architecture = value;
                RaisePropertyChangedEvent("Architecture");
            }
        }

        private string _frequency;

        public string Frequency
        {
            get { return _frequency; }
            set
            {
                _frequency = value;
                RaisePropertyChangedEvent("Frequency");
            }
        }

        private string _socket;

        public string Socket
        {
            get { return _socket; }
            set
            {
                _socket = value;
                RaisePropertyChangedEvent("Socket");
            }
        }

        #endregion Properties
        public CpuDbViewModel()
        {
            using (var db = new ComponentContext())
            {
                var res = from Cpu x in db.Cpus where x.IsDeleted == false select x;
                Data = new ObservableCollection<ComputerComponent>(res);
            }
        }
        protected override void Add()
        {
            var cpu = new Cpu();

            cpu.Manufacturer = Manufacturer;
            cpu.Name = Name;
            cpu.Info = Info;

            int numCores;
            if (!Int32.TryParse(NumberOfCores, out numCores))
            {
                return;
            }

            cpu.NumberOfCores = numCores;

            int powCons;
            if (!Int32.TryParse(PowerConsumption, out powCons))
            {
                return;
            }
            cpu.PowerConsumption = powCons;

            decimal price;
            if (!Decimal.TryParse(Price, out price))
            {
                return;
            }
            cpu.Price = price;

            decimal freq;
            if (!Decimal.TryParse(Frequency, out freq))
            {
                return;
            }
            cpu.Frequency = freq;

            CpuSocketEnum socket;
            if (!Enum.TryParse(Socket, out socket))
            {
                return;
            }
            cpu.Socket = socket;

            ArchitectureEnum arch;
            if (!Enum.TryParse(Architecture, out arch))
            {
                return;
            }

            using (var db = new ComponentContext())
            {
                db.Cpus.Add(cpu);
                db.SaveChanges();

                Data.Add(cpu);
            }
            Name = String.Empty;
            Manufacturer = String.Empty;
            Price = String.Empty;
            NumberOfCores = String.Empty;
            Architecture = String.Empty;
            Frequency = String.Empty;
            Info = String.Empty;
            Socket = String.Empty;
            PowerConsumption = String.Empty;
        }

        #region validation

        public override string this[string columnName]
        {
            get
            {
                var errorMessage = string.Empty;

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

                    case "NumberOfCores":
                        if (string.IsNullOrEmpty(NumberOfCores))
                            errorMessage = "Enter number of cores";
                        else if (NumberOfCores.Trim() == string.Empty)
                            errorMessage = "Enter valid number";
                        else
                        {
                            int tempInt;
                            if (!Int32.TryParse(NumberOfCores, out tempInt))
                                errorMessage = "Invalid price format, integer expected";
                        }
                        break;

                    case "Frequency":
                        if (string.IsNullOrEmpty(Frequency))
                            errorMessage = "Enter frequency";
                        else if (Frequency.Trim() == string.Empty)
                            errorMessage = "Enter valid number";
                        else
                        {
                            decimal tempDecimal;
                            if (!Decimal.TryParse(Frequency, out tempDecimal))
                                errorMessage = "Invalid frequency format, decimal expected";
                        }
                        break;

                    case "PowerConsumption":
                        errorMessage = ValidatePowerComsumption();
                        break;

                    case "Info":
                        errorMessage = ValidateÌnfo();
                        break;

                    case "Socket":
                        if (string.IsNullOrEmpty(Socket))
                            errorMessage = "Enter socket";
                        else if (Socket.Trim() == string.Empty)
                            errorMessage = "Enter valid socket";
                        else
                        {
                            CpuSocketEnum tempSocket;
                            if (!Enum.TryParse(Socket, out tempSocket))
                                errorMessage = "Invalid socket";
                        }
                        break;
                    case "Architecture":
                        if (string.IsNullOrEmpty(Architecture))
                            errorMessage = "Enter architecture";
                        else if (Architecture.Trim() == string.Empty)
                            errorMessage = "Enter valid architecture";
                        else
                        {
                            ArchitectureEnum tempArchitecture;
                            if (!Enum.TryParse(Architecture, out tempArchitecture))
                                errorMessage = "Invalid architecture";
                        }
                        break;
                }
                return errorMessage;
            }
        }

        #endregion validation
    }
}