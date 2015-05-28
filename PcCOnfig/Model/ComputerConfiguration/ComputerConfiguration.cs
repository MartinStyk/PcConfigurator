using System.ComponentModel.DataAnnotations;
using PcCOnfig.Model.cpu;
using PcCOnfig.Model.graphics;
using PcCOnfig.Model.hdd;
using PcCOnfig.Model.powersupply;
using PcCOnfig.Model.ram;

namespace PcCOnfig.Model.ComputerConfiguration
{
    public class ComputerConfiguration
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string ConfigurationName { get; set; }

        #region cpu
        public int CpuId { get; set; }
        public virtual Cpu Cpu { get; set; }
        #endregion

        #region ram
        public int RamId { get; set; }
        public virtual Ram Ram{get;set;}
        #endregion

        #region ram
        public int HddId { get; set; }
        public virtual Hdd Hdd { get; set; }
        #endregion

        #region powersupply
        public int PowerSupplyId { get; set; }

        public virtual PowerSupply PowerSupply { get; set; }
        #endregion

        #region motherboard
        public int MotherboardId { get; set; }
        public virtual Motherboard.Motherboard Motherboard { get; set; }
        #endregion

        #region box
        public int BoxId { get; set; }
        public virtual Box.Box Box { get; set; }
        #endregion

        #region graphics
        public int? GraphicCardId { get; set; }
        public virtual GraphicCard GraphicCard { get; set; }
        #endregion
        public string Info { get; set; }
    }
}
