using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
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

        [Obsolete("Please use 'Build'", false)]
        public static T? BuildWithType<T>(Manufacturer manufacturer) where T : IDriveable
        {
            T? result  = default;

            if (typeof(T) == typeof(Car))
            {
                var car = new Car(manufacturer);
                result = (T)Convert.ChangeType(car, typeof(T));
            }
            else if (typeof(T) == typeof(Truck))
            {
                var truck = new Truck(manufacturer);
                result = (T)Convert.ChangeType(truck, typeof(T));
            }
            return result;
        }
    }
}
