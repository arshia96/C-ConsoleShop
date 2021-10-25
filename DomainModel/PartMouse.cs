using System;
using Infrastructure.Enums;

namespace DomainModel
{
    public class PartMouse : Device
    {
        public int Dpi { get; set; }
        public PartMouse(int id, string name, string model, int dpi)
        {
            Id = Guid.NewGuid();
            Dpi = dpi;
            DeviceId = id;
            Name = name;
            Model = model;
            DeviceType = DeviceType.Mouse;
        }
    }
}   