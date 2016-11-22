using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormDragDrop
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void listView1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy;
            else
                e.Effect = DragDropEffects.None;

        }

        private void listView1_DragDrop(object sender, DragEventArgs e)
        {
            string[] _droppedFiles = (string[])e.Data.GetData(DataFormats.FileDrop, false);

            foreach (string _file in _droppedFiles)
            {
                listView1.Items.Add(_file);
            }

        }
    }
}
