namespace Problem3.LongestSubsequence
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    class Program
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();

            int counter = 1;

            int bestSequence = 0;
            int bestNum = 0;

            for (int i = 0; i < numbers.Count - 1; i++)
            {

                if (numbers[i] == numbers[i + 1])
                {
                    counter++;
                }
                else
                {
                    counter = 1;
                }

                if (bestSequence < counter)
                {
                    bestSequence = counter;
                    bestNum = numbers[i];
                }
            }

            for (int i = 0; i < bestSequence; i++)
            {
                Console.Write(bestNum + " ");
            }

            Console.WriteLine();
        }
    }
}
