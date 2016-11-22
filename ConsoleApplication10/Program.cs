using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
 
namespace ConsoleApplication10
{
    class Program
    {
        static void Main(string[] args)
        {
        
            string filePath = @"F:\iTunesMobileDevice.dll";
            try
            {
                Assembly assem = Assembly.LoadFile(filePath);
            }
            catch (BadImageFormatException e)
            {
                Console.WriteLine(e.Message);
                //Console.WriteLine("Unable to load {0}.", filePath);
                //Console.WriteLine(e.Message.Substring(0,
                //                  e.Message.IndexOf(".") + 1));
            }
            Console.WriteLine("///");
            Console.ReadKey();
        }
    }
}
