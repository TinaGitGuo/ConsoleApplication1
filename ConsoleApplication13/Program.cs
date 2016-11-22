using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security;
using System.Security.Cryptography;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
 
namespace ConsoleApplication13
{
    class Program
    {
        public static void Main(String[] args)
        {
          
            
        //XmlDocument doc = new XmlDocument();
        //doc.LoadXml("<book xmlns:bk='urn:samples'>" +
        //            "<bk:ISBN>1-861001-57-5</bk:ISBN>" +
        //            "<title>Pride And Prejudice</title>" +
        //            "</book>");

        //// Display information on the ISBN element.
        //XmlElement elem = (XmlElement)doc.DocumentElement.FirstChild;
        //Console.Write("{0}:{1} = {2}", elem.Prefix, elem.LocalName, elem.InnerText);
        //Console.WriteLine("\t namespaceURI=" + elem.NamespaceURI);
        // Creates and initializes a new SortedList.
        SortedList mySL = new SortedList();
            mySL.Add("Type", "fox");
            mySL.Add("Preferred", "jumped");
            mySL.Add("d", "over");
            mySL.Add("f", "brown");
            mySL.Add("A", "quick");
            mySL.Add("a", "The");
            //mySL.Add(1.6, "the");
            //mySL.Add(1.8, "dog");
            //mySL.Add(1.7, "lazy");

            // Gets the key and the value based on the index.
            int myIndex = 3;
            Console.WriteLine("The key   at index {0} is {1}.", myIndex, mySL.GetKey(myIndex));
            Console.WriteLine("The value at index {0} is {1}.", myIndex, mySL.GetByIndex(myIndex));

            // Gets the list of keys and the list of values.
            IList myKeyList = mySL.GetKeyList();
            IList myValueList = mySL.GetValueList();

            // Prints the keys in the first column and the values in the second column.
            Console.WriteLine("\t-KEY-\t-VALUE-");
            for (int i = 0; i < mySL.Count; i++)
                Console.WriteLine("\t{0}\t{1}", myKeyList[i], myValueList[i]);

            Console.ReadKey();
            Acc();

        }
        public static void Acc()
        {
            string path = @"C:\Users\Tina\Documents\Visual Studio 2015\Projects\Document\XMLFile2.xml";
            XmlDocument xDoc = new XmlDocument();
            xDoc.PreserveWhitespace = true;
            using (FileStream fs = new FileStream(path, FileMode.Open))
            {
                xDoc.Load(fs);
            }

            // canon node list
           // XmlNodeList nodeList = xDoc.SelectNodes("//Child1");
            XmlNodeList nodeList =
    xDoc.SelectNodes("//Child1/descendant-or-self::node()|//Child1//@*");
            XmlDsigC14NTransform transform = new XmlDsigC14NTransform();
            transform.LoadInput(nodeList);
            MemoryStream ms = (MemoryStream)transform.GetOutput(typeof(Stream));
            string  cc= xDoc.InnerXml;
            
            File.WriteAllBytes(@"C:\Users\Tina\Documents\Visual Studio 2015\Projects\Document\child1.xml", ms.ToArray());

            // canon XMLDocument
            transform = new XmlDsigC14NTransform();
            transform.LoadInput(xDoc);
            ms = (MemoryStream)transform.GetOutput(typeof(Stream));

           // File.WriteAllBytes(@"C:\Users\Tina\Documents\Visual Studio 2015\Projects\Document\doc.xml", ms.ToArray());

            StreamReader reader = new StreamReader(ms);
            string text = reader.ReadToEnd();

            // Document to Stream
            ms = new MemoryStream();
            XmlWriter xw = XmlWriter.Create(ms);
            xDoc.WriteTo(xw);
            xw.Flush();
            ms.Position = 0;

            transform = new XmlDsigC14NTransform();
            transform.LoadInput(ms);
            ms = (MemoryStream)transform.GetOutput(typeof(Stream));

            File.WriteAllBytes(@"C:\Users\Tina\Documents\Visual Studio 2015\Projects\Document\ms.xml", ms.ToArray());

            // node to stream
            //ms = new MemoryStream();
            //xw = XmlWriter.Create(ms);
            //nodeList[0].WriteTo(xw);
            //xw.Flush();
            //ms.Position = 0;

            //transform = new XmlDsigC14NTransform();
            //transform.LoadInput(ms);
            //ms = (MemoryStream)transform.GetOutput(typeof(Stream));

            //File.WriteAllBytes(@"D:\Test\xml imza\ms2.xml", ms.ToArray());
        }
        public static  void  Ass()
        {

            string path = @"C:\Users\Tina\Documents\Visual Studio 2015\Projects\Document\XMLFile2.xml";
            XmlDocument xDoc = new XmlDocument();
            xDoc.PreserveWhitespace = true;
            using (FileStream fs = new FileStream(path, FileMode.Open))
            {
                xDoc.Load(fs);
            }
          //  XmlElement elem = (XmlElement)xDoc.DocumentElement.FirstChild;
            //XmlNamespaceManager ns = new XmlNamespaceManager(xDoc.NameTable);
            //ns.AddNamespace("env", xDoc.DocumentElement.NamespaceURI);
            //XmlNode Body = xDoc.SelectSingleNode("//env:Child1", ns);
            //ns.AddNamespace("tax", Body.FirstChild.NamespaceURI);

            //   Create an XML document of just the body section
            //XmlDocument xmlBody = new XmlDocument();
            //xmlBody.PreserveWhitespace = true;
            //xmlBody.LoadXml(Body.OuterXml);

            //  Remove any existing IRMark
            //XmlNode nodeIr = xmlBody.SelectSingleNode("//tax:Child2", ns);
            //if (nodeIr != null)
            //{
            //    nodeIr.ParentNode.RemoveChild(nodeIr);
            //}

            //Normalise the document using C14N(Canonicalisation)
            XmlDsigC14NTransform c14n = new XmlDsigC14NTransform();
            c14n.LoadInput(xDoc);

            Stream S = (Stream)c14n.GetOutput();
        }
        private static string GetIRMark(byte[] Xml)
        {
            string vbLf = "\n";
            string vbCrLf = "\r\n";

            //  Convert Byte array to string
            string text = Encoding.UTF8.GetString(Xml);
            XmlDocument doc = new XmlDocument();
            doc.PreserveWhitespace = true;
            doc.LoadXml(text);

            XmlNamespaceManager ns = new XmlNamespaceManager(doc.NameTable);
            ns.AddNamespace("env", doc.DocumentElement.NamespaceURI);
            XmlNode Body = doc.SelectSingleNode("//env:Body", ns);
            ns.AddNamespace("tax", Body.FirstChild.NamespaceURI);

            //   Create an XML document of just the body section
            XmlDocument xmlBody = new XmlDocument();
            xmlBody.PreserveWhitespace = true;
            xmlBody.LoadXml(Body.OuterXml);

            //  Remove any existing IRMark
            XmlNode nodeIr = xmlBody.SelectSingleNode("//tax:IRmark", ns);
            if (nodeIr != null)
            {
                nodeIr.ParentNode.RemoveChild(nodeIr);
            }

            //Normalise the document using C14N(Canonicalisation)
            XmlDsigC14NTransform c14n = new XmlDsigC14NTransform();
            c14n.LoadInput(xmlBody);
            
            using (Stream S = (Stream)c14n.GetOutput())
            {
                byte[] Buffer = new byte[S.Length];

                //  Convert to string and normalise line endings
                S.Read(Buffer, 0, (int)S.Length);
                text = Encoding.UTF8.GetString(Buffer);
                text = text.Replace("&#xD;", "");
                text = text.Replace(vbCrLf, vbLf);
                text = text.Replace(vbCrLf, vbLf);

                //   Convert the final document back into a byte array
                byte[] b = Encoding.UTF8.GetBytes(text);

                //   Create the SHA - 1 hash from the final document
                SHA1 SHA = SHA1.Create();
                byte[] hash = SHA.ComputeHash(b);
                return Convert.ToBase64String(hash);
            }

        }
        //    public static string GetIRMark2(byte[] Xml)
        //    {
        //        string vbLf = "\n";
        //        string vbCrLf = "\r\n";
        //        int length = Xml.Length;

