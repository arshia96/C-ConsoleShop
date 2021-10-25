using System;
using Infrastructure.Enums;
namespace ApplicationService.Dtos
{
    public class InstallmentDto
    {
        public Guid InstallmentId { get; set; }
        /// <summary>
        /// تعداد اقساط
        /// </summary>
        public int InstallmentCount;
        /// <summary>
        /// قیمت قسط
        /// </summary>
        public decimal Price;
        /// <summary>
        /// زمان معیّن پرداخت قسط
        /// </summary>
        public DateTime PayDate;
        /// <summary>
        /// وضعیت قسط
        /// </summary>
        public InstallmentStateType InstallmentStateType; 
        public InstallmentDto(int installmentCount, decimal price, DateTime payDate, InstallmentStateType installmentStateType)
        {
            InstallmentCount = installmentCount;
            Price = price;
            PayDate = payDate;
            InstallmentStateType = installmentStateType;
        }

        public InstallmentDto(Guid id)
        {
            InstallmentId = id;
        }
    }
}