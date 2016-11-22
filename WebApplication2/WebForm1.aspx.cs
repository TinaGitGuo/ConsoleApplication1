using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication2
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        class student{
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            //sintoniaAtendimento.tipoSenha = new sintoniaWSDL.TipoSenhaType() { ...};
            //sintoniaAtendimento.fila = new sintoniaWSDL.FilaType() { ...};
            //sintoniaAtendimento.tipoAtendimento = new sintoniaWSDL.TipoAtendimentoType() {... };

            //FileStream fs = GetFileStream(@"gscfile.gsc");
            //FileStream newfs = GetFileStream(@"newStr.txt");

            //string str = GetFileStr(fs);
            //string newstr = GetFileStr(newfs);          

            string str = GetFileStr(@"gscfile.gsc");
            string newstr = GetFileStr(@"newStr.txt");
            int num = 2;//  Specifies that you want to insert rows in which object          
            int point = 0;

            while (num-->0)
            {
                point = str.IndexOf( '}' ,++point);       //         Record index
            }
            str= str.Insert(point, newstr);
            ToStreamWrite(@"gscfile.gsc", str);


            //string sTestFileName = Server.MapPath(@"gscfile.gsc");
            //int iInsertLine = 5;
            //string sInsertText = "hello world";
            //string sText = "";
            //System.IO.StreamReader sr = new System.IO.StreamReader(sTestFileName);

            //int iLnTmp = 0; //Number of records
            //while (!sr.EndOfStream)
            //{
            //    iLnTmp++;
            //    if (iLnTmp == iInsertLine)
            //    {
            //        sText += sInsertText + "\r\n";  //insert values
            //    }
            //    string sTmp = sr.ReadLine();    //Record the current number of rows
            //    sText += sTmp + "\r\n";
            //}
            //sr.Close();

            //System.IO.StreamWriter sw = new System.IO.StreamWriter(sTestFileName, false);
            //sw.Write(sText);
            //sw.Flush();
            //sw.Close();
        }
        //Rewrite
        public void ToStreamWrite(string path,string sText)
        {
            using (System.IO.StreamWriter sw = new System.IO.StreamWriter(GetPath(path), false))
            {

                sw.Write(sText);
                sw.Flush();
                sw.Close();
            }
        }
        //Get the relative path
        public string GetPath(string path)
        {
            return Server.MapPath(path);
        }
        //public FileStream GetFileStream(string path)
        //{
        //    return new FileStream(Server.MapPath(path), FileMode.Open, FileAccess.ReadWrite);
        //}
        //Get the contents of the file
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
       
    }


}

 