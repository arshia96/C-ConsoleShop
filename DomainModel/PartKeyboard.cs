using System;
using Infrastructure.Enums;

namespace DomainModel
{
    public class PartKeyboard : Device
    {

        public PartKeyboard(int id, string name, string model)
        { 
            Id = Guid.NewGuid();
            DeviceId = id;
            Name = name;
            Model = model;  
            DeviceType = DeviceType.Keyboard;
        }
    }
}