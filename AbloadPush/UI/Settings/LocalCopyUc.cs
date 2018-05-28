using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace AbloadPush.UI.Settings
{
    public partial class LocalCopyUc : UserControl
    {
        public bool DoSaveDirectory { get => cbDoMakeCopy.Checked; set => cbDoMakeCopy.Checked = value; }
        public string SaveDirectory { get => tbPath.Text; set => tbPath.Text = value; }

        public LocalCopyUc()
        {
            InitializeComponent();
        }

        private void bBrowse_Click(object sender, EventArgs e)
        {
            var dialog = new FolderBrowserDialog();
            if (!String.IsNullOrWhiteSpace(tbPath.Text) && Directory.Exists(tbPath.Text))
            {
                dialog.SelectedPath = tbPath.Text;
            }
            else
            {
                dialog.SelectedPath = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
            }

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                tbPath.Text = Directory.Exists(dialog.SelectedPath) ? dialog.SelectedPath : "";
            }
        }
    }
}
