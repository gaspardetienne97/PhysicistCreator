using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Giraffe
{
    class Max
    {
        static void Main1(string[] args)
        {
            int MaxNum = Max1(20, 4);
            Console.WriteLine(MaxNum);
            Console.ReadLine();
        }
        static int Max1(int num1, int num2)
        {
            if (num1 > num2) 
            {
                return num1;
            } else 
            {
                return num2;
            }
        }
    }
}