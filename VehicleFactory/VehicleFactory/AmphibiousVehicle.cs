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

        public void Swim()
        {
            Console.WriteLine($"Type: {GetType().FullName} - {nameof(Swim)}");
        }
    }

    public class AmphibiousVehicleOne : Vehicle, ISwimable
    {
        public AmphibiousVehicleOne(Manufacturer manufacturer) : base(manufacturer)
        {
        }

        public void Swim()
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
