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
            var numbers = input.Split(',');
            foreach (var number in numbers)
            {
                if ((max < Convert.ToInt32(number)))
                {
                    max = Convert.ToInt32(number);
                }
            }
            Console.WriteLine("Max = "+ max);
        }
    }
}