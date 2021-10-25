using ApplicationService.Interface;
using DomainModel;

namespace ApplicationService.Dtos
{
    public class ProductDto : IDtoBase
    {
        /// <summary>
        /// آیدی محصول
        /// </summary>
        public int ProductId { get; set; }
        /// <summary>
        /// نام محصول
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// مدل محصول
        /// </summary>
        public string Model { get; set; }
        /// <summary>
        /// قیمت محصول
        /// </summary>
        public Amount Price { get; set; }
        /// <summary>
        /// رشته ای از مشخصات محصول
        /// </summary>
        public string Display()
        {
            return $"Id = {ProductId} | Name = {Name} | Model : {Model} | Price : {Price.Value} Toman";
        }
    }
}