using PcCOnfig.Model.ComputerConfiguration;

namespace PcCOnfig.ViewModel.ViewModelPC
{
    class FinalPageViewModel : PcWizardPageViewModelBase
    {
        #region properties
        public string NameText
        {
            get
            {
                return Configuration.ConfigurationName;
            }
        }

        public string MotherboardText
        {
            get
            {
                return Configuration.Motherboard.Manufacturer + " " + Configuration.Motherboard.Name;
            }
        }
        public string CpuText
        {
            get
            {
                return Configuration.Cpu.Manufacturer + " " + Configuration.Cpu.Name;
            }
        }
        public string RamText
        {
            get
            {
                return Configuration.Ram.Manufacturer + " " + Configuration.Ram.Name + "[" + Configuration.Ram.Capacity + " GB]";
            }
        }
        public string HddText
        {
            get
            {
                return Configuration.Hdd.Manufacturer + " " + Configuration.Hdd.Name + "[" + Configuration.Hdd.Capacity + " GB]";
            }
        }
        public string PowerSupplyText
        {
            get
            {
                return Configuration.PowerSupply.Manufacturer + " " + Configuration.PowerSupply.Name;
            }
        }
        public string GraphicCardText
        {
            get
            {
                if (Configuration.PowerSupply == null)
                {
                    return " - ";
                }
                else
                {
                    return Configuration.GraphicCard.Manufacturer + " " + Configuration.GraphicCard.Name;
                }
                
            }
        }
        public string BoxText
        {
            get
            {
                return Configuration.Box.Manufacturer + " " + Configuration.Box.Name;
            }
        }
        #endregion

        public FinalPageViewModel(ComputerConfiguration configuration)
            : base(configuration)
        {

        }
        public override string DisplayName { get { return "Summary"; } }
        internal override bool IsValid()
        {
            return true;
        }
    }
}

