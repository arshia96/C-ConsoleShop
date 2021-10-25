using System;
using Infrastructure.Enums;

namespace DomainModel
{
    public class Device
    {
        /// <summary>
        /// آیدی دیوایس در دیتابیس
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// آیدی مربوط به دیوایس
        /// </summary>
        public int DeviceId { get; set; }
        /// <summary>
        /// نام دیوایس
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// مدل دیوایس
        /// </summary>
        public string Model { get; set; }
        /// <summary>
        /// نوع دیوایس
        /// </summary>
        public DeviceType DeviceType { get; set; }
    }
}