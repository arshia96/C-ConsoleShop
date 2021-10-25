using System.Collections.Generic;
using DomainModel;

namespace Repository.Database
{
    public class DatabaseTable
    {
        private static DatabaseTable _instance;
        public static DatabaseTable GetInstance()
        {
            if (_instance == null)
                _instance = new DatabaseTable();
            return _instance;
        }
        public List<Cart> CartList { get; set; } = new List<Cart>();
    public List<User> UsersList { get; set; } = new List<User>() {new User(){Username = "Arshia" , Password = "12345", Name = "Arshia", Address = "PasdaranSt. No.1", Phone = "09202462411"},
            new User(){Username = "Ali", Password = "123", Name = "Ali", Address = "PasdaranSt. No.2", Phone = "09202462411" } };
        public List<PartCpu> CpuList
        {
            get
            {
                List<PartCpu> list = new List<PartCpu>()
                {
                    new PartCpu(1, "Intel", "Core i9", "10900", "LGA 1200", 10),
                    new PartCpu(2, "Intel", "Core i9", "9900K", "LGA 1151", 8),
                    new PartCpu(3, "Intel", "Core i7", "10700K", "LGA 1200", 8),
                    new PartCpu(4, "AMD", "Ryzen 9", "5900X", "AMD AM4", 12),
                    new PartCpu(5, "AMD", "Ryzen 7", "5800X", "AMD AM4", 8)
                };
                return list;
            }
        }
        public List<PartRam> RamList
        {
            get
            {
                List<PartRam> list = new List<PartRam>()
                {
                    new PartRam(1, "G Skill", "TRIDNTZ ROYAL LITE", 4000, 32, "DDR4"),
                    new PartRam(2, "G Skill","TRIDENTZ ROYAL GOLD", 4000, 16, "DDR4"),
                    new PartRam(3, "G Skill","TRIDENTZ ROYAL", 4000, 16, "DDR4"),
                    new PartRam(4, "G Skill","TRIDENTZ", 3200, 8, "DDR4"),
                    new PartRam(5, "TeamGroup","T-Force Delta", 3200, 8, "DDR4")
                };
                return list;
            }
        }
        public List<PartGraphicCard> GraphicCardList
        {
            get
            {
                List<PartGraphicCard> list = new List<PartGraphicCard>()
                {
                    new PartGraphicCard(1, "PNY", "Nvidia Quadro RTX 6000", 24, "PCI Express 4.0"),
                    new PartGraphicCard(2, "ASUS","TUF RTX3080", 10, "PCI Express 4.0"),
                    new PartGraphicCard(3, "MSI","RTX 3070 VENTUS 2X", 14, "PCI Express 3.0"),
                    new PartGraphicCard(4, "ASUS","TUF AMD RX6800", 16, "PCI Express 4.0"),
                    new PartGraphicCard(5, "XFX","AMD RX 6700 XT", 12, "PCI Express 4.0")
                };
                return list;
            }
        }
        public List<PartHdd> HddList
        {
            get
            {
                List<PartHdd> list = new List<PartHdd>()
                {
                    new PartHdd(1, "WesternDigital", "Purple WD121PURZ", 12, "SATA 3.0"),
                    new PartHdd(2, "WesternDigital","Purple WD60PURN", 10, "SATA 3.0"),
                    new PartHdd(3, "WesternDigital","Purple WD60PUMZ", 8, "SATA 3.0"),
                    new PartHdd(4, "WesternDigital","Purple WD60PURX", 6, "SATA 3.0"),
                    new PartHdd(5, "WesternDigital","Purple WD10PGMZON", 2, "SATA 3.0")
                };
                return list;
            }
        }
        public List<PartSsd> SsdList
        {
            get
            {
                List<PartSsd> list = new List<PartSsd>()
                {
                    new PartSsd(1, "Samsung", "EVO 870", 4000, "SATA 3.0"),
                    new PartSsd(2, "Samsung","QVO 870", 2000, "SATA 3.0"),
                    new PartSsd(3, "Samsung","EVO 870", 250, "SATA 3.0"),
                    new PartSsd(4, "Samsung","M.2 980", 1000, "PCI-Express 3.0 x4"),
                    new PartSsd(5, "Samsung","EVO 980", 500, "PCI-Express 3.0 x4")
                };
                return list;
            }
        }
        public List<PartMotherboard> MotherboardList
        {
            get
            {
                List<PartMotherboard> list = new List<PartMotherboard>()
                {
                    new PartMotherboard(1, "ASUS", "ROG MAXIMUS XIII HERO", "LGA 1200"),
                    new PartMotherboard(2, "ASUS", "ROG STRIX Z590-F GAMING", "LGA 1200"),
                    new PartMotherboard(3, "ASUS", "ROG Strix Z390-E Gaming", "LGA 1151"),
                    new PartMotherboard(4, "ASUS", "PRIME X570-PRO", "AMD AM4"),
                    new PartMotherboard(5, "ASUS", "ROG STRIX X470-F GAMING", "AMD AM4")
                };
                return list;
            }
        }
        public List<PartPower> PowerList
        {
            get
            {
                List<PartPower> list = new List<PartPower>()
                {
                    new PartPower(1, "ASUS", "ROG STRIX 1000W", 1000),
                    new PartPower(2, "ASUS","ROG Strix 850G White Editon", 850),
                    new PartPower(3, "ASUS","ROG Strix 750G", 750),
                    new PartPower(4, "ASUS","TUF-GAMING-650B", 650),
                    new PartPower(5, "ASUS","TUF Gaming 550B", 550)
                };
                return list;
            }
        }
        public List<PartCase> CaseList
        {
            get
            {
                List<PartCase> list = new List<PartCase>()
                {
                    new PartCase(1, "CoolerMaster", "MasterCase H500P Mesh"),
                    new PartCase(2, "CoolerMaster","MasterCase H500 Iron"),
                    new PartCase(3, "CoolerMaster","MasterBox K500 ARGB"),
                    new PartCase(4, "CoolerMaster","Silencio S600"),
                    new PartCase(5, "CoolerMaster","MasterBox TD500L")
                };
                return list;
            }
        }
        public List<PartKeyboard> KeyboardList
        {
            get
            {
                List<PartKeyboard> list = new List<PartKeyboard>()
                {
                    new PartKeyboard(1, "Logitech", "G910 Orion SPECTRUM"),
                    new PartKeyboard(2, "Razer","BlackWidow Tournament Edition Chroma V2"),
                    new PartKeyboard(3, "Logitech","CRAFT"),
                    new PartKeyboard(4, "Razer","BLACKWIDOW V3 Chroma")
                };
                return list;
            }
        }
        public List<PartMouse> MouseList
        {
            get
            {
                List<PartMouse> list = new List<PartMouse>()
                {
                    new PartMouse(1, "SteelSeries", "Rival 650", 12000),
                    new PartMouse(2, "Razer","Basilisk UltimateI", 20000),
                    new PartMouse(3, "Microsoft"," Surface Arc 2017", 1600),
                    new PartMouse(4, "Asus","ROG Gladius II Origin", 12000)
                };
                return list;
            }
        }

