using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleFactory
{
    public sealed class Truck: Vehicle
    {
        public Truck(Manufacturer manufacturer) : base(manufacturer)
        {
        }

        public int Charge { get; set; }

        //public void Drive()
        //{
        //    Console.WriteLine($"Type: {GetType().FullName} - {nameof(Drive)}");
        //}
    }
}
