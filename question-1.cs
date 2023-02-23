using System;

namespace Question_1
{
    class Program
    {
        static void Main(string[] args)
        {
            var finalResult = 0;
            while (true)
            {
                Console.WriteLine("Enter any number to add to the result, or enter \"ok\" to Exit");
                var input = Console.ReadLine();
                if (input.ToLower() == "ok")
                {
                    break;
                }
                finalResult += Convert.ToInt32(input);
            }
            Console.WriteLine("Sum of numbers entered till now = "+ finalResult);
        }
    }
}