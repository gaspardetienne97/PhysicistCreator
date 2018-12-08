using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Giraffe
{
    class Calculator
    {
        static void Main1(string[] args)
        {
            Console.WriteLine("Enter a number:");
            double num1 = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Enter an opperator:");
            char operatorchar = Convert.ToChar(Console.ReadLine());
            Console.WriteLine("Enter a number:");
            double num2 = Convert.ToDouble(Console.ReadLine());
            if (operatorchar == '+')
            {
                double answer = num1 + num2;
                Console.WriteLine(answer);
            }
            else if (operatorchar == '-')
            {
                double answer = num1 - num2;
                Console.WriteLine(answer);
            }
            else if (operatorchar == '*')
            {
                double answer = num1 * num2;
                Console.WriteLine(answer);
            }
            else if (operatorchar == '/')
            {
                double answer = num1 / num2;
                Console.WriteLine(answer);
            }
            else
                Console.WriteLine("Invalid Input");
            Console.ReadLine();
        }
    }
}
