using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleFactory
{
    public class AmphibiousVehicle : IDriveable, ISwimable
    {
        public void Drive()
        {
            Console.WriteLine($"Type: {GetType().FullName} - {nameof(Drive)}");
        }

        public bool Swim(int maxSwimCount)
        {
            Console.WriteLine($"Type: {GetType().FullName} - {nameof(Swim)}");
            return true;
        }
    }

    public class AmphibiousVehicleOne : Vehicle, ISwimable
    {
        public AmphibiousVehicleOne(Manufacturer manufacturer) : base(manufacturer)
        {
        }

        public bool Swim(int maxSwimCount)
        {
            throw new NotImplementedException();
        }
    }
    //public class AmphibiousVehicleTwo : Vehicle, Boat
    //{
    //    public AmphibiousVehicleTwo(Manufacturer manufacturer) : base(manufacturer)
    //    {
    //    }
    //}
}
