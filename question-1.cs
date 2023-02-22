using System;

namespace Question_1
{
    class Program
    {
        static void Main(string[] args)
        {
            var finalResult=0;
            Console.WriteLine("Enter any number to add to the result, or enter \"ok\" to Exit");
            while(true)
            {
                var input=Console.ReadLine();
                if (input=="ok"){
                    break;
                }
                finalResult+=Convert.ToInt32(input);
                Console.WriteLine("You can enter more numbers to add, or \"ok\" to Exit");

            }
            Console.WriteLine("Sum of numbers entered till now = "+ finalResult);
        }
    }
}