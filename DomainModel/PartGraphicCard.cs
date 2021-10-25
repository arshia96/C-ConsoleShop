using System;
using Infrastructure.Enums;

namespace DomainModel
{
    public class PartGraphicCard : Device
    {
        /// <summary>
        /// حجم کارت گرافیک
        /// </summary>
        public int Capacity { get; set; }
        /// <summary>
        /// سوکت کارت گرافیک
        /// </summary>
        public string Socket { get; set; }
        public PartGraphicCard(int id, string name, string model, int capacity, string socket)
        {
            Id = Guid.NewGuid();
            DeviceId = id;
            Name = name;
            Model = model;
            Capacity = capacity;
            Socket = socket;
            DeviceType = DeviceType.GraphicCard;
        }
    }
}