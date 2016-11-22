using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication9
{
    class Program
    {
        static void Main(string[] args)
        {
            //    string filePath = Environment.ExpandEnvironmentVariables("%windir%");
            //    if (!filePath.Trim().EndsWith(@"\"))
            //        filePath += @"\";
            //    filePath += @"System32\Kernel32.dll";
            //  string filePath = @"C:\Users\Tina\Downloads\iPhone Info_MSDN (3)\Demo\bin\Debug\iTunesMobileDevice.dll";
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
