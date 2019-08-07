using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.SpaceshipCrafting
{
    public class SpaceshipCrafting
    {
        private static void Main()
        {
            Queue<int> liquids = new Queue<int>(Console.ReadLine()
                .Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList());

            Stack<int> items = new Stack<int>(Console.ReadLine()
                .Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList());

            var data = new Dictionary<int, string>()
            {
                {50, "Aluminium" },
                {75, "Lithium" },
                {100, "Carbon fiber" },
                {25, "Glass"}
            };

            List<string> madeItems = new List<string>();

            while (liquids.Count != 0 && items.Count != 0)
            {
                int currentChemicalLiquid = liquids.Dequeue();
                int currentPhysicalItem = items.Pop();

                int sum = currentChemicalLiquid + currentPhysicalItem;

                if (data.ContainsKey(sum))
                {
                    madeItems.Add(data[sum]);
                }
                else
                {
                    items.Push(currentPhysicalItem + 3);
                }
            }

            if (madeItems.Contains("Lithium") &&
                madeItems.Contains("Carbon fiber") &&
                madeItems.Contains("Glass") &&
                madeItems.Contains("Aluminium"))
            {
                Console.WriteLine("Wohoo! You succeeded in building the spaceship!");
            }
            else
            {
                Console.WriteLine("Ugh, what a pity! You didn't have enough materials to build the spaceship.");
            }

            if (liquids.Count != 0)
            {
                Console.WriteLine($"Liquids left: {string.Join(", ", liquids)}");
            }
            else
            {
                Console.WriteLine("Liquids left: none");
            }

            if (items.Count != 0)
            {
                Console.WriteLine($"Physical items left: {string.Join(", ", items)}");
            }
            else
            {
                Console.WriteLine("Physical items left: none");
            }

            Console.WriteLine($"Aluminium: {madeItems.Count(x => x == "Aluminium")}");
            Console.WriteLine($"Carbon fiber: {madeItems.Count(x => x == "Carbon fiber")}");
            Console.WriteLine($"Glass: {madeItems.Count(x => x == "Glass")}");
            Console.WriteLine($"Lithium: {madeItems.Count(x => x == "Lithium")}");
        }
    }
}