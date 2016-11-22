using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication8
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        [DataContract]

        public class Property
        {
            [DataMember]

            public string propertyType { get; set; }
            [DataMember]

            public Value[] values { get; set; }
        }
        [DataContract]
        public class Value
        {
            [DataMember]

            public Resource[] resource { get; set; }
        }
        [DataContract]
        public class Resource
        {
            [DataMember]
            public string resource { get; set; }
        }
        [DataContract]
        public class Values : Value
        {
            [DataMember]
            public string Region { get; set; }
            [DataMember]
            public string Subscription { get; set; }
        }
        [DataContract]
        public class RootObject
        {
            [DataMember]
            public Property  properties { get; set; }
        }
        
        public string GetPath(string path)
        {
            return Server.MapPath(path);
        }
        public string GetFileStr(string path)
        {
            string str = "";
            using (StreamReader sr = new StreamReader(GetPath(path)))
            {
                sr.BaseStream.Seek(0, SeekOrigin.Begin);
                str = sr.ReadToEnd();
            }
            return str;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            RootObject c = new RootObject();

            //c.properties
             string str = GetFileStr(@"TextFile1.txt");

            RootObject a= JsonDeserialize<RootObject>(str);

        }

        //public  static T Newtonsoft<T>(string jsonString)
        //{
        //    Newtonsoft.Json
        //        return new T();
        //}
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