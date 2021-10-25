using System;

namespace DomainModel
{
    public abstract class CartState
    {
        public Guid StateId = Guid.NewGuid();
        public DateTime dataTime = DateTime.Now; 
        public virtual void SetCreatedState(){}
        public virtual void SetRemovedFromCartState(){}
        public virtual void SetInstallmentShippingState(){}
        public virtual void SetFullPaidState(){}
        public virtual void SetExpireState(){}
    }
}