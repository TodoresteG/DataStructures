namespace Problem5.CountOfOccurrences
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(x => int.Parse(x))
                .ToList();

            var countOfNumbers = new Dictionary<int, int>();

            foreach (var number in input)
            {
                if (!countOfNumbers.ContainsKey(number))
                {
                    countOfNumbers.Add(number, 0);
                }

                countOfNumbers[number]++;
            }

            foreach (var kvp in countOfNumbers.OrderBy(x => x.Key))
            {
                Console.WriteLine($"{kvp.Key} -> {kvp.Value} times");
            }
        }
    }
}
