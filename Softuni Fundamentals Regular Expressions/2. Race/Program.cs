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
            Dictionary<string, int> participats = new Dictionary<string, int>();
            Regex letters = new Regex(@"[A-Za-z]");
            Regex numbers = new Regex(@"[0-9]");

            string[] players = Console.ReadLine().Split(", ");

            foreach (var item in players)
            {
                participats.Add(item, 0);
            }

            string commnad = Console.ReadLine();

            while (commnad != "end of race")
            {
                string currentName = string.Empty;

                MatchCollection matchLetters = letters.Matches(commnad);
                foreach (Match item in matchLetters)
                {
                    currentName += item;
                }

                if (!participats.ContainsKey(currentName))
                {
                    commnad = Console.ReadLine();
                    continue;
                }

                MatchCollection matchNumbers = numbers.Matches(commnad);
                int numArr = 0;

                foreach (Match item in matchNumbers)
                {
                    numArr += int.Parse(item.Value);
                }

                participats[currentName] += numArr;

                commnad = Console.ReadLine();
            }

            int count = 1;
            foreach (var item in participats.OrderByDescending(x => x.Value))
            {
                if (count == 1)
                {
                    Console.WriteLine($"{count}st place: {item.Key}");
                }
                else if (count == 2)
                {
                    Console.WriteLine($"{count}nd place: {item.Key}");
                }
                else if (count == 3)
                {
                    Console.WriteLine($"{count}rd place: {item.Key}");
                }
                count++;
            }
        }
    }
}