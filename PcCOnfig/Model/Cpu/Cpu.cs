using System.ComponentModel.DataAnnotations;

namespace PcCOnfig.Model.cpu
{
    public class Cpu : ComputerComponent
    {
        [Required]
        public int NumberOfCores { get; set; }
        [Required]
        public ArchitectureEnum Architecture { get; set; }
        [Required]
        public decimal Frequency { get; set; }
        [Required]
        public CpuSocketEnum Socket { get; set; }
        [Required]
        public int PowerConsumption { get; set; }

    }
}
