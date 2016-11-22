using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication20
{
    class usethread
    {
        public bool[] threadw; //每个线程结束标志 
        public string[] filenamew;//每个线程接收文件的文件名
        public int[] filestartw;//每个线程接收文件的起始位置 
        public int[] filesizew;//每个线程接收文件的大小 
        public string strurl;//
        public bool hb;//文件合并标志 
        public int thread;//进程数 


    }
    public class HttpFile
    {
        public Form formm;
        public int threadh;//线程代号  public string filename;//文件名 
        public string strUrl;//接收文件的URL  public FileStream fs; 
        public HttpWebRequest request; public System.IO.Stream ns;
        public byte[] nbytes;//接收缓冲区  public int nreadsize;//接收字节数 
        public HttpFile(Form1 form, int thread)//构造方法  
        { 
  formm=form;   threadh=thread;
        }
        ~HttpFile()//析构方法 
        { 
  formm.Dispose ();
        }
        public void receive()//接收线程  
        { 
  filename=formm.filenamew[threadh];
            strUrl =formm.strurl;
            ns =null; 
  nbytes= new byte[512];
            nreadsize =0;
            formm.listBox1.Items.Add ("线程"+threadh.ToString ()+"开始接收");
            fs =new FileStream(filename, System.IO.FileMode.Create);
            try   { 
   request=(HttpWebRequest)HttpWebRequest.Create (strUrl);    //接收的起始位置及接收的长度  
   request.AddRange(formm.filestartw[threadh], 
   formm.filestartw[threadh]+formm.filesizew[threadh]); 
   ns=request.GetResponse ().GetResponseStream();//获得接收流
}
