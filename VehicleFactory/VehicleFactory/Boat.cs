using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleFactory
{
    public class Boat : ISwimable
    {
        private int currentSwimCount = 0;

        public bool Swim(int maxSwimCount)
        {
            if(maxSwimCount < 0)
            {
                Console.WriteLine(nameof(Swim));
                return true;
            }

            if (currentSwimCount <= maxSwimCount)
            {
                currentSwimCount++;
                Console.WriteLine(nameof(Swim));
                return true;
            }

            return false;
        }
    }
}
