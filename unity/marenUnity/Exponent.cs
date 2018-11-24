using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Giraffe
{
    class Exponent
    {
        static void Main1(string[] args)
        {
            Console.WriteLine("Enter A Number:");
            int baseNum = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter A Number:");
            int powNum = Convert.ToInt32(Console.ReadLine());
            int result = GetPow(baseNum, powNum);
            Console.WriteLine(result);

        }
        static int GetPow(int baseNum, int powNum)
        {
            int result = 1;
            for (int i = 0; i < powNum; i++)
            {
                result = result * baseNum;
            }

            return result;
        }
    }
}


