using System;
namespace Question_4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter comma separated numbers");
            var numbers = Console.ReadLine().Split(',').Select(int.Parse).ToArray();
            var lengthOfNumbers = numbers.Length;
            Array.Sort(numbers);
            Array.Reverse(numbers);
            Console.WriteLine("Reverse Sorted Array:");
            for (var i = 0; i < lengthOfNumbers; i++)
            {
                Console.Write(String.Format("{0} ", numbers[i]));
            }
        }
    }
}