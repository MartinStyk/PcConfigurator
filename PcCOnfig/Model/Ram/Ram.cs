using System.ComponentModel.DataAnnotations;

namespace PcCOnfig.Model.ram
{
    public class Ram : ComputerComponent
    {
        [Required]
        public int PowerConsumption { get; set; }

        [Required]
        public double Capacity { get; set; }

        [Required]
        public RamConnectionEnum ConnectionType { get; set; }

    }
}