using System.Data.Entity;
using PcCOnfig.Model.cpu;
using PcCOnfig.Model.graphics;
using PcCOnfig.Model.hdd;
using PcCOnfig.Model.powersupply;
using PcCOnfig.Model.ram;

namespace PcCOnfig.Model
{
    public class ComponentContext : DbContext
    {
        public virtual DbSet<Cpu> Cpus { get; set; }
        public virtual DbSet<Ram> Rams { get; set; }
        public virtual DbSet<Hdd> HardDrives { get; set; }
        public virtual DbSet<Motherboard.Motherboard> MotherBoards { get; set; }
        public virtual DbSet<PowerSupply> PowerSupplies { get; set; }
        public virtual DbSet<GraphicCard> GraphicCards { get; set; }
        public virtual DbSet<Box.Box> Boxes { get; set; }
        public virtual DbSet<ComputerConfiguration.ComputerConfiguration> ComputerConfigurations { get; set; }
    }
}
