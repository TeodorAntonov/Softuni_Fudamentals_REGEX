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
            string emailPattern = @"(?<=\s)([A-Za-z0-9]+[-._]*[A-Za-z0-9]+)@([A-Za-z0-9]+(([-.]*)[A-Za-z]+)*\.[a-z]{2,})";

            string input = Console.ReadLine();

            MatchCollection matchCol = Regex.Matches(input, emailPattern);

            foreach (Match item in matchCol)
            {
                Console.WriteLine(item.Value);
            }
        }
    }
}