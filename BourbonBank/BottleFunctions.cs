using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BourbonBank
{
    class BottleFunctions
    {

        // Load list of bottles from Json
        public static List<Bottle> LoadBottles(string filepath)
        {
            try
            {
                string jsonString = File.ReadAllText(filepath);
                var bottle = JsonConvert.DeserializeObject<List<Bottle>>(jsonString);
                return bottle;
            }
            catch
            {
                Console.WriteLine("No data to load.");
            }
            return new List<Bottle>();
        }

        // Save list of bottles to Json
        public static void SaveBottles(List<Bottle> bottle, string filepath)
        {
            string jsonString = JsonConvert.SerializeObject(bottle, Formatting.Indented);
            File.WriteAllText(filepath, jsonString);
        }

        // Print bottles to console
        public static void PrintBottles(List<Bottle> bottles)
        {
            IEnumerable<Bottle> bottleOrder = bottles.OrderBy(b => b.Distillery);
            foreach (var bottle in bottleOrder)
            {
                Console.WriteLine("{0}, {1}, {2}, {3}, {4}, {5}, {6}, {7}", bottle.Name, bottle.Distillery, bottle.Size, bottle.Proof, bottle.Age, bottle.MSRP, bottle.SecondaryPrice, bottle.BottlesOwned);
            }
        }
        // Update Existing Bottle in collection
        public static void UpdateBottle(string Name, int amount, List<Bottle> bottles) 
        {
            foreach (var bottle in bottles)
            {
                if (bottle.Name.ToLower() == Name.ToLower())
                {
                    bottle.BottlesOwned += amount;
                }
            }
        }
        // Calculate the value of the collection
        public static void CalcValue(string filepath)
        {
            int msrpValue = 0;
            int secondaryValue = 0;
            var bottles = LoadBottles(filepath);

            foreach (var bottle in bottles)
            {
                var bottleCount = bottle.BottlesOwned;
                if (bottleCount > 1)
                {
                    bottle.MSRP = bottle.MSRP * bottleCount;
                    bottle.SecondaryPrice = bottle.SecondaryPrice * bottleCount;
                }

                msrpValue += bottle.MSRP;
                secondaryValue += bottle.SecondaryPrice;
            }
            Console.WriteLine($"The MSRP value of your collection is: ${msrpValue}");
            Console.WriteLine($"The secondary value of your collection is: ${secondaryValue}");

        }

        

    }
}
