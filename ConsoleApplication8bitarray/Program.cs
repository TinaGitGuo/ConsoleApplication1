using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication8bitarray
{
    class Program
    {
        static void Main(string[] args)
        {
            int inta= 1;       
            BitArray myIa = new BitArray(inta);
            object obj = new object();
            long longtest = GetSpaceForObjectByFormatter(obj);
            Console.WriteLine(" The size of the space occupied:"+longtest + " , " + GetSpaceForObjectByFormatter(1)+ " ,  "+GetSpaceForObjectByFormatter(myIa));

            int[] intb = new int[5] { 1, 2, 3, 4, 5 };
            BitArray myIb = new BitArray(intb);
            //BitArray myIc = new BitArray();
            int a = myIa.Length;

            // byte[]  bytea = new byte[](inta);
            //BitArray wr = new BitArray( );

            //obj = "dsgjskdghsdkghsjkdghkdjkhgk43kjkfdkhjdkfjh";
            //longtest = GetSpaceForObjectByFormatter(obj);
            //obj += "aaafgfhdfhdfh";
            //    Console.WriteLine( inta.ToString().Length +"   " + intb.ToString().Length);



            string st = " int inta:" + GetSpaceForObjectByFormatter(inta) + "   BitArray myIa:" + GetSpaceForObjectByFormatter(myIa)
               + " int[] intb:" + GetSpaceForObjectByFormatter(intb) + "   BitArray myIb:" + GetSpaceForObjectByFormatter(myIb);
            Console.WriteLine(st);

            int size = Marshal.SizeOf(typeof(int)); //结果为4 
            //int size = Marshal.SizeOf(typeof(long)); //结果为8 
            //int size = Marshal.SizeOf(typeof(float)); //结果为4 
            //int size = Marshal.SizeOf(typeof(double)); //结果为8 

            ;
            Console.WriteLine(Marshal.SizeOf(typeof(MyObject)));
            //string str = " int inta:" + GetSpaceForObjectByReader(inta) + "   BitArray myIa:" + GetSpaceForObjectByReader(myIa)
            //  + " int[] intb:" + GetSpaceForObjectByReader(intb) + "   BitArray myIb:" + GetSpaceForObjectByReader(myIb);
            //Console.WriteLine(str);
            Console.ReadKey();

        }

        [StructLayout(LayoutKind.Sequential)]
        public class MyObject
        {
              public double x;
           // object x;
        }
        //static long GetSpaceForObjectByReader(object obj)
        //{
        //    MemoryStream memory = new MemoryStream();
        //    BinaryReader binrder = new BinaryReader(memory);

        //    memory.Position = 0;  ;
        //    return memory.Length;

        //}
        static long GetSpaceForObjectByFormatter(object obj)
        {
            MemoryStream memory = new MemoryStream();   
            BinaryFormatter bin = new BinaryFormatter();
            bin.Serialize(memory, obj);    //反序列化，将对象转化为流输出 在MemoryStream.
    //        byte[] a = memory.ToArray();
            
            memory.Position = 0; ;
            return memory.Length;
        }

    }
}
