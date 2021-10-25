using System;
using System.Collections.Generic;
using System.Linq;
using Infrastructure.Enums;

namespace DomainModel
{
    public class Installment
    {
        public Installment(int months, Amount price, Amount commission, InstallmentStateType installmentStateType, DateTime payDate)
        {
            InstallmentId = Guid.NewGuid();
            InstallmentCount = months;
            Price = price;
            Commission = commission;
            InstallmentStateType = installmentStateType;
            PayDate = payDate;
            PlusCommissionCalculator(Commission);
        }

        public Guid InstallmentId { get; set; } = new Guid();
        /// <summary>
        /// زمان پرداخت قسط
        /// </summary>
        public DateTime PayDate { get; set; }
        /// <summary>
        /// زمان قسط پرداخت شده
        /// </summary>
        public DateTime PaidDate { get; set; }
        /// <summary>
        /// مبلغ هر قسط
        /// </summary>
        public Amount Price { get; set; }

        /// <summary>
        /// کارمزد
        /// </summary>
        public Amount Commission { get; set; } = new Amount(0);

        /// <summary>
        /// تعداد اقساط
        /// </summary>
        public int InstallmentCount { get; set; }
        /// <summary>
        /// لیست وضعیت های اقساط
        /// </summary>
        public IEnumerable<InstallmentState> _installmentStateHistory { get; private set; } = new List<InstallmentState>();
        /// <summary>
        /// وضعیت قسط
        /// </summary>
        public InstallmentStateType InstallmentStateType { get; set; }
        /// <summary>
        /// افزودن وضعیت به وضعیت های پرداخت اقساط
        /// </summary>
        public void AddState(InstallmentState installmentState)
        {
            var temp = _installmentStateHistory.ToList();
            temp.Add(installmentState);
            _installmentStateHistory = temp;
        }
        /// <summary>
        /// افزودن کارمزد اقساط در مبلغ هر قسط
        /// </summary>
        /// <param name="commission">کارمزد</param>
        public void PlusCommissionCalculator(Amount commission)
        {
            switch (commission.Value)
            {
                case 0.12m:
                    Price.MultipleAmount(new Amount(1.12m));
                    break;
                case 0.18m:
                    Price.MultipleAmount(new Amount(1.18m));
                    break;
                case 0.24m:
                    Price.MultipleAmount(new Amount(1.24m));
                    break;
            }
        }
    }
}