using System;
using Infrastructure.Enums;

namespace DomainModel
{
    public class PartCpu : Device
    {
        /// <summary>
        /// تعداد هسته های پردازنده
        /// </summary>
        public int Cores { get; set; }
        /// <summary>
        /// سری پردازنده
        /// </summary>
        public string Series { get; set; }
        /// <summary>
        /// سوکت پردازنده
        /// </summary>
        public string Socket { get; set; }
        public PartCpu(int id, string name, string model, string series, string socket, int cores)
        {
            Id = Guid.NewGuid();
            Series = series;
            Cores = cores;
            DeviceId = id;
            Name = name;
            Model = model;
            Socket = socket;
            DeviceType = DeviceType.Cpu;
        }
    }
}
