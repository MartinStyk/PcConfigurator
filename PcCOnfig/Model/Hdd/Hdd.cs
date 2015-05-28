using System.ComponentModel.DataAnnotations;

namespace PcCOnfig.Model.hdd
{
    public class Hdd : ComputerComponent
    {
        [Required]
        public double Capacity { get; set; }
        [Required]
        public int PowerConsumption { get; set; }
        [Required]
        public HardDriveConnectionEnum ConnectionType { get; set; }
        [Required]
        public HardDriveTypeEnum Type { get; set; }
    }
}
