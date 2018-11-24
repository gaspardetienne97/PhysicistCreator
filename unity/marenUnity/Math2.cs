using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Giraffe
{
    class Math2
    {
        static void Main1(string[] args)
        {
            Console.WriteLine("Enter a number:");
            double num1 = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Enter another number:");
            double num2 = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine(num1 + num2);
            Console.ReadLine();
        }
    }
}