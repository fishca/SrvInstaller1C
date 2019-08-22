using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Management;
using System.ServiceProcess;


namespace SrvInstaller1C
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void ButtonAdd_Click(object sender, EventArgs e)
        {
            if (ListViewExistedServices.SelectedItems.Count > 0)
            {
                var Item = ListViewExistedServices.SelectedItems[0];
                /*
                foreach (var Serv in ArrayOfServices)
                {

                }
                */

            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            //Text = My.Application.Info.ProductName + " / " + My.Application.Info.Copyright
            Text = Application.ProductName + " / " + "_" + " / " + Application.ProductVersion;

            RefreshListService();


        }

        
        /// <summary>
        /// Получает службы через WMI
        /// </summary>
        public void RefreshListService()
        {
            ListViewExistedServices.Items.Clear();

            //Dim search As New ManagementObjectSearcher("SELECT * FROM Win32_Service WHERE PathName like '%ragent.exe%'")
            ManagementObjectSearcher search = new ManagementObjectSearcher("SELECT * FROM Win32_Service WHERE PathName like '%ragent.exe%'");

            int i = 0;
            foreach (ManagementObject info in search.Get())
            {
                /*
                Dim Srv = New Service
                Srv.Name = info("Name")
                Srv.DisplayName = info("DisplayName")
                Srv.Description = info("Description")
                Srv.PathName = info("PathName")
                Srv.User = info("StartName")
                Srv.ParsePath()
                */
                Service1C Srv = new Service1C();
                Srv.Name        = (String)info["Name"];
                Srv.DisplayName = (String)info["DisplayName"];
                Srv.Description = (String)info["Description"];
                Srv.PathName    = (String)info["PathName"];
                Srv.User        = (String)info["StartName"];
                Srv.ParsePath();

                //Dim sc = New System.ServiceProcess.ServiceController(Srv.Name)
                ServiceController sc = new ServiceController(Srv.Name);

                ListViewItem item1 = new ListViewItem(Srv.DisplayName);

                if (sc.Status.ToString() == "Running")
                    item1.SubItems.Add("Работает");
                if (sc.Status.ToString() == "Stopped")
                    item1.SubItems.Add("Остановлена");

                item1.SubItems.Add(Srv.PortMngr.ToString());
                item1.SubItems.Add(Srv.ClusterFiles);
                item1.SubItems.Add(Srv.PathName);

                ListViewExistedServices.Items.Add(item1);

                i++;

            }

            search.Dispose();

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            AboutBox aboutBox = new AboutBox();
            
            aboutBox.ShowDialog();
        }
    }
}
