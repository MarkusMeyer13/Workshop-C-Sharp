using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace VehicleFactory
{
    public class Engine
    {
        [JsonProperty("Type")]
        public EngineType? EngineType { get; set; }
        public int? HorsePower { get; set; }

        [NotMapped]
        public double? Power
        {
            get
            {
                return HorsePower * 0.7355;
            }
        }
    }
    public class ElectricEngine : Engine
    {

    }

    public class EngineFactory
    {
        public static Engine Build(EngineType engineType)
        {
            if (engineType == EngineType.Electric)
            {
                return new ElectricEngine();
            }

            return null;
        }
    }
}
