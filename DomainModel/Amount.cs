using Infrastructure.Exceptions;

namespace DomainModel
{
    public class Amount
    {
        public decimal Value{ get; set; }
        /// <summary>
        /// Value
        /// مبلغ
        /// </summary>
        public Amount(decimal value)
        {
            Validation(value);
            Value = value;
        }
        private void Validation(decimal value) 
        {
            if (value < 0)
                throw new InvalidAmountException();
        }
        /// <summary>
        /// تفریق امانت از امانت
        /// </summary>
        public void MinusAmount(Amount value)
        {
            Value -= value.Value;
        }
        /// <summary>
        /// ضرب امانت در یک امانت دیگر
        /// </summary>
        /// <param name="value"></param>
        public void MultipleAmount(Amount value)
        {
            Value *= value.Value;
        }
        /// <summary>
        /// تقسیم امانت و امانت دیگر
        /// </summary>
        public void DivisionAmount(Amount value)
        {
            var a = Value / value.Value;
            Value = a;
        }
    }
}
