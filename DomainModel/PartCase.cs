using System;
using Infrastructure.Enums;
namespace DomainModel
{
    public class PartCase : Device
    {
        public PartCase(int id, string name, string model)
        {
            Id = Guid.NewGuid();
            DeviceId = id;    
            Name = name;
            Model = model;
            DeviceType = DeviceType.Case;
        }
    }
}