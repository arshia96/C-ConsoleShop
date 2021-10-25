using System;

namespace ApplicationService.Command
{
    public class InstallmentCommand
    {
        public Guid InstallmentId { get; set; } = new Guid();
    }
}