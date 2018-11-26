using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Giraffe
{
    class BookProgram
    {
        static void Main1(string[] args)
        {
            Book book1 = new Book("Harry Potter", "J. K. Rowling", 500);
            Console.WriteLine(book1.pages);

            Book book2 = new Book("Lord Of The Rings","J. R. R. Tolkien",700);
            Console.WriteLine(book2.pages);

            Console.ReadLine();
        }
    }
}
