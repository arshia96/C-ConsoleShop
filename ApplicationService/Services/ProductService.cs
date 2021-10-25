using System.Collections.Generic;
using System.Linq;
using ApplicationService.Command;
using ApplicationService.Dtos;
using ApplicationService.Interface;
using DomainModel;
using Infrastructure.Enums;
using Infrastructure.Exceptions;
using Repository;
using Repository.Database;

namespace ApplicationService.Services
{
    public class ProductService : IProductService
    {
        private static readonly DatabaseTable database = DatabaseTable.GetInstance();
        private readonly GetProductsRepository _getProductsRepository = new GetProductsRepository();
        public Product RegisterProduct(ProductCommand command)
        {
            List<Product> _productsList = database.ProductsList;
            var product = _productsList.SingleOrDefault(i => i.ProductId == command.ProductId);
            if (product == null)
                throw new InvalidProductDbException();
            return product;
        }
        public List<ProductDto> GetAllProducts()
        {
            var result = new List<ProductDto>();
            var productList = _getProductsRepository.GetAllProducts();
            for (int i = 0; i <= productList.Count; i++)
            {
                var product = productList.SingleOrDefault(j => j.ProductId - 1 == i);
                if (product != null)
                    result.Add(new ProductDto()
                    {
                        ProductId = product.ProductId,
                        Name = product.Device.Name,
                        Model = product.Device.Model,
                        Price = product.Price
                    });
            }
            return result;
        }

        public List<ProductDto> GetCpuProducts()
        {
            var result = new List<ProductDto>();
            var productList = _getProductsRepository.GetCpuProducts();
            for (var index = 0; index < productList.Count(); index++)
            {
                result.Add(new ProductDto()
                {
                    ProductId = productList[index].ProductId,
                    Name = productList[index].Device.Name,
                    Model = productList[index].Device.Model,
                    Price = productList[index].Price
                });
            }
            return result;
        }

        public List<ProductDto> GetRamProducts()
        {
            var result = new List<ProductDto>();
            var productList = _getProductsRepository.GetRamProducts();
            for (var index = 0; index < productList.Count(); index++)
            {
                result.Add(new ProductDto()
                {
                    ProductId = productList[index].ProductId,
                    Name = productList[index].Device.Name,
                    Model = productList[index].Device.Model,
                    Price = productList[index].Price
                });
            }

            return result;
        }

        public List<ProductDto> GetGraphicCardProducts()
        {
            var result = new List<ProductDto>();
            var productList = _getProductsRepository.GetGraphicCardProducts();
            for (var index = 0; index < productList.Count(); index++)
            {
                result.Add(new ProductDto()
                {
                    ProductId = productList[index].ProductId,
                    Name = productList[index].Device.Name,
                    Model = productList[index].Device.Model,
                    Price = productList[index].Price
                });
            }

            return result;
        }

        public List<ProductDto> GetHddProducts()
        {
            var result = new List<ProductDto>();
            var productList = _getProductsRepository.GetHddProducts();
            for (var index = 0; index < productList.Count(); index++)
            {
                result.Add(new ProductDto()
                {
                    ProductId = productList[index].ProductId,
                    Name = productList[index].Device.Name,
                    Model = productList[index].Device.Model,
                    Price = productList[index].Price
                });
            }

            return result;
        }

        public List<ProductDto> GetSsdProducts()
        {
            var result = new List<ProductDto>();
            var productList = _getProductsRepository.GetSsdProducts();
            for (var index = 0; index < productList.Count(); index++)
            {
                result.Add(new ProductDto()
                {
                    ProductId = productList[index].ProductId,
                    Name = productList[index].Device.Name,
                    Model = productList[index].Device.Model,
                    Price = productList[index].Price
                });
            }
            return result;
        }

        public List<ProductDto> GetMotherboardProducts()
        {
            var result = new List<ProductDto>();
            var productList = _getProductsRepository.GetMotherboardProducts();
            for (var index = 0; index < productList.Count(); index++)
            {
                result.Add(new ProductDto()
                {
                    ProductId = productList[index].ProductId,
                    Name = productList[index].Device.Name,
                    Model = productList[index].Device.Model,
                    Price = productList[index].Price
                });
            }

            return result;
        }

        public List<ProductDto> GetPowerProducts()
        {
            var result = new List<ProductDto>();
            var productList = _getProductsRepository.GetPowerProducts();
            for (var index = 0; index < productList.Count(); index++)
            {
                result.Add(new ProductDto()
                {
                    ProductId = productList[index].ProductId,
                    Name = productList[index].Device.Name,
                    Model = productList[index].Device.Model,
                    Price = productList[index].Price
                });
            }

            return result;
        }

        public List<ProductDto> GetCaseProducts()
        {
            var result = new List<ProductDto>();
            var productList = _getProductsRepository.GetCaseProducts();
            for (var index = 0; index < productList.Count(); index++)
            {
                result.Add(new ProductDto()
                {
                    ProductId = productList[index].ProductId,
                    Name = productList[index].Device.Name,
                    Model = productList[index].Device.Model,
                    Price = productList[index].Price
                });
            }

            return result;
        }
        public List<ProductDto> GetMouseProducts()
        {
            var result = new List<ProductDto>();
            var productList = _getProductsRepository.GetMouseProducts();
            for (var index = 0; index < productList.Count(); index++)
            {
                result.Add(new ProductDto()
                {
                    ProductId = productList[index].ProductId,
                    Name = productList[index].Device.Name,
                    Model = productList[index].Device.Model,
                    Price = productList[index].Price
                });
            }
            return result;
        }

        public List<ProductDto> GetKeyboardProducts()
        {
            var result = new List<ProductDto>();
            var productList = _getProductsRepository.GetKeyboardProducts();
            for (var index = 0; index < productList.Count(); index++)
            {
                result.Add(new ProductDto()
                {
                    ProductId = productList[index].ProductId,
                    Name = productList[index].Device.Name,
                    Model = productList[index].Device.Model,
                    Price = productList[index].Price
                });
            }
            return result;
        }
    }
}