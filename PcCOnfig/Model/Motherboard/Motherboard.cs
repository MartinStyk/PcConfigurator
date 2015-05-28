using System.ComponentModel.DataAnnotations;
using PcCOnfig.Model.cpu;
using PcCOnfig.Model.graphics;
using PcCOnfig.Model.hdd;
using PcCOnfig.Model.ram;

namespace PcCOnfig.Model.Motherboard
{
    public class Motherboard : ComputerComponent
    {
        [Required]
        public int PowerConsumption { get; set; }
        [Required]
        public HardDriveConnectionEnum HardDriveConnectionType { get; set; }
        [Required]
        public CpuSocketEnum CpuConnectionType { get; set; }
        [Required]
        public RamConnectionEnum RamConnectionType { get; set; }
        [Required]
        public int RamConnectionNumber { get; set; }

        public GraphicsConnectionEnum GraphicsConnectionType { get; set; }

    }
}
