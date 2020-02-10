namespace LinearDataStructures
{
    using System;
    using System.Linq;

    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(x => int.Parse(x)).ToList();

            if (input.Count == 0)
            {
                Console.WriteLine("Sum=0; Average=0.00");
                return;
            }

            var sum = input.Sum();
            var average = input.Average();
            Console.WriteLine($"Sum={sum}; Average={average:f2}");
        }
    }
}
