using System;

namespace Question_2
{
    class Program
    {
        static void Main(string[] args)
        {
            int max = 0;
            Console.WriteLine("Enter comma separated numbers");
            var input = Console.ReadLine();
            var numbers =input.Split(',').Select(int.Parse).ToArray();
            Array.Sort(numbers);
            Console.WriteLine("Max = " + numbers[numbers.Length-1]);
        }
    }
}