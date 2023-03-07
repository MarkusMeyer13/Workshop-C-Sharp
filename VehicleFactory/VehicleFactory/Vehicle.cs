using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleFactory
{
    public abstract class Vehicle: IDriveable
    {
        public string? Model { get; set; }
        public Manufacturer Manufacturer { get; private set; }

        public Vehicle(Manufacturer manufacturer)
        {
            Manufacturer = manufacturer;
        }

        public virtual void DoSomething()
        {
            Console.WriteLine("Base");
        }

        protected void Stop()
        {
            Console.WriteLine(nameof(Stop));
        }

        public virtual void Drive()
        {
            Console.WriteLine($"Type: {GetType().FullName} - {nameof(Drive)}");
        }
    }
}
