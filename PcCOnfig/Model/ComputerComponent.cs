using System.ComponentModel.DataAnnotations;

namespace PcCOnfig.Model
{
    public class ComputerComponent
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Manufacturer { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public decimal Price { get; set; }
        public string Info { get; set; }
        [Required]
        public bool IsDeleted { get; set; }
    }

}
