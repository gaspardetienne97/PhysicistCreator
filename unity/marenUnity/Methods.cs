using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Giraffe
{
    class Method
    {
        static void Main1(string[] args)
        {
            SayHi("Tom",20);
            Console.ReadLine();
        }
        static void SayHi(string name, int age)
        {
            Console.WriteLine("Hello " + name);
            Console.WriteLine("You are: " + age);
        }
    }
}