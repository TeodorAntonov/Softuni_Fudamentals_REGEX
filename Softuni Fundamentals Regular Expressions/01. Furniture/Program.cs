﻿using System;
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
            Regex pattern = new Regex(@"^>>([A-Za-z]+)<<([0-9]+\.{0,1}[0-9]{0,})!([0-9]+)");

            string text = Console.ReadLine();
            decimal totalPrice = 0;

            Console.WriteLine("Bought furniture:");
            while (text != "Purchase")
            {
                Match match = pattern.Match(text);

                if (!match.Success)
                {
                    text = Console.ReadLine();
                    continue;

                }

                string productName = match.Groups[1].Value;
                decimal productPrice = decimal.Parse(match.Groups[2].Value);
                int productQuality = int.Parse(match.Groups[3].Value);

                totalPrice += productPrice * productQuality;
                Console.WriteLine(productName);
                text = Console.ReadLine();
            }

            Console.WriteLine($"Total money spend: {totalPrice:f2}");
        }
    }
}