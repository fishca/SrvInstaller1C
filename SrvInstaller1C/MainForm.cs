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
        public struct InstalledServices
        {
            public string ProductType;
            public string ProductName;
            public string ExePath;
            public string ProductID;
            public string ProductVersion;
        }

        public enum MSI_ERROR
        {
            ERROR_SUCCESS           = 0,
            ERROR_MORE_DATA         = 234,
            ERROR_NO_MORE_ITEMS     = 259,
            ERROR_INVALID_PARAMETER = 87,
            ERROR_BAD_CONFIGURATION = 1610
        }

        public List<InstalledServices> ListInstalledServices = new List<InstalledServices>();

        public List<Service1C> ArrayOfServices = new List<Service1C>();

        public MainForm()
        {
            InitializeComponent();
        }

        private void ButtonAdd_Click(object sender, EventArgs e)
        {
            if (ListViewExistedServices.SelectedItems.Count > 0)
            {
                var Item = ListViewExistedServices.SelectedItems[0];

                foreach (var Serv in ArrayOfServices)
                {
                    if (Serv.DisplayName == Item.SubItems[0].Text)
                    {
                        var ClusterForm = new ServiceParam();
                        ClusterForm.ItsAdd = true;
                        ClusterForm.Serv = Serv;
                        ClusterForm.ShowDialog();
                    }
                }


            }
            else
            {
                var AddNewService = new AvailableServices();
                AddNewService.FullServiceList = ListInstalledServices;
                AddNewService.ShowDialog();

            }

            RefreshListService();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            Text = Application.ProductName + " / " + "_" + " / " + Application.ProductVersion;
            RefreshListService();
        }


        public void ActivateButton()
        {
            linkLabel1.Enabled = false;
            linkLabel2.Enabled = false;
            linkLabel3.Enabled = false;
            ButtonEdit.Enabled = false;
            ButtonDel.Enabled = false;
            ButtonAdd.Text = "Добавить новую службу";
            if (ListViewExistedServices.SelectedItems.Count > 0)
            {
                var Item = ListViewExistedServices.SelectedItems[0];

                ButtonEdit.Enabled = true;
                ButtonDel.Enabled = true;
                ButtonAdd.Text = "Скопировать" + Environment.NewLine + "выделенную службу";
                if (Item.SubItems[1].Text == "Работает")
                {
                    linkLabel2.Enabled = true;
                    linkLabel3.Enabled = true;
                }
                else if (Item.SubItems[1].Text == "Остановлена")
                {
                    linkLabel1.Enabled = true;
                }
            }

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

                
                ArrayOfServices.Add(Srv);

                i++;

            }

            search.Dispose();
            ActivateButton();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            AboutBox aboutBox = new AboutBox();
            
            aboutBox.ShowDialog();
        }

        private void ListViewExistedServices_Click(object sender, EventArgs e)
        {
            ActivateButton();
        }

        private void ListViewExistedServices_SelectedIndexChanged(object sender, EventArgs e)
        {
            ActivateButton();
        }

        private void ButtonEdit_Click(object sender, EventArgs e)
        {
            if (ListViewExistedServices.SelectedItems.Count > 0)
            {
                var Item = ListViewExistedServices.SelectedItems[0];

                foreach (var Serv in ArrayOfServices)
                {
                    if (Serv.DisplayName == Item.SubItems[0].Text)
                    {
                        var ClusterForm = new ServiceParam();
                        ClusterForm.ItsAdd = true;
                        ClusterForm.Serv = Serv;
                        ClusterForm.ShowDialog();
                        RefreshListService();
                    }
                }
            }
            else
            {
                MessageBox.Show("Необходимо выделить строку со службой сервера 1С, которую требуется изменить.");
            }
        }

        private void ButtonDel_Click(object sender, EventArgs e)
        {
            if (ListViewExistedServices.SelectedItems.Count > 0)
            {
                var Item = ListViewExistedServices.SelectedItems[0];

                foreach (var Serv in ArrayOfServices)
                {
                    if (Serv.DisplayName == Item.SubItems[0].Text)
                    {


                        DialogResult Rez = MessageBox.Show("Вы действительно хотите удалить службу сервера 1С " + Environment.NewLine + "\"" + Serv.DisplayName + "\" ?", "УДАЛЕНИЕ службы сервера 1С", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);

                        if (Rez == DialogResult.Yes)
                        {
                            bool StopError = false;
                            try
                            {
                                var sc = new System.ServiceProcess.ServiceController(Serv.Name);
                                if (sc.Status == ServiceControllerStatus.Running)
                                {
                                    sc.Stop();
                                    sc.WaitForStatus(ServiceControllerStatus.Stopped);
                                }
                                sc.Dispose();
                            }
                            catch (Exception)
                            {
                                StopError = true;
                            }
                            //var Result = ObjTec.Services.ServiceInstaller.UninstallService(Serv.Name)
                        }


                        RefreshListService();
                    }
                }
            }
            else
            {
                MessageBox.Show("Необходимо выделить строку со службой сервера 1С, которую требуется изменить.");
            }
        }
    }
}
