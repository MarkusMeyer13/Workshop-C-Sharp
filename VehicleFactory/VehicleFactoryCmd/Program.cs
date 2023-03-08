using System.ComponentModel.DataAnnotations;
using VehicleFactory;

namespace VehicleFactoryCmd
{
    internal class Program
    {
        private static void Vehicles()
        {
            var driveables = new List<IDriveable>();
            driveables.Add(new Car(new Manufacturer()));
            driveables.Add(new Truck(new Manufacturer()));
            driveables.Add(new AmphibiousVehicle());

            foreach (var driveable in driveables)
            {

                try
                {
                    driveable.Drive();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                finally
                {

                }

            }
        }


        private static void CreateEngine()
        {
            var engine = new Engine();

            int engineTypeValue = 1;

            engine.EngineType = (EngineType)engineTypeValue;
            Console.WriteLine(engine.EngineType);

            var engineTypeString = "Electric";

            if (Enum.TryParse(engineTypeString, out EngineType engineType))
            {
                Console.WriteLine(engineType);
            }
        }

        static void Main(string[] args)
        {
            var newCar = Factory.BuildWithType<Car>(new Manufacturer());

            var car = Factory.Build<Car>(new Manufacturer() { Name = "VM" });
            //car?.Drive();

            var truck = Factory.Build<Truck>(new Manufacturer() { Name = "Daimler" });
            //if (truck != null)
            //{
            //    truck.Drive();
            //}

            var vehicles = new Dictionary<string, Car>();
            vehicles.Add("gti", newCar);
            vehicles.Add("gti1", newCar);

            if(vehicles.ContainsKey("gti"))
            {
                var result = vehicles["gti"];
            }

            if(vehicles.TryGetValue("gti", out Car? foundCar))
            {
                Console.WriteLine(foundCar);
            }

            foreach(var item in vehicles)
            {
                //item.Value.Drive();
                Console.WriteLine( item.Value.GetType().FullName);
                Console.WriteLine( item.Key);
            }

            //Vehicles();
            return;

            CreateEngine();
        }



        private static void DriveVehicles()
        {
            Car gti = new Car(new Manufacturer() { Name = "VW" })
            {
                Model = "test"
            };
            gti.DoSomething();

            var manufacturerBmw = new Manufacturer
            {
                Name = "BMW",
            };

            Manufacturer manufacturerVM = new();

            gti.Model = "abc";
            gti.Drive();

            Truck truck = new(manufacturerVM);
            truck.Model = "abc";
            truck.Charge = 2;

            Vehicle vehicle1 = new Car(manufacturerVM);
            Vehicle vehicle2 = new Truck(manufacturerVM);

            var list = new List<Vehicle>();
            list.Add(vehicle1);
            list.Add(vehicle2);
            list.Add(new Truck(manufacturerVM));

            var enumerator = list.GetEnumerator();
            while (enumerator.MoveNext())
            {
                if (enumerator.Current == null)
                {
                    continue;
                }

                //Console.WriteLine(enumerator.Current.GetType().FullName);
                Console.WriteLine(enumerator.Current.ToString());

                if (enumerator.Current.GetType() == typeof(Car))
                {
                    Car car = (Car)enumerator.Current;
                    Console.WriteLine($"Car: {car.ToString()}");
                }
                else if (enumerator.Current is Truck)
                {
                    Truck? truck1 = enumerator.Current as Truck;
                    Console.WriteLine($"Truck: {truck1?.ToString()}");

                }

            }


            IDriveable driveableTruck = new Truck(manufacturerVM);

            var listDriveable = new List<IDriveable>();
            listDriveable.Add(vehicle1);
            listDriveable.Add(vehicle2);
            listDriveable.Add(new Truck(manufacturerVM));
            //driveableTruck.

        }
    }
}