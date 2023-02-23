using System;

namespace Question_3
{
    class Program
    {
        static void Main(string[] args)
        {
            while(true)
            {
                Console.WriteLine("Enter comma separated numbers");
                var numbers = Console.ReadLine().Split(',').Select(int.Parse).ToArray();
                var lengthOfNumbers = numbers.Length;
                if (lengthOfNumbers < 5)
                {
                    Console.WriteLine("Entered list is invalid...Try again");
                }
                else
                {
                    Array.Sort(numbers);
                    Console.WriteLine("Three smallest numbers are:");
                    Console.WriteLine(String.Format("{0} {1} {2}", numbers[0], numbers[1] , numbers[2]));
                    break;
                }
            }
        }
    }
}