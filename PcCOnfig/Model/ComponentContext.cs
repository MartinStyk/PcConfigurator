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
        public  DbSet<Cpu> Cpus { get; set; }
        public  DbSet<Ram> Rams { get; set; }
        public  DbSet<Hdd> HardDrives { get; set; }
        public DbSet<Motherboard.Motherboard> MotherBoards { get; set; }
        public  DbSet<PowerSupply> PowerSupplies { get; set; }
        public  DbSet<GraphicCard> GraphicCards { get; set; }
        public  DbSet<Box.Box> Boxes { get; set; }
        public  DbSet<ComputerConfiguration.ComputerConfiguration> ComputerConfigurations { get; set; }
    }
}