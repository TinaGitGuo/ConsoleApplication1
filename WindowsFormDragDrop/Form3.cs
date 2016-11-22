using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormDragDrop
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
            listBox1.AllowDrop = true;
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            //ChangeWindowMessageFilter(WM_DROPFILES, MSGFLT_ADD);
            //ChangeWindowMessageFilter(WM_COPYDATA, MSGFLT_ADD);
            //ChangeWindowMessageFilter(0x0049, MSGFLT_ADD);

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button1_MouseDown(object sender, MouseEventArgs e)
        {
            button1.DoDragDrop(button1.Text, DragDropEffects.All);
        }

        private void textBox1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Text))
                e.Effect = DragDropEffects.Copy;
            else
                e.Effect = DragDropEffects.None;
        }

        private void textBox1_DragDrop(object sender, DragEventArgs e)
        {
            textBox1.Text = e.Data.GetData(DataFormats.Text).ToString();

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
          
        }

        private void listBox1_DragDrop(object sender, DragEventArgs e)
        {
            string[] _droppedFiles = (string[])e.Data.GetData(DataFormats.FileDrop, false);

            foreach (string _file in _droppedFiles)
            {
                listBox1.Items.Add(_file);
            }
        }

        private void listBox1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.All;
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

        private void listView1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.All;
            else
                e.Effect = DragDropEffects.None;
           
        }

        private void textBox1_QueryContinueDrag(object sender, QueryContinueDragEventArgs e)
        {

        }
    }
}
