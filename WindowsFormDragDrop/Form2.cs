using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormDragDrop
{
    
      
        public partial class Form2 : Form
        {
            public Form2()
            {
                InitializeComponent();
                this.AllowDrop = true;
                this.DragEnter += new DragEventHandler(Form2_DragEnter_1);
                this.DragDrop += new DragEventHandler(Form2_DragDrop_1);
            }
         
            
            private void Form2_DragEnter_1(object sender, DragEventArgs e)
            {
                if (e.Data.GetDataPresent(DataFormats.FileDrop))


                e.Effect = DragDropEffects.All;
            }

            private void Form2_DragDrop_1(object sender, DragEventArgs e)
            {
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
                foreach (string file in files) Console.WriteLine(file);
            }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
    }
    
}
