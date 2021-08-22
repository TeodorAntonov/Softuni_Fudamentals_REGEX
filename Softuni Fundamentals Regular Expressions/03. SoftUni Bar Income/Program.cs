using System;
using System.Linq;
using System.Numerics;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Tryouts
{
    class Program
    {
        static void Main(string[] args)
        {

            Regex pattern = new Regex(@"^%(?<customer>[A-Z][a-z]+)%[^|$%.]*<(?<product>\w+)>[^|$%.]*\|(?<count>\d+)\|[^|$%.]*?(?<price>[-+]?[0-9]*\.?[0-9]+([eE][-+]?[0-9]+)?)\$");

            string input = Console.ReadLine();
            double totalSum = 0;

            while (input != "end of shift")
            {
                // Match match = pattern.Match(input);

                if (pattern.IsMatch(input))
                {
                    Match match = pattern.Match(input);
                    string customer = match.Groups["customer"].Value;
                    string product = match.Groups["product"].Value;
                    int quantity = int.Parse(match.Groups["count"].Value);
                    double price = double.Parse(match.Groups["price"].Value);

                    double result = quantity * price;

                    Console.WriteLine($"{customer}: {product} - {result:f2}");

                    totalSum += result;

                }

                input = Console.ReadLine();
            }

            Console.WriteLine($"Total income: {totalSum:f2}");
        }
    }
}