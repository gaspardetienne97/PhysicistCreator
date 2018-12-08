using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Giraffe
{
    class Cube1
    {
        static void Main1(string[] args)
        {
            int CubedNum = Cube(3);
            Console.WriteLine(CubedNum);
            Console.ReadLine();
        }
        static int Cube(int num)
        {
            int result = num * num * num;
            return result;
        }
    }
}