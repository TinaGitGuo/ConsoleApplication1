using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication3
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            string str = GetFileStr(@"TextFile1.txt");
            //string str = "Hello World";
            byte[] messagebytes = Encoding.UTF8.GetBytes(str);
 
            //
            RSACryptoServiceProvider oRSA4ToKey = new RSACryptoServiceProvider();
            string privtekey = oRSA4ToKey.ToXmlString(true);
            string publickey = oRSA4ToKey.ToXmlString(false);


            RSACryptoServiceProvider oRSA4 = new RSACryptoServiceProvider();
            oRSA4.FromXmlString(privtekey);
            byte[] encryptedData = oRSA4.SignData(messagebytes, new SHA1CryptoServiceProvider());



            RSACryptoServiceProvider oRSA4Verify = new RSACryptoServiceProvider();
            oRSA4Verify.FromXmlString(publickey);
            bool bVerify = oRSA4Verify.VerifyData(messagebytes, new SHA1CryptoServiceProvider(), encryptedData);

          
            Console.WriteLine(bVerify);
            Console.ReadKey();



             

        }

//        public string JsonFile()
//        {

//             var as=[ {
//                "updateSRReq": {
//                    "incidentID": "",
//"createdBy": "037022000042048",
//"description": "037022000042048",
//"isVisibleToCustomer": "3",
//"updateType": "2",
//"activityType": "2",
//"createdOn": "2016-09-08 17:57",
//"lastUpdate": "2016-09-08 17:57",
//"status": "2",
//"closedTime": ""
//                },
//"subHeader": {
//                    "value": {
//                        "requestUUID": "123",
//"ServiceRequestId": "AE.MAPS.UDK.SSTP",
//"ServiceRequestVersion": "1.0",
//"ChannelId": "MAPS"
//                    }
//                }
//            }]
//        }
        public   string GetFileStr(string path)
        {
            string str = "";
            using (StreamReader sr = new StreamReader(GetPath(path)))
            {
                sr.BaseStream.Seek(0, SeekOrigin.Begin);
                str = sr.ReadToEnd();
            }
            return str;
        }
        public   string GetPath(string path)
        {
            return Server.MapPath(path);
        }
    }
}