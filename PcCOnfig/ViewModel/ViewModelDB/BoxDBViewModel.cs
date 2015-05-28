using System;
using System.Collections.ObjectModel;
using System.Linq;
using PcCOnfig.Model;
using PcCOnfig.Model.Box;

namespace PcCOnfig.ViewModel.ViewModelDB
{
    class BoxDbViewModel : ConfigDbComponentsCommonPresenter
    {

        #region properties

        private string _mHeight;
        public string Height
        {
            get
            {
                return _mHeight;
            }
            set
            {
                _mHeight = value;
                RaisePropertyChangedEvent("Height");
            }
        }
        private string _mWidth;
        public string Width
        {
            get
            {
                return _mWidth;
            }
            set
            {
                _mWidth = value;
                RaisePropertyChangedEvent("Width");
            }
        }
        private string _mDepth;
        public string Depth
        {
            get
            {
                return _mDepth;
            }
            set
            {
                _mDepth = value;
                RaisePropertyChangedEvent("Depth");
            }
        }


        #endregion Properties

        public BoxDbViewModel()
        {
            using (var db = new ComponentContext())
            {
                var res = db.Boxes.Cast<Box>().Where(x => x.IsDeleted == false);
                Data = new ObservableCollection<ComputerComponent>(res);
            }
        }

        protected override void Add()
        {
            Box b = new Box();

            b.Manufacturer = Manufacturer;
            b.Name = Name;
            b.Info = Info;

            decimal price;
            if (!Decimal.TryParse(Price, out price))
            {
                return;
            }
            b.Price = price;
            decimal height;
            if (!Decimal.TryParse(Height, out height))
            {
                return;
            }
            b.Height = height;

            decimal width;
            if (!Decimal.TryParse(Width, out width))
            {
                return;
            }
            b.Width = width;

            decimal depth;
            if (!Decimal.TryParse(Depth, out depth))
            {
                return;
            }
            b.Depth = depth;

            using (var db = new ComponentContext())
            {
                db.Boxes.Add(b);
                db.SaveChanges();
                Data.Add(b);
            }
            Name = String.Empty;
            Manufacturer = String.Empty;
            Price = String.Empty;
            Info = String.Empty;
            PowerConsumption = String.Empty;
            Width = String.Empty;
            Depth = String.Empty;
            Height = String.Empty;
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

                    case "Info":
                        errorMessage = ValidateÌnfo();
                        break;
                    case "Width":
                        decimal tempW;
                        if (string.IsNullOrEmpty(Width))
                            errorMessage = "Enter width of box";
                        else if (Width.Trim() == string.Empty)
                            errorMessage = "Enter valid number";
                        else if (!Decimal.TryParse(Width, out tempW))
                            errorMessage = "Invalid format, decimal expected";
                        break;
                    case "Height":
                        decimal tempH;
                        if (string.IsNullOrEmpty(Height))
                            errorMessage = "Enter height of box";
                        else if (Height.Trim() == string.Empty)
                            errorMessage = "Enter valid number";
                        else if (!Decimal.TryParse(Height, out tempH))
                            errorMessage = "Invalid format, decimal expected";
                        break;
                    case "Depth":
                        decimal tempD;
                        if (string.IsNullOrEmpty(Depth))
                            errorMessage = "Enter depth of box";
                        else if (Depth.Trim() == string.Empty)
                            errorMessage = "Enter valid number";
                        else if (!Decimal.TryParse(Depth, out tempD))
                            errorMessage = "Invalid format, decimal expected";
                        break;
                }
                return errorMessage;
            }
        }
        #endregion validation
    }
}

