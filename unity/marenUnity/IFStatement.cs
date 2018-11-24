using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Giraffe
{
    class IFStatement
    {
        static void Main1(string[] args)
        {
            bool isbaby = true;
            bool isMale = false;
            if (isbaby && isMale)
            {
                Console.WriteLine("It's A Boy!");
            } else if (isbaby || !isMale)
            {
                Console.WriteLine("It's A Girl!");
            } else
            {
                Console.WriteLine("It's NOT A Boy!");
            }
            bool one = true;
            bool theother = false;
            if (one || theother)
            {
                Console.WriteLine("Hello");
            }
            Console.ReadLine();
        }
    }
}