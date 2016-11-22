using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace ClassLibrary3
{
    public static class ReadFile
    {
        
        public static string GetFileStr(string path)
        {
            string str = "";
            using (StreamReader sr = new StreamReader( path))
            {
                sr.BaseStream.Seek(0, SeekOrigin.Begin);
                str = sr.ReadToEnd();
            }
            return str;
        }
        public static T JsonDeserialize<T>(string jsonString)
        {
            DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(T));
            MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(jsonString));
            T obj = (T)ser.ReadObject(ms);


            //  T obj = (T)ser.ReadObject(ms);
            return obj;
        }
    }
}
