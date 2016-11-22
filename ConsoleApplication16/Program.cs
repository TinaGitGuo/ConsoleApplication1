using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication16
{
    class Program
    {
        static void Main(string[] args)
        {

            byte[] messagebytes = Encoding.UTF8.GetBytes("Hello World");


            //byte[] messagebytes = Encoding.UTF8.GetBytes("Hello World");

            RSACryptoServiceProvider oRSA4ToKey = new RSACryptoServiceProvider();
            string privtekey = oRSA4ToKey.ToXmlString(true);
            string publickey = oRSA4ToKey.ToXmlString(false);


            RSACryptoServiceProvider oRSA4 = new RSACryptoServiceProvider();
            oRSA4.FromXmlString(privtekey);
            byte[] encryptedData = oRSA4.SignData(messagebytes , new SHA1CryptoServiceProvider());



            RSACryptoServiceProvider oRSA4Verify = new RSACryptoServiceProvider();
            oRSA4Verify.FromXmlString(publickey);
            bool bVerify = oRSA4Verify.VerifyData(messagebytes, new SHA1CryptoServiceProvider(), encryptedData);

            Console.WriteLine(encryptedData);
            Console.WriteLine(bVerify);
            Console.ReadKey();


    
            string str = GetFileStr(@"gscfile.gsc");

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
        public static string GetPath(string path)
        {
            return Microsoft.SqlServer.Server.MapPath(path);
        }
    }
}
