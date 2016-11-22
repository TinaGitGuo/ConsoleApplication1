 

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace WebApplication9
{
    //[ComVisible(true)]  // This is mandatory.
    //[Guid("4945B34B-1B63-4a58-B5FE-9627FEFAEA9D")]
    //[InterfaceType(ComInterfaceType.InterfaceIsDual)]
    public interface IInterface01
    {
        void Method01();

        string string_property
        {
            get;
            set;
        }

        void test(string a, ref string b);
        

       
    }

    //[ComVisible(true)]  // This is mandatory.
    //[Guid("36E6BC94-308C-4952-84E6-109041990EF7")]
    //[ProgId("CSCOMServer.CSCOMClass01")]
    //[ClassInterface(ClassInterfaceType.None)]
    public class CSCOMClass01 : IInterface01
    {
        // A default public constructor is also mandatory.
        public CSCOMClass01()
        {
        }

        ~CSCOMClass01()
        {
        }

        public void Method01()
        {
            Console.WriteLine("Method01().");
        }

        public string string_property
        {
            get
            {
                return m_string_property;
            }

            set
            {
                m_string_property = value;
            }
        }
       public void test(string a, ref string b)
        {

        }
        private string m_string_property;
    }
}