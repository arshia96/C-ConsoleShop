namespace DomainModel
{
    public class InstallmentStateCreated : InstallmentState
    {
        private readonly Installment _installment;
        public InstallmentStateCreated(Installment installment)
        {
            _installment = installment;
        }
        public override void SetCreatedState()
        {
            _installment.AddState(new InstallmentStateCreated(_installment));
        }

        public override void SetFailedState()
        {
            _installment.AddState(new InstallmentStateFailed());
        }

        public override void SetSuccessState()
        {
            _installment.AddState(new InstallmentStateSuccess());
        }
    }
}