        //      //  Convert Byte array to string
        //        string text = Encoding.UTF8.GetString(Xml, 0, length);
        //        XDocument xDoc = XDocument.Parse(text, LoadOptions.PreserveWhitespace);

        //        XNamespace xns = xDoc.Root.Name.Namespace;
        //        XElement body = xDoc.Root.Element(xns + "Body");
        //        var irmarkelement = from e in body.Descendants()
        //                            where e.Name.LocalName == "IRmark"
        //                            select e;
        //        if (irmarkelement != null)
        //        {
        //            irmarkelement.Remove();
        //        }

        //        XElement newdoc = XElement.Parse(body.ToString());

        //        var xdoc = ToXmlDocument(newdoc);

        //        var reader = newdoc.CreateReader();

        //        reader.MoveToContent();
        //        var xml = reader.ReadOuterXml();
        //        var nStream = ToStream(xml);
        //        byte[] Buffer = new byte[nStream.Length];

        //        nStream.Read(Buffer, 0, (int)nStream.Length);
        //        text = Encoding.UTF8.GetString(Buffer, 0, (int)nStream.Length);
        //        text = text.Replace("&#xD;", "");
        //        text = text.Replace(vbCrLf, vbLf);
        //        text = text.Replace(vbCrLf, vbLf);

        //        byte[] b = Encoding.UTF8.GetBytes(text);

        //        var hasher = HashAlgorithmProvider.OpenAlgorithm(HashAlgorithm.Sha1);
        //        byte[] bytes = hasher.HashData(b);

        //        return Convert.ToBase64String(bytes);
        //    }
        //}
        //public static Stream ToStream(string str)
        //{
        //    byte[] byteArray = Encoding.UTF8.GetBytes(str);
        // //   byte[] byteArray = Encoding.ASCII.GetBytes(str);
        //    return new MemoryStream(byteArray);
        //}
    }
}

