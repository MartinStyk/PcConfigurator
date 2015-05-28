using System.ComponentModel.DataAnnotations;

namespace PcCOnfig.Model.graphics
{
    public class GraphicCard : ComputerComponent
    {
        [Required]
        public int PowerConsumption { get; set; }
        [Required]
        public double Capacity { get; set; }
        [Required]
        public GraphicsConnectionEnum ConnectionType { get; set; }
    }
}
