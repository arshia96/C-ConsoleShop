using System.Collections.Generic;
using System.Linq;
using DomainModel;
using Infrastructure.Enums;
using Repository.Database;

namespace Repository
{
    public class GetProductsRepository
    {
        static DatabaseTable _database = DatabaseTable.GetInstance();
        private List<Product> _productsList = _database.ProductsList;
        public List<Product> GetAllProducts()
        {
            return _productsList;
        }

        public List<Product> GetCpuProducts()
        {
            var productsList = _productsList.Where(j => j.Device.DeviceType == DeviceType.Cpu).ToList();
            return productsList;
        }

        public List<Product> GetRamProducts()
        {
            var productsList = _productsList.Where(j => j.Device.DeviceType == DeviceType.Ram).ToList();
            return productsList;
        }

        public List<Product> GetGraphicCardProducts()
        {
            var productsList = _productsList.Where(j => j.Device.DeviceType == DeviceType.GraphicCard).ToList();
            return productsList;
        }

        public List<Product> GetHddProducts()
        {
            var productsList = _productsList.Where(j => j.Device.DeviceType == DeviceType.Hdd).ToList();
            return productsList;
        }

        public List<Product> GetSsdProducts()
        {
            var productsList = _productsList.Where(j => j.Device.DeviceType == DeviceType.Ssd).ToList();
            return productsList;
        }

        public List<Product> GetMotherboardProducts()
        {
            var productsList = _productsList.Where(j => j.Device.DeviceType == DeviceType.MotherBoard).ToList();
            return productsList;
        }

        public List<Product> GetPowerProducts()
        {
            var productsList = _productsList.Where(j => j.Device.DeviceType == DeviceType.Power).ToList();
            return productsList;
        }

        public List<Product> GetCaseProducts()
        {
            var productsList = _productsList.Where(j => j.Device.DeviceType == DeviceType.Case).ToList();
            return productsList;
        }
        public List<Product> GetMouseProducts()
        {
            var productsList = _productsList.Where(j => j.Device.DeviceType == DeviceType.Mouse).ToList();
            return productsList;
        }

        public List<Product> GetKeyboardProducts()
        {
            var productsList = _productsList.Where(j => j.Device.DeviceType == DeviceType.Keyboard).ToList();
            return productsList;
        }
    }
}