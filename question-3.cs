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
                var input=Console.ReadLine();
                var numbers=input.Split(',');
                var lengthOfNumbers=numbers.Length;
                if(lengthOfNumbers<5)
                {
                    Console.WriteLine("Entered list is invalid...Try again");
                }
                else
                {
                    var integerArray=new int[lengthOfNumbers];
                    for(var i=0;i<lengthOfNumbers;i++)
                    {
                        integerArray[i]=Convert.ToInt32(numbers[i]);
                    }
                    Array.Sort(integerArray);
                    Console.WriteLine("Three smallest numbers are:");
                    for(var i=0;i<3;i++)
                    {
                        Console.WriteLine(integerArray[i]);
                    }    
                    break;
                }
            }
        }
    }
}