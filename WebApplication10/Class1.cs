using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;

namespace WebApplication10
{
    public static class Class1
    {
         public static System.Drawing.Bitmap ResizeImage(System.Drawing.Image image, int width, int height)
        {
            Bitmap result = new Bitmap(width, height);
            using (Graphics graphics = Graphics.FromImage(result))
            {
                graphics.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
                graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                graphics.DrawImage(image, 0, 0, result.Width, result.Height);
            }
            return result;
        }
        //public static string opret_version(Billedbuf billeddata, string extension, int buforgWidth, int buforgHeight, int bufeditWidth)
        //{
        //    Bitmap myNewBitmap = new Bitmap(HttpContext.Current.Server.MapPath(billeddata.DesignatedPath + Path.GetFileName(billeddata.Original_link)));
        //    int bufeditHeight = calculate_Height(bufeditWidth, buforgWidth, buforgHeight);
        //    string newfile = Path.GetFileNameWithoutExtension(billeddata.Original_link) + extension + ".jpg";
        //    Bitmap myEditnail = ResizeImage(myNewBitmap, bufeditWidth, bufeditHeight);
        //    myEditnail.Save(HttpContext.Current.Server.MapPath(billeddata.DesignatedPath + newfile),
        //                    System.Drawing.Imaging.ImageFormat.Jpeg);
        //    myNewBitmap.Dispose();
        //    return newfile;
        //}
        public static string opret_version( string extension, int buforgWidth, int buforgHeight, int bufeditWidth)
        {
            var path = HttpContext.Current.Server.MapPath(@"Images"+"\\"+"chongwu1110.jpg");
            Bitmap myNewBitmap = new Bitmap(path);
            int bufeditHeight = 500;
            string newfile= Path.GetFileNameWithoutExtension(path) + extension + ".jpg";
            Bitmap myEditnail = ResizeImage(myNewBitmap, bufeditWidth, bufeditHeight);
            var newpath = HttpContext.Current.Server.MapPath(@"Images" + "\\" + newfile);
            myEditnail.Save(newpath,
              System.Drawing.Imaging.ImageFormat.Jpeg);
            myNewBitmap.Dispose();
            return newfile; 
            //string newfile =Path.GetDirectoryName(path)+ "\\"+Path.GetFileNameWithoutExtension(path) + extension + ".jpg";
            //Bitmap myEditnail = ResizeImage(myNewBitmap, bufeditWidth, bufeditHeight);
            //myEditnail.Save(  newfile ,
            //                System.Drawing.Imaging.ImageFormat.Jpeg);
        }
    }
}