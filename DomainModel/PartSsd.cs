using System;
using Infrastructure.Enums;

namespace DomainModel
{
    public class PartSsd : Device
    {
        /// <summary>
        /// مقدار فضای هارد
        /// </summary>
        public int Capacity { get; set; }
        /// <summary>
        /// سوکت اتصال هارد
        /// </summary>
        public string Socket { get; set; }
        public PartSsd(int id, string name, string model, int capacity, string socket)
        {
            Id = Guid.NewGuid();
            DeviceId = id;
            Name = name;
            Model = model;
            Capacity = capacity;
            Socket = socket;
            DeviceType = DeviceType.Ssd;
        }
    }
}