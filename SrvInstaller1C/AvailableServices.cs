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
            //FullServiceList.Sort(Function(x, y) x.ProductType.CompareTo(y.ProductType))
            FullServiceList.Sort();
            foreach (var Item in FullServiceList)
            {
                ListViewItem item1 = new ListViewItem(Item.ProductType);
                switch (Item.ProductType)
                {
                    case "AppServer":
                        item1.SubItems.Add("Сервер приложений");
                        break;
                    case "RASServer":
                        item1.SubItems.Add("Сервер администрирования");
                        break;
                    case "CRServer":
                        item1.SubItems.Add("Сервер хранилища");
                        break;
                    default:
                        break;
                }
                item1.SubItems.Add(Item.ExePath);
                item1.SubItems.Add(Item.ProductVersion);

                ListAllServices.Items.Add(item1);
            }
        }

        private void ButtonAdd_Click(object sender, EventArgs e)
        {
            ServiceParam ClusterForm = new ServiceParam();
            ClusterForm.ItsAdd = true;
            ClusterForm.Serv = new Service1C();
            ClusterForm.ShowDialog();

            Close();

        }

        private void Button1_Click(object sender, EventArgs e)
        {

        }

        private void ListAllServices_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void ListAllServices_DoubleClick(object sender, EventArgs e)
        {
            ListViewItem Item = ListAllServices.SelectedItems[0];
            if (Item.SubItems[0].Text == "AppServer")
            {
                Service1C Serv = new Service1C();
                Serv.ExeFile = Item.SubItems[2].Text;

                ServiceParam ClusterForm = new ServiceParam();
                ClusterForm.ItsAdd = true;
                ClusterForm.Serv = Serv;
                ClusterForm.ShowDialog();
            }
            Close();
        }
    }
}
