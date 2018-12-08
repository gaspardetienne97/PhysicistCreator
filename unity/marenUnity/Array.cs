using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Giraffe
{
    class Array
    {
        static void Main1(string[] args)
        {
            int[] luckynumbers = {4,8,15,16,23,42};
            luckynumbers[1] = 900;
            string[] friends = new string[5];
            friends[0] = "Matt";
            friends[1] = "Sarah";
            Console.WriteLine(luckynumbers[2]);
            Console.WriteLine(luckynumbers[1]);
            Console.WriteLine(friends[0]);
            Console.WriteLine(friends[3]);
            Console.ReadLine();
        }
    }
}