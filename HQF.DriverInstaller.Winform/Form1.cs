using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HQF.DriverInstaller.Lib;

namespace HQF.DriverInstaller.Winform
{
    public partial class Form1 : Form
    {
        private DriverBLL _driverBll=new DriverBLL();
        public Form1()
        {
            InitializeComponent();
        }

        private void btn_Browse_Click(object sender, EventArgs e)
        {
            var openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = @"All Execute File(*.exe)|*.exe";
            openFileDialog.Multiselect=false;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                txt_exeFile.Text = openFileDialog.FileName;
            }
        }

      
    }
}