        public List<Product> ProductsList
        {
            get
            {
                List<Product> products = new List<Product>()
                {
                    new Product(1, CpuList[0],new Amount(18000000)),
                    new Product(2, CpuList[1],new Amount(15000000)),
                    new Product(3, CpuList[2],new Amount(13000000)),
                    new Product(4, CpuList[3],new Amount(15000000)),
                    new Product(5, CpuList[4],new Amount(13000000)),
                    new Product(6, RamList[0],new Amount(12000000)),
                    new Product(7, RamList[1],new Amount(10000000)),
                    new Product(8, RamList[2],new Amount(8000000)),
                    new Product(9, RamList[3],new Amount(6000000)),
                    new Product(10, RamList[4],new Amount(4000000)),
                    new Product(11, GraphicCardList[0],new Amount(130000000)),
                    new Product(12, GraphicCardList[1],new Amount(90000000)),
                    new Product(13, GraphicCardList[2],new Amount(70000000)),
                    new Product(14, GraphicCardList[3],new Amount(65000000)),
                    new Product(15, GraphicCardList[4],new Amount(40000000)),
                    new Product(16, HddList[0],new Amount(18000000)),
                    new Product(17, HddList[1],new Amount(13000000)),
                    new Product(18, HddList[2],new Amount(10000000)),
                    new Product(19, HddList[3],new Amount(7000000)),
                    new Product(20, HddList[4],new Amount(3000000)),
                    new Product(21, SsdList[0],new Amount(6000000)),
                    new Product(22, SsdList[1],new Amount(4000000)),
                    new Product(23, SsdList[2],new Amount(3000000)),
                    new Product(24, SsdList[3],new Amount(2000000)),
                    new Product(25, SsdList[4],new Amount(1000000)),
                    new Product(26, MotherboardList[0],new Amount(18000000)),
                    new Product(27, MotherboardList[1],new Amount(15000000)),
                    new Product(28, MotherboardList[2],new Amount(12000000)),
                    new Product(29, MotherboardList[3],new Amount(8000000)),
                    new Product(30, MotherboardList[4],new Amount(4000000)),
                    new Product(31, PowerList[0],new Amount(12000000)),
                    new Product(32, PowerList[1],new Amount(10000000)),
                    new Product(33, PowerList[2],new Amount(8000000)),
                    new Product(34, PowerList[3],new Amount(6000000)),
                    new Product(35, PowerList[4],new Amount(4000000)),
                    new Product(36, CaseList[0],new Amount(10000000)),
                    new Product(37, CaseList[1],new Amount(8000000)),
                    new Product(38, CaseList[2],new Amount(6000000)),
                    new Product(39, CaseList[3],new Amount(4000000)),
                    new Product(40, CaseList[4],new Amount(2000000)),
                    new Product(41, KeyboardList[0],new Amount(8000000)),
                    new Product(42, KeyboardList[1],new Amount(6000000)),
                    new Product(43, KeyboardList[2],new Amount(4000000)),
                    new Product(44, KeyboardList[3],new Amount(2000000)),
                    new Product(45, MouseList[0],new Amount(5000000)),
                    new Product(46, MouseList[1],new Amount(4000000)),
                    new Product(47, MouseList[2],new Amount(3000000)),
                    new Product(48, MouseList[3],new Amount(2000000))
                };
                return products;
            }
        }
    }
}