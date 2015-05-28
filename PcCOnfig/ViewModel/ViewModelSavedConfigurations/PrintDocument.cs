using System;
using System.Windows.Documents;
using PcCOnfig.Model.Box;
using PcCOnfig.Model.cpu;
using PcCOnfig.Model.ComputerConfiguration;
using PcCOnfig.Model.graphics;
using PcCOnfig.Model.hdd;
using PcCOnfig.Model.Motherboard;
using PcCOnfig.Model.powersupply;
using PcCOnfig.Model.ram;

namespace PcCOnfig.ViewModel.ViewModelSavedConfigurations
{
    public class PrintDocument
    {
        private readonly FlowDocument _flowDocument;
        private readonly ComputerConfiguration _config;
        public PrintDocument(ComputerConfiguration config){
            if(config == null) {
                throw new ArgumentNullException("config");
            }
            _flowDocument= new FlowDocument();
            _config = config;

        }

        public FlowDocument CreateFlowDocument( )
        {
            Paragraph name = new Paragraph();

            name.Inlines.Add(new Run("Computer configuration name : "));
            name.Inlines.Add(new Bold(new Run( _config.ConfigurationName )));  
            _flowDocument.Blocks.Add(name);
            CreateMotherboardSection();
            CreateCpuSection();
            CreateHddSection();
            CreateRamSection();
            CreatePowerSupplySection();
            CreateGraphicCardSection();
            CreateBoxSection();
           return _flowDocument;
        }
        private void CreateMotherboardSection()
        {
            Motherboard mb = _config.GetMotherboard();
            
            Paragraph motherBoard = new Paragraph();
            motherBoard.Inlines.Add(new Bold(new Run("Motherboard : ")));
            motherBoard.Inlines.Add(new Run(mb.Manufacturer + mb.Name));

            List motherBoardList = new List();
            Paragraph motherBoardListItem1 = new Paragraph(new Run("Cpu connection : " + mb.CpuConnectionType));
            Paragraph motherBoardListItem2 = new Paragraph(new Run("Ram connection : " + mb.RamConnectionType));
            Paragraph motherBoardListItem3 = new Paragraph(new Run("Hdd connection : " + mb.HardDriveConnectionType));
            Paragraph motherBoardListItem4 = new Paragraph(new Run("Graphic card connection : " + mb.GraphicsConnectionType));
            Paragraph motherBoardListItem5 = new Paragraph(new Run("Power consumption : " + mb.PowerConsumption + "W"));
            Paragraph motherBoardListItem6 = new Paragraph(new Run("Price : " + mb.Price + "€"));
            Paragraph motherBoardListItem7 = new Paragraph(new Run("Info : " + mb.Info));

            // Add ListItems with paragraphs in them.
            motherBoardList.ListItems.Add(new ListItem(motherBoardListItem1));
            motherBoardList.ListItems.Add(new ListItem(motherBoardListItem2));
            motherBoardList.ListItems.Add(new ListItem(motherBoardListItem3));
            motherBoardList.ListItems.Add(new ListItem(motherBoardListItem4));
            motherBoardList.ListItems.Add(new ListItem(motherBoardListItem5));
            motherBoardList.ListItems.Add(new ListItem(motherBoardListItem6));
            motherBoardList.ListItems.Add(new ListItem(motherBoardListItem7));

            _flowDocument.Blocks.Add(motherBoard);
            _flowDocument.Blocks.Add(motherBoardList);

        }
        private void CreateCpuSection()
        {
            Cpu cpu = _config.GetCpu();

            Paragraph cpuParag = new Paragraph();
            cpuParag.Inlines.Add(new Bold(new Run("Cpu : ")));
            cpuParag.Inlines.Add(new Run(cpu.Manufacturer + cpu.Name));

            List cpuList = new List();
            Paragraph listItem3 = new Paragraph(new Run("Frequency : " + cpu.Frequency + "GHz"));
            Paragraph listItem4 = new Paragraph(new Run("Number of cores : " + cpu.NumberOfCores));
            Paragraph listItem5 = new Paragraph(new Run("Power consumption : " + cpu.PowerConsumption + "W"));
            Paragraph listItem6 = new Paragraph(new Run("Price : " + cpu.Price + "€"));
            Paragraph listItem7 = new Paragraph(new Run("Info : " + cpu.Info));

            // Add ListItems with paragraphs in them.
            cpuList.ListItems.Add(new ListItem(listItem3));
            cpuList.ListItems.Add(new ListItem(listItem4));
            cpuList.ListItems.Add(new ListItem(listItem5));
            cpuList.ListItems.Add(new ListItem(listItem6));
            cpuList.ListItems.Add(new ListItem(listItem7));

            _flowDocument.Blocks.Add(cpuParag);
            _flowDocument.Blocks.Add(cpuList);

        }
        private void CreateHddSection()
        {
            Hdd r = _config.GetHdd();

            Paragraph parag = new Paragraph();
            parag.Inlines.Add(new Bold(new Run("Hard Drive : ")));
            parag.Inlines.Add(new Run(r.Manufacturer + r.Name));

            List list = new List();
            Paragraph listItem2 = new Paragraph(new Run("Connection : " + r.ConnectionType));
            Paragraph listItem3 = new Paragraph(new Run("Type : " + r.Type));
            Paragraph listItem4 = new Paragraph(new Run("Capacity : " + r.Capacity + "GB"));
            Paragraph listItem5 = new Paragraph(new Run("Power consumption : " + r.PowerConsumption + "W"));
            Paragraph listItem6 = new Paragraph(new Run("Price : " + r.Price + "€"));
            Paragraph listItem7 = new Paragraph(new Run("Info : " + r.Info));

            list.ListItems.Add(new ListItem(listItem2));
            list.ListItems.Add(new ListItem(listItem3));
            list.ListItems.Add(new ListItem(listItem4));
            list.ListItems.Add(new ListItem(listItem5));
            list.ListItems.Add(new ListItem(listItem6));
            list.ListItems.Add(new ListItem(listItem7));

            _flowDocument.Blocks.Add(parag);
            _flowDocument.Blocks.Add(list);

        }
        private void CreateRamSection()
        {
            Ram r = _config.GetRam();

            Paragraph parag = new Paragraph();
            parag.Inlines.Add(new Bold(new Run("Ram : ")));
            parag.Inlines.Add(new Run(r.Manufacturer + r.Name));

            List list = new List();
            Paragraph listItem3 = new Paragraph(new Run("Type : " + r.ConnectionType));
            Paragraph listItem4 = new Paragraph(new Run("Capacity : " + r.Capacity + "GB"));
            Paragraph listItem5 = new Paragraph(new Run("Power consumption : " + r.PowerConsumption + "W"));
            Paragraph listItem6 = new Paragraph(new Run("Price : " + r.Price + "€"));
            Paragraph listItem7 = new Paragraph(new Run("Info : " + r.Info));

            list.ListItems.Add(new ListItem(listItem3));
            list.ListItems.Add(new ListItem(listItem4));
            list.ListItems.Add(new ListItem(listItem5));
            list.ListItems.Add(new ListItem(listItem6));
            list.ListItems.Add(new ListItem(listItem7));

            _flowDocument.Blocks.Add(parag);
            _flowDocument.Blocks.Add(list);

        }
        private void CreatePowerSupplySection()
        {
            PowerSupply ps = _config.GetPowerSupply();

            Paragraph parag = new Paragraph();
            parag.Inlines.Add(new Bold(new Run("Power Supply : ")));
            parag.Inlines.Add(new Run(ps.Manufacturer + ps.Name));

            List list = new List();
            Paragraph listItem5 = new Paragraph(new Run("Maximum Power : " + ps.MaximumPower + "W"));
            Paragraph listItem6 = new Paragraph(new Run("Price : " + ps.Price + "€"));
            Paragraph listItem7 = new Paragraph(new Run("Info : " + ps.Info));
            list.ListItems.Add(new ListItem(listItem5));
            list.ListItems.Add(new ListItem(listItem6));
            list.ListItems.Add(new ListItem(listItem7));

            _flowDocument.Blocks.Add(parag);
            _flowDocument.Blocks.Add(list);

        }
        private void CreateBoxSection()
        {
            Box r = _config.GetBox();

            Paragraph parag = new Paragraph();
            parag.Inlines.Add(new Bold(new Run("Box : ")));
            parag.Inlines.Add(new Run(r.Manufacturer + r.Name));

            List list = new List();
            Paragraph listItem5 = new Paragraph(new Run(String.Format("Dimenstions : {0}x{1}x{2} cm", r.Height,r.Width,r.Depth)));
            Paragraph listItem6 = new Paragraph(new Run("Price : " + r.Price + "€"));
            Paragraph listItem7 = new Paragraph(new Run("Info : " + r.Info));

            list.ListItems.Add(new ListItem(listItem5));
            list.ListItems.Add(new ListItem(listItem6));
            list.ListItems.Add(new ListItem(listItem7));

            _flowDocument.Blocks.Add(parag);
            _flowDocument.Blocks.Add(list);

        }
        private void CreateGraphicCardSection()
        {
            if (_config.GraphicCardId == null)
            {
                return;
            }
            GraphicCard r = _config.GetGraphicCard();

            Paragraph parag = new Paragraph();
            parag.Inlines.Add(new Bold(new Run("Graphic Card : ")));
            parag.Inlines.Add(new Run(r.Manufacturer + r.Name));

            List list = new List();
            Paragraph listItem2 = new Paragraph(new Run("Connection : " + r.ConnectionType));
            Paragraph listItem4 = new Paragraph(new Run("Memory : " + r.Capacity + "GB"));
            Paragraph listItem5 = new Paragraph(new Run("Power consumption : " + r.PowerConsumption + "W"));
            Paragraph listItem6 = new Paragraph(new Run("Price : " + r.Price + "€"));
            Paragraph listItem7 = new Paragraph(new Run("Info : " + r.Info));

            list.ListItems.Add(new ListItem(listItem2));
            list.ListItems.Add(new ListItem(listItem4));
            list.ListItems.Add(new ListItem(listItem5));
            list.ListItems.Add(new ListItem(listItem6));
            list.ListItems.Add(new ListItem(listItem7));

            _flowDocument.Blocks.Add(parag);
            _flowDocument.Blocks.Add(list);

        }
    }
}
