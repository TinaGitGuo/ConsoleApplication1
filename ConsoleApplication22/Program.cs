using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication22
{
    class Program
    {
        static void Main(string[] args)
        {
            Object b = new Object();
            Object cst2 = b;
            Object c = 6;
            Object c1 = c;
            object a = new object();
            object cst = a;
            a = 6;
            Console.WriteLine(a + " " + cst);
            a = "klm";
            Console.WriteLine(a + " " + cst);

        }
    }
}
