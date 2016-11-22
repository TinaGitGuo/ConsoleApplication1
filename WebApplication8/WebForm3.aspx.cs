using ClassLibrary3;
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
    public partial class WebForm3 : System.Web.UI.Page
    {

        [DataContract]
        public class Property
        {
            [DataMember]

            public string propertyType { get; set; }
            [DataMember]

            public value[] values { get; set; }
        }
        [DataContract]
        public  class value{

            [DataMember]
            public string Region { get; set; }
            [DataMember]
            public string Subscription { get; set; }
            [DataMember]
            public string resource { get; set; }
        }
        //[DataContract]
        //public class Subscrip :value
        //{
        //    [DataMember]
        //    public string Region { get; set; }
        //    [DataMember]
        //    public string Subscription { get; set; }
        //}
        //[DataContract]
        //public class Resource :value
        //{
        //    [DataMember]
        //    public string resource { get; set; }
        //}
        [DataContract]
        public class RootObject
        {
            [DataMember]
            public Property[] properties { get; set; }
        }
     
        protected void Page_Load(object sender, EventArgs e)
        {

            string jsonString = " {\"field1\":\"1\"} ";
            jsonString= ReadFile.GetFileStr(Server.MapPath(@"TextFile1 - Copy.txt"));
            RootObject obj= ReadFile.JsonDeserialize<RootObject>(jsonString);

        }
    }
}