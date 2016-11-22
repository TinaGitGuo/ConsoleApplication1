using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication14与java相等的加密
{
    class Class3
    {
        void a()
        {
            //加密解密用到的公钥与私钥 
            RSACryptoServiceProvider oRSA = new RSACryptoServiceProvider();
            string privatekey = oRSA.ToXmlString(true);//私钥 
            string publickey = oRSA.ToXmlString(false);//公钥 
                                                       //这两个密钥需要保存下来 
            byte[] messagebytes = Encoding.UTF8.GetBytes("luo罗"); //需要加密的数据 

            //公钥加密 
            RSACryptoServiceProvider oRSA1 = new RSACryptoServiceProvider();
            oRSA1.FromXmlString(publickey); //加密要用到公钥所以导入公钥 
            byte[] AOutput = oRSA1.Encrypt(messagebytes, false); //AOutput 加密以后的数据
                                                                 //私钥解密 
            RSACryptoServiceProvider oRSA2 = new RSACryptoServiceProvider();
            oRSA2.FromXmlString(privatekey);
            byte[] AInput = oRSA2.Decrypt(AOutput, false);
            string reslut = Encoding.ASCII.GetString(AInput);
// 2、用RSACryptoServiceProvider签名验签
   byte[] messagebytes = Encoding.UTF8.GetBytes("luo罗");
            RSACryptoServiceProvider oRSA = new RSACryptoServiceProvider();
            string privatekey = oRSA.ToXmlString(true);
            string publickey = oRSA.ToXmlString(false);

            //私钥签名 
            RSACryptoServiceProvider oRSA3 = new RSACryptoServiceProvider();
            oRSA3.FromXmlString(privatekey);
            byte[] AOutput = oRSA3.SignData(messagebytes, "SHA1");
            //公钥验证 
            RSACryptoServiceProvider oRSA4 = new RSACryptoServiceProvider();
            oRSA4.FromXmlString(publickey);
            bool bVerify = oRSA4.VerifyData(messagebytes, "SHA1", AOutput);


    //        3、用证书进行签名
    //因为一般证书的私钥是不可以导出的所以所以用第2种方法导入私钥的来进行签名行不通
byte[] messagebytes = Encoding.UTF8.GetBytes("luo罗");
            string Path = @"D:Certificate1.P12";
            X509Certificate2 x509 = new X509Certificate2(Path, "12345678");
            SHA1 sha1 = new SHA1CryptoServiceProvider();
            byte[] hashbytes = sha1.ComputeHash(messagebytes); //对要签名的数据进行哈希 
            RSAPKCS1SignatureFormatter signe = new RSAPKCS1SignatureFormatter();
            signe.SetKey(x509.PrivateKey); //设置签名用到的私钥 
            signe.SetHashAlgorithm("SHA1"); //设置签名算法 
            byte[] reslut = signe.CreateSignature(hashbytes);


            //验签：与第2方法相同
           RSACryptoServiceProvider oRSA4 = new RSACryptoServiceProvider();
            oRSA4.FromXmlString(x509.PublicKey.Key.ToXmlString(false));
            bool bVerify = oRSA4.VerifyData(messagebytes, "SHA1", reslut);
        }
        void b()
        {
            ////4、用证书加密解密
   string Path = @"D:Certificate1.P12";
            X509Certificate2 x509 = new X509Certificate2(Path, "12345678");
            byte[] data = System.Text.Encoding.UTF8.GetBytes("cheshi罗");
            -
                        //证书公钥加密 
                        RSACryptoServiceProvider oRSA1 = new RSACryptoServiceProvider();

            oRSA1.FromXmlString(x509.PublicKey.Key.ToXmlString(false));
            -
                        byte[] AOutput = oRSA1.Encrypt(data, false);
            -
                        //证书私钥解密 
                        RSACryptoServiceProvider rsa2 = (RSACryptoServiceProvider)x509.PrivateKey;
            byte[] plainbytes = rsa2.Decrypt(AOutput, false);
            string reslut = Encoding.UTF8.GetString(plainbytes);
            //5用证书对文件加密解密，因为文件可能特别大 所以需要用流和buffer的方式来，鄙视把文件全部读到byte[] 里进行加密的人，假如文件5G，那全部读到byte[] 里崩溃掉
   private void Form1_Load(object sender, EventArgs e)
        {
            x509 = new X509Certificate2(Path, "12345678");
            RSACryptoServiceProvider oRSA1 = new RSACryptoServiceProvider();
            Encrypt();
            Decrypt();
        }
        private void Decrypt()
        {
            string FilePath = "2.txt";
            string OutFile = "3.txt";
            System.IO.FileStream picfs = new System.IO.FileStream(FilePath, System.IO.FileM
        }
    }
}
