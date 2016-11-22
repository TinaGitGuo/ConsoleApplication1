using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public bool[] threadw; //每个线程结束标志 
        public string[] filenamew;//每个线程接收文件的文件名

        public int[] filestartw;//每个线程接收文件的起始位置
        public int[] filesizew;//每个线程接收文件的大小 
        public string strurl;//接受文件的URL 
        public bool hb;
        //文件合并标志 
        public int thread;//进程数
        private void Form1_Load(object sender, EventArgs e)
        {

        }
        public class HttpFile
        {
            public Form1 formm;
            public int threadh;//线程代号 
            public string filename;//文件名 
            public string strUrl;//接收文件的URL 
            public FileStream fs;
            public HttpWebRequest request;
            public System.IO.Stream ns;
            public byte[] nbytes;//接收缓冲区
            public int nreadsize;//接收字节数 
            public HttpFile(Form1 form, int thread)//构造方法 
            {
                formm = form;
                threadh = thread;
            }
            ~HttpFile()//析构方法
            {
                formm.Dispose();
            }
           

            public void receive()//接收线程 
            {
                filename = formm.filenamew[threadh];
                strUrl = formm.strurl;
                ns = null;
                nbytes = new byte[512];
                nreadsize = 0;
                formm.listBox1.Items.Add("线程" + threadh.ToString() + "开始接收");
                fs = new FileStream(filename, System.IO.FileMode.Create);
                try
                {


                    //FtpWebResponse response = (FtpWebResponse)WebRequest.GetResponse();
                    //Stream ftpStream = response.GetResponseStream();
                    //long cl = response.ContentLength;
                    //int bufferSize = 2048;
                    //int readCount;
                    //byte[] buffer = new byte[bufferSize];
                    //readCount = ftpStream.Read(buffer, 0, bufferSize);

                    //FileStream outputStream = new FileStream(newFileName, FileMode.Create);
                    //while (readCount > 0)
                    //{
                    //    outputStream.Write(buffer, 0, readCount);
                    //    readCount = ftpStream.Read(buffer, 0, bufferSize);
                    //}


                    // FtpWebRequest

                    //                   request = (HttpWebRequest)WebRequest.Create(strUrl);    //接收的起始位置及接收的长度  

                    request = (HttpWebRequest)WebRequest.Create(strUrl);    //接收的起始位置及接收的长度  
                    request.AddRange(formm.filestartw[threadh],
                    formm.filestartw[threadh] + formm.filesizew[threadh]);
                    ns = request.GetRequestStream(); ;//获得接收流

                    nreadsize = ns.Read(nbytes, 0, 512);

                   

                    while (nreadsize > 0)
                    {
                        fs.Write(nbytes, 0, nreadsize); //ns.Read(nbytes, (int)request.ContentLength / 5 * i, (int)request.ContentLength / 5);
                        nreadsize = ns.Read(nbytes, 0, 512);
                        formm.listBox1.Items.Add("线程" + threadh.ToString() + "正在接收");
                    }
                    fs.Close(); ns.Close();
                }
                catch (Exception er)
                {
                    MessageBox.Show(er.Message); fs.Close();
                }
                formm.listBox1.Items.Add("进程" + threadh.ToString() + "接收完毕!");
                formm.threadw[threadh] = true;
            }
        }
        private void button1_Click(object sender, System.EventArgs e)
        {
            DateTime dt = DateTime.Now;//开始接收时间  
            textBox1.Text = dt.ToString();
            strurl = textBox2.Text.Trim().ToString();
            HttpWebRequest request;
            long filesize = 0;
            try
            {
                request = (HttpWebRequest)HttpWebRequest.Create(strurl);
                filesize = request.GetResponse().ContentLength;//取得目标文件的长度 
                request.Abort();
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message);
            }
            // 接收线程数 
            thread = Convert.ToInt32(textBox4.Text.Trim().ToString(), 10);  //根据线程数初始化数组 
            threadw = new bool[thread];
            filenamew = new string[thread];
            filestartw = new int[thread];
            filesizew = new int[thread];
            //计算每个线程应该接收文件的大小 
            int filethread = (int)filesize / thread;//平均分配 
            int filethreade = filethread + (int)filesize % thread;//剩余部分由最后一个线程完成 
                                                                  //为数组赋值 
            for (int i = 0; i < thread; i++)
            {
                threadw[i] = false;//每个线程状态的初始值为假 
                filenamew[i] = i.ToString() + ".dat";//每个线程接收文件的临时文件名
                if (i < thread - 1)
                {
                    filestartw[i] = filethread * i;//每个线程接收文件的起始点 
                    filesizew[i] = filethread - 1;//每个线程接收文件的长度  
                }
                else
                {
                    filestartw[i] = filethread * i; filesizew[i] = filethreade - 1;
                }
            }
            //定义线程数组，启动接收线程 
            Thread[] threadk = new Thread[thread];
            HttpFile[] httpfile = new HttpFile[thread];
            for (int j = 0; j < thread; j++)
            {
                httpfile[j] = new HttpFile(this, j);
                threadk[j] = new Thread(new ThreadStart(httpfile[j].receive));
                threadk[j].Start();
            }
            //启动合并各线程接收的文件线程 
            Thread hbth = new Thread(new ThreadStart(hbfile));
            hbth.Start();
        }


        public void hbfile()
        {
            while (true)//等待
            {
                hb = true;
                for (int i = 0; i < thread; i++)
                {
                    if (threadw[i] == false)//有未结束线程，等待 
                    {
                        hb = false;
                        Thread.Sleep(100);
                        break;
                    }
                }
                if (hb == true)//所有线程均已结束，停止等待，
                {
                    break;
                }
            }
            FileStream fs;//开始合并 
            FileStream fstemp;
            int readfile;
            byte[] bytes = new byte[512];
            fs = new FileStream(textBox3.Text.Trim().ToString(), System.IO.FileMode.Create);
            for (int k = 0; k < thread; k++)
            {
                fstemp = new FileStream(filenamew[k], System.IO.FileMode.Open);
                while (true)
                {
                    readfile = fstemp.Read(bytes, 0, 512);
                    if (readfile > 0)
                    {
                        fs.Write(bytes, 0, readfile);
                    }
                    else
                    {
                        break;
                    }
                }
                fstemp.Close();
            }
            fs.Close();
            DateTime dt = DateTime.Now;
            textBox1.Text = dt.ToString();//结束时间 

            MessageBox.Show("接收完毕!!!");
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
