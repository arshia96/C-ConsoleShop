using System;
using Infrastructure.Enums;

namespace DomainModel
{
    public class PartRam : Device
    {
        /// <summary>
        /// حجم رم
        /// </summary>
        public int Capacity { get; set; }
        /// <summary>
        /// سوکت اتصال رم
        /// </summary>
        public string Socket { get; set; }
        /// <summary>
        /// فرکانس رم
        /// </summary>
        public int Frequency { get; set; }
        public PartRam(int id, string name, string model, int frequency, int capacity, string socket)
        {
            Id = Guid.NewGuid();
            DeviceId = id;
            Name = name;
            Model = model;
            Capacity = capacity;
            Socket = socket;
            Frequency = frequency;
            DeviceType = DeviceType.Ram;
        }
    }
}