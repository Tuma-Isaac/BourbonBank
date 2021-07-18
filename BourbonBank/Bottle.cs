using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BourbonBank
{
    class Bottle
    {
        [JsonProperty("Name")]
        public string Name { get; set; }
        [JsonProperty("Distillery")]
        public string Distillery { get; set; }
        [JsonProperty("Size")]
        public double Size { get; set; }
        [JsonProperty("Proof")]
        public double Proof { get; set; }
        [JsonProperty("Age")]
        public string Age { get; set; }
        [JsonProperty("MSRP")]
        public int MSRP { get; set; }
        [JsonProperty("SecondaryPrice")]
        public int SecondaryPrice { get; set; }
        [JsonProperty("BottlesOwned")]
        public int BottlesOwned { get; set; }
    }
}
