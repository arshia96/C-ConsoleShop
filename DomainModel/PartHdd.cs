using System;
using Infrastructure.Enums;

namespace DomainModel
{
    public class PartHdd : Device
    {
        /// <summary>
        /// حجم فضای هارد
        /// </summary>
        public int Capacity { get; set; }
        /// <summary>
        /// سوکت هارد
        /// </summary>
        public string Socket { get; set; }
        public PartHdd(int id, string name, string model, int capacity, string socket)
        {
            Id = Guid.NewGuid();
            DeviceId = id;
            Name = name;
            Model = model;
            Capacity = capacity;
            Socket = socket;
            DeviceType = DeviceType.Hdd;
        }
    }
}