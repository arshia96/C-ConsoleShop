using System;
using System.Collections.Generic;
using DomainModel;
using Infrastructure.Enums;

namespace ApplicationService.Dtos
{
    public class CartDto
    {
        /// <summary>
        /// نام سبد خرید
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// وضعیت سبدخرید
        /// </summary>
        public CartStateType CartStateType { get; set; }
        /// <summary>
        /// لیست محصولات داخل سبدخرید
        /// </summary>
        public List<ProductDto> ProductDtos { get; set; } = new List<ProductDto>();
    }
}