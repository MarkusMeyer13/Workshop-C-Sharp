using System;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using VehicleFactory;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections;
using System.Data.SqlClient;
using System.Data;

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

        private static void Build()
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

            if (vehicles.ContainsKey("gti"))
            {
                var result = vehicles["gti"];
            }

            if (vehicles.TryGetValue("gti", out Car? foundCar))
            {
                Console.WriteLine(foundCar);
            }

            foreach (var item in vehicles)
            {
                //item.Value.Drive();
                Console.WriteLine(item.Value.GetType().FullName);
                Console.WriteLine(item.Key);
            }

        }

        private static void LinqQueries()
        {
            var manufacturers = new List<Manufacturer>();

            var manufacturerVW = new Manufacturer() { Name = "VW" };
            manufacturers.Add(manufacturerVW);

            var manufacturerBmw = new Manufacturer() { Name = "BMW" };
            manufacturers.Add(manufacturerBmw);
            manufacturers.Add(manufacturerBmw);

            var manufacturerMercedes = new Manufacturer() { Name = "Mercedes" };
            manufacturers.Add(manufacturerMercedes);

            var manufacturerFound = from manufacturer in manufacturers
                                        //where manufacturer.Name.Contains("M")
                                    select manufacturer;
            Console.WriteLine(manufacturers.Distinct().Count());

            var distinctManufacturers = manufacturers
                .GroupBy(_ => _.Name)
                .Select(_ => _.First())
                .OrderBy(_ => _.Name)
                .FirstOrDefault();
            //.ToList();

            var gti = new Car(manufacturerVW) { Engine = new Engine() { HorsePower = 10 } };
            var cClass = new Car(manufacturerMercedes) { Engine = new Engine() { HorsePower = 25 } };
            var cars = new List<Car>();
            cars.Add(gti);
            cars.Add(gti);
            cars.Add(cClass);

            var totalHorsePower = cars
                 .Where(_ => _.Manufacturer != null &&
            _.Manufacturer.Name == "VW")
                 .Select(_ => _.Engine?.HorsePower)
                 .Sum();

            Console.WriteLine(totalHorsePower);
        }


        private static void SelectSqlDataSet()
        {
            var connectionString = "Server=tcp:workshop-csharp.database.windows.net,1433;Initial Catalog=markusm;Persist Security Info=False;User ID=workshop;Password=kveOxZEL!gzSWJoItmex;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
            SqlConnection connection = new SqlConnection(connectionString);
            var result = new List<Manufacturer>();
            try
            {
                connection.Open();
                var query = $"SELECT * FROM Manufacturer";

                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);

                DataSet manufacturers = new DataSet();
                adapter.Fill(manufacturers, "Manufacturer");

                Manufacturer manufacturer = new Manufacturer();
                manufacturer.Name = manufacturers.Tables["Manufacturer"].Rows[0][1].ToString();
                Console.WriteLine(manufacturers.Tables[0].Rows.Count);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        private static void InsertSqlData()
        {
            var connectionString = "Server=tcp:workshop-csharp.database.windows.net,1433;Initial Catalog=markusm;Persist Security Info=False;User ID=workshop;Password=kveOxZEL!gzSWJoItmex;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                connection.Open();
                var query = "INSERT INTO Manufacturer (Name) VALUES (@ManufacturerName)";

                SqlCommand sqlCommand = connection.CreateCommand();
                sqlCommand.CommandText = query;
                SqlParameter sqlParameter = new SqlParameter("@ManufacturerName", "Mercedes");
                //sqlParameter.Direction = ParameterDirection.Input;
                sqlCommand.Parameters.Add(sqlParameter);

                var result = sqlCommand.ExecuteNonQuery();
                Console.WriteLine(result);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        private static void SelectSqlData()
        {
            string manufacturerName = "VW";

            var connectionString = "Server=tcp:workshop-csharp.database.windows.net,1433;Initial Catalog=markusm;Persist Security Info=False;User ID=workshop;Password=kveOxZEL!gzSWJoItmex;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
            SqlConnection connection = new SqlConnection(connectionString);
            var result = new List<Manufacturer>();
            try
            {
                connection.Open();
                var query = $"SELECT * FROM Manufacturer WHERE Name = @ManufacturerName";

                SqlCommand sqlCommand = connection.CreateCommand();

                //var paramManufacturerName = new SqlParameter("@ManufacturerName", SqlDbType.VarChar, 50);
                //paramManufacturerName.Value = manufacturerName;

                var paramManufacturerName = new SqlParameter("@ManufacturerName", manufacturerName);

                sqlCommand.Parameters.Add(paramManufacturerName);

                sqlCommand.CommandText = query;

                using var reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    Console.WriteLine($"{reader.GetInt32(0)} - {reader.GetString(1)}");
                    Manufacturer manufacturer = new Manufacturer();
                    manufacturer.Id = reader.GetInt32(0);
                    manufacturer.Name = reader.GetString(1);

                    result.Add(manufacturer);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                connection.Close();
            }

            Console.WriteLine(result.Count);
        }

        private static void DoSomething(
            IReadOnlyList<Manufacturer> list
            , IEnumerable<Manufacturer> enumerable)
        {
            foreach (Manufacturer manufacturer in enumerable) { }
        }

        private static void EfData()
        {
            VehicleFactoryContext vehicleFactoryContext = new VehicleFactoryContext();

            //var first = vehicleFactoryContext.Manufacturer.ToList()[0];
            //vehicleFactoryContext.Manufacturer.Remove(first);

            vehicleFactoryContext.Manufacturer.Add(new Manufacturer() { Name = "abc" });
            vehicleFactoryContext.SaveChanges();


            var manufacturers = vehicleFactoryContext.Manufacturer
                .Where(_ => !string.IsNullOrEmpty(_.Name)
                && _.Name.Contains("v"));

            //DoSomething(manufacturers.ToList(), manufacturers);


            var list = manufacturers.ToList();
            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine(list[i].Name);
            }


            //var enumerator = manufacturers.GetEnumerator();
            //while (enumerator.MoveNext())
            //{
            //    _ = enumerator.Current.Name;
            //}

            //foreach (var manufacturer in manufacturers)
            //{
            //    Console.WriteLine(manufacturer.Name);
            //}
        }

        static void Main(string[] args)
        {
            EfData();
            //SelectSqlDataSet();
            //InsertSqlData();
            //SelectSqlData();
            //WorkingWithJson();

            ////Vehicles();
            return;

            CreateEngine();
        }

        private static void WorkingWithJson()
        {
            string fileName = "VehicleFactory.data.Engine.json";
            var resourceStream = typeof(Engine).Assembly.GetManifestResourceStream(fileName);

            if (resourceStream != null)
            {
                using StreamReader reader = new StreamReader(resourceStream);
                string text = reader.ReadToEnd();
                Console.WriteLine(text);
            }

            var path = ".\\Cars.json";
            var json = File.ReadAllText(path);


            //var json = "[ { \"Model\": \"test\", \"Manufacturer\": { \"Name\": \"VW\" }, \"Engine\": { \"Type\": null, \"HorsePower\": 10 } }, { \"Model\": null, \"Manufacturer\": { \"Name\": \"BMW\" }, \"Engine\": { \"Type\": null, \"HorsePower\": 10 } } ] ";

            var data = JArray.Parse(json);
            for (int i = 0; i < data.Count; i++)
            {
                JObject obj = (JObject)data[i];

                Console.WriteLine(obj["Model"]);
            }

            Engine engine = new Engine() { HorsePower = 10, EngineType = EngineType.Electric };
            var jsonDocument = JsonConvert.SerializeObject(engine);

            //var manufacturerVW = new Manufacturer() { Name = "VW" };
            //var gti = new Car(manufacturerVW) { Engine = new Engine() { HorsePower = 10 } };



            ////var engine2 = JsonConvert.DeserializeObject<Engine>(jsonDocument);  
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