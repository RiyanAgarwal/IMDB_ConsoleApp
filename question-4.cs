using System;

namespace Question_3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter comma separated numbers");
            var input=Console.ReadLine();
            var numbers=input.Split(',');
            var lengthOfNumbers=numbers.Length;
            var integerArray=new int[lengthOfNumbers];
            for(var i=0;i<lengthOfNumbers;i++)
                {
                    integerArray[i]=Convert.ToInt32(numbers[i]);
                }
            Array.Sort(integerArray);
            Console.WriteLine("Sorted Array:");
            for(var i=lengthOfNumbers-1;i>-1;i--)
            { 
                Console.Write(String.Format("{0} ",integerArray[i]));
            }
        }
    }
}