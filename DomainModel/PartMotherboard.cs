using System;
using Infrastructure.Enums;

namespace DomainModel
{
    public class PartMotherboard : Device
    {
        /// <summary>
        /// سوکت اتصال پردازنده ی مادربورد
        /// </summary>
        public string CpuSocket { get; set; }
        public PartMotherboard(int id, string name, string model, string socket)
        {
            Id = Guid.NewGuid();
            DeviceId = id;
            Name = name;
            Model = model;
            CpuSocket = socket;
            DeviceType = DeviceType.MotherBoard;
        }
    }
}