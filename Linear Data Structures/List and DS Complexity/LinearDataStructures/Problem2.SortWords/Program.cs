namespace Problem2.SortWords
{
    using System;
    using System.Linq;

    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();

            Console.WriteLine(string.Join(" ", input.OrderBy(x => x)));
        }
    }
}
