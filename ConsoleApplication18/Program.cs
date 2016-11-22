using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication18
{
    class Program
    {
        static void Main(string[] args)
        {
        }
        public static string GetFileStr(string path)
        {
            string str = "";
            using (StreamReader sr = new StreamReader(GetPath(path)))
            {
                sr.BaseStream.Seek(0, SeekOrigin.Begin);
                str = sr.ReadToEnd();
            }
            return str;
        }

    }
}
