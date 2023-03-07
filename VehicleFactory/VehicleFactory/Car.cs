using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace VehicleFactory
{
    public class Car : Vehicle
    {
        public Car(Manufacturer manufacturer) : base(manufacturer)
        {
        }

        public override void Drive()
        {
            Console.WriteLine("Drive");
            Brake();
            Stop();
        }

        private void Brake()
        {
            Console.WriteLine("Brake");
        }

        public override void DoSomething()
        {
            base.DoSomething();
            Console.WriteLine("From car");
        }

        public override string ToString()
        {
            return $"Type: '{this.GetType().FullName}'; BaseType: '{this.GetType().BaseType?.FullName}'";
        }
    }

}

