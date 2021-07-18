using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using static BourbonBank.BottleFunctions;

namespace BourbonBank
{
    class Program
    {
        static void Main(string[] args)
        {
            
            string fileName = @"C:\Users\tumai\source\repos\BourbonBank\BourbonBank\BourbonCollection.json";
            string path = Path.Combine(Environment.CurrentDirectory, @"Data\", fileName);
            var bottles = LoadBottles(path);
            
            //Cosmetic stuff            
            Console.BackgroundColor = ConsoleColor.DarkRed;
            Console.Clear();
            
            // List of options           
            StringBuilder options = new StringBuilder();
            options.Append("\n");
            options.Append("\n             Welcome to the Bourbon Bank               ");
            options.Append("\n*******************************************************");
            options.Append("\n*  To view the current collection, press 1            *");
            options.Append("\n*  To add a new bottle, press 2                       *");
            options.Append("\n*  To update a current bottle, press 3                *");
            options.Append("\n*  To remove a bottle, press 4                        *");
            options.Append("\n*  To calculate the value of the collection, press 5  *");
            options.Append("\n*  Type quit to quit                                  *");
            options.Append("\n*******************************************************");
            
            while (true)
            {
                try
                {
                    Console.WriteLine(options);
                    var response = Console.ReadLine();
                    int intParse;
                    double doubleParse;
                    if (response.ToLower() == "quit")
                    {
                        break;
                    }
                    // View current collection
                    else if (Int32.Parse(response) == 1)
                    {
                        PrintBottles(bottles);                    
                        continue;
                    }
                    // Add a new bottle to the collection
                    else if (Int32.Parse(response) == 2)
                    {
                        var bottle = new Bottle();
                        Console.WriteLine("Please enter the name of the bottle.");
                        bottle.Name = Console.ReadLine();
                        Console.WriteLine("Please enter the Distillery name");
                        bottle.Distillery = Console.ReadLine();

                        Console.WriteLine("Please enter the size of the bottle in ml/L.");
                        if (double.TryParse(Console.ReadLine(), out doubleParse))
                        {
                            bottle.Size = doubleParse;
                        }
                        Console.WriteLine("Please enter the bottles proof.");
                        if (double.TryParse(Console.ReadLine(), out doubleParse))
                        {
                            bottle.Proof = doubleParse;
                        }
                        Console.WriteLine("Please enter the bottles age. If the age is unknown, please enter NAS for No Age Statement.");
                        bottle.Age = Console.ReadLine();
                        Console.WriteLine("Please enter the MSRP value.");
                        if (Int32.TryParse(Console.ReadLine(), out intParse))
                        {
                            bottle.MSRP = intParse;
                        }
                        Console.WriteLine("Please enter the secondary value.");
                        if (Int32.TryParse(Console.ReadLine(), out intParse))
                        {
                            bottle.SecondaryPrice = intParse;

                        }
                        Console.WriteLine("Please enter the number of bottles you own");
                        if (Int32.TryParse(Console.ReadLine(), out intParse))
                        {
                            bottle.BottlesOwned = intParse;
                        }
                        bottles.Add(bottle);
                        SaveBottles(bottles, path);
                        continue;
                    }
                    // Update an existing bottle count
                    else if (Int32.Parse(response) == 3)
                    {
                        var amountofBottles = 0;
                        Console.WriteLine("Which bottle would you like to update?");
                        var updatedBottle = Console.ReadLine();
                        Console.WriteLine("How many bottles would you like to add or subtract? Type - for subtraction.");
                        if (Int32.TryParse(Console.ReadLine(), out intParse)) { amountofBottles = intParse; }
                        UpdateBottle(updatedBottle, amountofBottles, bottles);
                        SaveBottles(bottles, path);
                        continue;
                    }
                    // Remove a bottle from collection
                    else if (Int32.Parse(response) == 4)
                    {
                        Console.WriteLine("What bottle would you like to remove from the collection?");
                        var bottleRemoved = Console.ReadLine();
                        var remove = bottles.SingleOrDefault(b => b.Name == bottleRemoved);
                        if (remove != null) bottles.Remove(remove);
                        SaveBottles(bottles, path);
                        continue;
                    }
                    // Calculate value of collection
                    else if (Int32.Parse(response) == 5)
                    {
                        CalcValue(path);
                        continue;
                    }                                  
                }
                catch (FormatException)
                {
                    Console.WriteLine("Please enter a valid input.");
                }
            }
        }

    }
}
