using System.Linq;
using PcCOnfig.Model.cpu;
using PcCOnfig.Model.graphics;
using PcCOnfig.Model.hdd;
using PcCOnfig.Model.powersupply;
using PcCOnfig.Model.ram;

namespace PcCOnfig.Model.ComputerConfiguration
{
    public static class ComputerConfigurationExtension
    {
        public static Motherboard.Motherboard GetMotherboard(this ComputerConfiguration config)
        {
            Motherboard.Motherboard motherboard;
            using (var db = new ComponentContext())
            {
                motherboard = (from Motherboard.Motherboard mb in db.MotherBoards where mb.Id == config.MotherboardId select mb).FirstOrDefault();
            }
            return motherboard;
        }
        public static Cpu GetCpu(this ComputerConfiguration config)
        {
            Cpu cpu;
            using (var db = new ComponentContext())
            {
                cpu = (from Cpu c in db.Cpus where c.Id == config.CpuId select c).FirstOrDefault();
            }
            return cpu;
        }
        public static Ram GetRam(this ComputerConfiguration config)
        {
            Ram ram;
            using (var db = new ComponentContext())
            {
                ram = (from Ram r in db.Rams where r.Id == config.RamId select r).FirstOrDefault();
            }
            return ram;
        }
        public static Hdd GetHdd(this ComputerConfiguration config)
        {
            Hdd hdd;
            using (var db = new ComponentContext())
            {
                hdd = (from Hdd i in db.HardDrives where i.Id == config.HddId select i).FirstOrDefault();
            }
            return hdd;
        }
        public static PowerSupply GetPowerSupply(this ComputerConfiguration config)
        {
            PowerSupply powerSupply;
            using (var db = new ComponentContext())
            {
                powerSupply = (from PowerSupply i in db.PowerSupplies where i.Id == config.PowerSupplyId select i).FirstOrDefault();
            }
            return powerSupply;
        }
        public static Box.Box GetBox(this ComputerConfiguration config)
        {
            Box.Box box;
            using (var db = new ComponentContext())
            {
                box = (from Box.Box i in db.Boxes where i.Id == config.BoxId select i).FirstOrDefault();
            }
            return box;
        }
        public static GraphicCard GetGraphicCard(this ComputerConfiguration config)
        {
            if (config.GraphicCardId == null)
            {
                return null;
            }
            GraphicCard graphicCard;
            using (var db = new ComponentContext())
            {
                graphicCard = (from GraphicCard i in db.GraphicCards where i.Id == config.GraphicCardId select i).FirstOrDefault();
            }
            return graphicCard;
        }
    }   
}
