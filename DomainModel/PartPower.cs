using System;
using Infrastructure.Enums;

namespace DomainModel
{
    public class PartPower : Device
    {
        /// <summary>
        /// مقدار جریان منبع تغذیه
        /// </summary>
        public int Capacity { get; set; }
        public PartPower(int id, string name, string model, int capacity)
        {
            Id = Guid.NewGuid();
            DeviceId = id;
            Name = name;
            Model = model;
            Capacity = capacity;
            DeviceType = DeviceType.Power;
        }
    }
}