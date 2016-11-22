using System;
using System.Windows.Forms;

namespace WebApplication2
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        private void lstRules_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.All;
            else
                e.Effect = DragDropEffects.None;
        }

        private void lstRules_DragDrop(object sender, DragEventArgs e)
        {
            string[] _droppedFiles = (string[])e.Data.GetData(DataFormats.FileDrop, false);

            foreach (string _file in _droppedFiles)
            {
                lstRules.Items.Add(_file);
            }
        }
    }
}