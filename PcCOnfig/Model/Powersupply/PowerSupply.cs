using System.ComponentModel.DataAnnotations;

namespace PcCOnfig.Model.powersupply
{
    public class PowerSupply : ComputerComponent
    {
   
        [Required]
        public int MaximumPower { get; set; }

    }
}
