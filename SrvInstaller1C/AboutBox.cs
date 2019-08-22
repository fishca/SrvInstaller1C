using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SrvInstaller1C
{
    public partial class AboutBox : Form
    {
        public AboutBox()
        {
            InitializeComponent();
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void AboutBox_Load(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox1.Text += "Service installer for 1C:Enterprise 8 http://infostart.ru/public/178238/" + Environment.NewLine;
            textBox1.Text += "Автор https://github.com/alekseybochkov/ServiceInstaller1C Алексей Бочков";

        }
    }
}
