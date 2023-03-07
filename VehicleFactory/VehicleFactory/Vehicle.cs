using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleFactory
{
    public abstract class Vehicle : IDriveable
    {
        public string? Model { get; set; }
        public Manufacturer Manufacturer { get; private set; }

        public Engine? Engine { get; set; }

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

        /// <summary>
        /// Drives this instance.
        /// </summary>
        /// <exception cref="Exception">No engine.</exception>
        /// <exception cref="NullReferenceException">No engine.</exception>
        public virtual void Drive()
        {
            try
            {
                int? horsePower = Engine.HorsePower;
                //Engine = new Engine() { HorsePower = 8 };
                //if (Engine == null )
                //{
                //    throw new Exception("No engine.");
                //}
                //Console.WriteLine(horsePower);
            }
            catch (NullReferenceException e)
            {
                Console.WriteLine("Please assign engine!");
                throw;
            }
            catch (DivideByZeroException e)
            {
                Console.WriteLine(" DivideByZeroException");
                //throw;
            }
            catch (Exception e)
            {
                Console.WriteLine("Upps");
            }
            finally
            {
                Console.WriteLine("hallo");
            }

            Console.WriteLine($"Type: {GetType().FullName} - {nameof(Drive)}");
        }
    }
}
