using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_2
{
    public class program
    {
        static void Main(string[] args)
        {
            var calc = new Calculator();
            var sumOfTwoInt = calc.Add(12, 6);
            Console.WriteLine("sum of two integers = " + Convert.ToString(sumOfTwoInt));
            Console.WriteLine("value of result in Calculator class = " + Convert.ToString(calc.GetResult()));

            var sumOfThreeInt = calc.Add(6, 88, 2);
            Console.WriteLine("sum of three integers = " + Convert.ToString(sumOfThreeInt));
            Console.WriteLine("value of result in Calculator class = " + Convert.ToString(calc.GetResult()));


            var sumOfFloat = calc.Add(13.6f, 44.8f);
            Console.WriteLine("sum of two floats = " + Convert.ToString(sumOfFloat));
            
            

            Console.WriteLine("value of result in Calculator class = " + Convert.ToString(calc.GetResult()));
            var advCalc = new AdvanceCalculator();
            var power = advCalc.Power(3, 5);
            Console.WriteLine("result of power method = " + Convert.ToString(power));
            Console.WriteLine("value of result in AdvanceCalculator class = " + Convert.ToString(advCalc.GetResult()));

        }
    }
}