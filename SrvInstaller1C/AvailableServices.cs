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
    public partial class AvailableServices : Form
    {
        public List<MainForm.InstalledServices> FullServiceList = new List<MainForm.InstalledServices>();
        public AvailableServices()
        {
            InitializeComponent();
        }

        private void AvailableServices_Load(object sender, EventArgs e)
        {

        }
    }
}
