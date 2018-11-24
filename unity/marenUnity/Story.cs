using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Giraffe
{
    class Story
    {
        static void Main1(string[] args)
        {
            string characterName = "John";
            int characterAge;
            characterAge = 35;

            Console.WriteLine("My son went to the moon. His name is " + characterName + ".");
            Console.WriteLine("He is " + characterAge + " years old.");
            characterAge = 20;
            Console.WriteLine("He is " + characterAge + " years old.");
            Console.ReadLine();
        }
    }
}
