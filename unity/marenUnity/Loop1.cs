using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Giraffe
{
    class Loop1
    {
        static void Main1(string[] args)
        {
            // int i = 1;
            // while (i <= 5)
            //  {
            //     Console.WriteLine(i);
            //     i++;
            //  }
            int[] luckynumbers = { 4, 8, 15, 16, 23, 42 };
            for (int i = 0; i < luckynumbers.Length; i++) 
            {
                Console.WriteLine(luckynumbers[i]);
            }
            Console.ReadLine();
        }
    }
}

