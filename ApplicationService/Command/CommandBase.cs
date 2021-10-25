namespace ApplicationService.Command
{
    public abstract class CommandBase
    {
        /// <summary>
        /// اعتبار سنجی
        /// </summary>
        public abstract void Validate();
    }
}