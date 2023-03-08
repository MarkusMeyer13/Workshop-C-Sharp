using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleFactory
{
    public class Factory
    {
        public static IDriveable? Build<T>(Manufacturer manufacturer) where T : IDriveable
        {
            IDriveable? result = null;

            if(typeof(T) == typeof(Car))
            {
                result = new Car(manufacturer);
            }
            else if (typeof(T) == typeof(Truck))
            {
                result = new Truck(manufacturer);
            }
            Console.WriteLine($"Type:  {result?.GetType().FullName}");
            return result;
        }
    }
}
