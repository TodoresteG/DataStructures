namespace Problem4.RemoveOddOccurrences
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

            // Linear complexity O(n)
            var numberOccurrencies = new Dictionary<int, int>();

            for (int i = 0; i < input.Count; i++)
            {
                if (!numberOccurrencies.ContainsKey(input[i]))
                {
                    numberOccurrencies.Add(input[i], 0);
                }

                numberOccurrencies[input[i]]++;
            }

            for (int i = 0; i < input.Count; i++)
            {
                if (numberOccurrencies[input[i]] % 2 == 0)
                {
                    Console.Write(input[i] + " ");
                }
            }

            // n * n complexity
            //for (int i = 0; i < input.Count; i++)
            //{
            //    int count = 0;

            //    for (int j = 0; j < input.Count; j++)
            //    {
            //        if (input[j] == input[i])
            //        {
            //            count++;
            //        }
            //    }

            //    if (count % 2 == 0)
            //    {
            //        Console.Write(input[i] + " ");
            //    }
            //}

            Console.WriteLine();
        }
    }
}
