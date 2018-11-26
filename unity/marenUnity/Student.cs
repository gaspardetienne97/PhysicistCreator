using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Giraffe
{
    class StudentProgram
    {
        static void Main1(string[] args)
        {
            Student student1 = new Student("Emily","Astro",2.8);
            Console.WriteLine(student1.gpa);

            Student student2 = new Student("Max","Art",3.6);
            Console.WriteLine(student2.gpa);

            Console.WriteLine(student1.HasHonors());
            Console.WriteLine(student2.HasHonors());

            Console.ReadLine();
        }
    }
}
