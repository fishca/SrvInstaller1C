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
//using Microsoft.Win32;
using System.Runtime.InteropServices;
using System.IO;
using System.Diagnostics;

namespace SrvInstaller1C
{



    public partial class MainForm : Form
    {

        //[DllImport("msi.dll", EntryPoint = "MsiEnumProductsExW", CharSet = CharSet.Unicode, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        //public static extern uint MsiEnumProductsEx(string szProductCode, string szUserSid, uint dwContext, uint dwIndex, string szInstalledProductCode, out object pdwInstalledProductContext, string szSid, ref uint pccSid)
        [DllImport("msi.dll", EntryPoint = "MsiEnumProducts", CharSet = CharSet.Unicode, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        public static extern uint MsiEnumProducts(int szProductCode, StringBuilder szUserSid);


        [DllImport("msi.dll", CharSet = CharSet.Unicode)]
        //static extern Int32 MsiGetProductInfo(string product, string property, [Out] StringBuilder valueBuf, ref Int32 len);
        static extern Int32 MsiGetProductInfo(string product, string property, [Out] string valueBuf, ref Int32 len);

        public struct InstalledServices
        {
            public string ProductType;
            public string ProductName;
            public string InstallLocation;
            public string ExePath;
            public string ProductID;
            public string ProductVersion;
        }

        public enum MSI_ERROR : uint
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
            //GetListOfAllInstalledPlatforms();
        }

        public string GetErrorDescription(int ErrorNumber)
        {
            string Desc = "";

            if (ErrorNumber == 5)
            {
                //ERROR_ACCESS_DENIED	
                Desc = "The handle does not have access to the service.";
            }
            else if (ErrorNumber == 1059)
            {
                // ERROR_CIRCULAR_DEPENDENCY	
                Desc = "A circular service dependency was specified.";

            }
            else if (ErrorNumber == 1065)
            {
                // ERROR_DATABASE_DOES_NOT_EXIST	
                Desc = "The specified database does not exist.";
            }
            else if (ErrorNumber == 1078)
            {
                // ERROR_DUPLICATE_SERVICE_NAME	
                Desc = "The display name already exists in the service control manager database either as a service name or as another display name.";
            }
            else if (ErrorNumber == 6)
            {
                // ERROR_INVALID_HANDLE	---------------
                Desc = "The handle to the specified service control manager database is invalid.";
            }
            else if (ErrorNumber == 123)
            {
                // ERROR_INVALID_NAME	
                Desc = "The specified service name is invalid.";
            }
            else if (ErrorNumber == 87)
            {
                // ERROR_INVALID_PARAMETER		
                Desc = "A parameter that was specified is invalid.";
            }
            else if (ErrorNumber == 1057)
            {
                // ERROR_INVALID_SERVICE_ACCOUNT		
                Desc = "The account name does not exist, or a service is specified to share the same binary file as an already installed service but with an account name that is not the same as the installed service.";
            }
            else if (ErrorNumber == 1060)
            {
                // ERROR_SERVICE_DOES_NOT_EXIST		
                Desc = "The specified service does not exist.";
            }
            else if (ErrorNumber == 1072)
            {
                // ERROR_SERVICE_MARKED_FOR_DELETE			
                Desc = "The service has been marked for deletion.";
            }
            else if (ErrorNumber == 1073)
            {
                // ERROR_SERVICE_EXISTS			
                Desc = "The specified service already exists in this database.";
            }
            
            return "№ " + ErrorNumber.ToString() + " - " + Desc;
        }
        public string GetProductProperty(string productID, string sProperty)
        {
            string lsIKC = new string(' ', 255);
            //StringBuilder lsIKC = new StringBuilder(" ", 255);
            int liLen = 255;

            MsiGetProductInfo(productID, sProperty, lsIKC, ref liLen);
        
            return lsIKC.ToString().Substring(0, liLen).Trim();
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

        public void AddAccesibleServices(string InstallLocation, string ProductName)
        {

            FileInfo FileServer1C = new FileInfo(Path.Combine(InstallLocation, "bin\ragent.exe"));
            if (FileServer1C.Exists)
            {
                FileVersionInfo myFileVersionInfo = FileVersionInfo.GetVersionInfo(FileServer1C.FullName);

                InstalledServices Service1C = new InstalledServices();

                Service1C.InstallLocation = InstallLocation;
                Service1C.ProductType = "AppServer";
                Service1C.ProductName = ProductName;
                Service1C.ProductVersion = myFileVersionInfo.ProductVersion;
                Service1C.ExePath = FileServer1C.FullName;

                ListInstalledServices.Add(Service1C);
            }


            FileInfo FileServerRepo = new FileInfo(Path.Combine(InstallLocation, "bin\\crserver.exe"));
            if (FileServerRepo.Exists)
            {
                FileVersionInfo myFileVersionInfo = FileVersionInfo.GetVersionInfo(FileServer1C.FullName);

                InstalledServices Service1C = new InstalledServices();

                Service1C.InstallLocation = InstallLocation;
                Service1C.ProductType = "CRServer";
                Service1C.ProductName = ProductName;
                Service1C.ProductVersion = myFileVersionInfo.ProductVersion;
                Service1C.ExePath = FileServer1C.FullName;

                ListInstalledServices.Add(Service1C);
            }

            FileInfo FileServerRas = new FileInfo(Path.Combine(InstallLocation, "bin\\ras.exe"));
            if (FileServerRas.Exists)
            {
                FileVersionInfo myFileVersionInfo = FileVersionInfo.GetVersionInfo(FileServer1C.FullName);

                InstalledServices Service1C = new InstalledServices();

                Service1C.InstallLocation = InstallLocation;
                Service1C.ProductType = "RASServer";
                Service1C.ProductName = ProductName;
                Service1C.ProductVersion = myFileVersionInfo.ProductVersion;
                Service1C.ExePath = FileServer1C.FullName;

                ListInstalledServices.Add(Service1C);
            }

        }

        public void GetListOfAllInstalledPlatforms()
        {
            StringBuilder sb = new StringBuilder(39);

            MSI_ERROR _error_ = MSI_ERROR.ERROR_SUCCESS;

            int index = 0;

            while (_error_ == MSI_ERROR.ERROR_SUCCESS)
            {

                if (MsiEnumProducts(index, sb) == 0)
                {
                    _error_ = MSI_ERROR.ERROR_SUCCESS;
                }
                else if (MsiEnumProducts(index, sb) == 234)
                {
                    _error_ = MSI_ERROR.ERROR_MORE_DATA;
                }
                else if (MsiEnumProducts(index, sb) == 259)
                {
                    _error_ = MSI_ERROR.ERROR_NO_MORE_ITEMS;
                }
                else if (MsiEnumProducts(index, sb) == 87)
                {
                    _error_ = MSI_ERROR.ERROR_INVALID_PARAMETER;
                }
                else if (MsiEnumProducts(index, sb) == 1610)
                {
                    _error_ = MSI_ERROR.ERROR_BAD_CONFIGURATION;
                }

                string productID = sb.ToString();

                if (_error_ == MSI_ERROR.ERROR_SUCCESS)
                {
                    string a1 = GetProductProperty(productID, "Publisher");
                    if (a1 == "1C")
                    {
                        string InstallLocation = GetProductProperty(productID, "InstallLocation");
                        string ProductName = GetProductProperty(productID, "ProductName");

                        AddAccesibleServices(InstallLocation, ProductName);
                    }

                }
                index += 1;
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

        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            RefreshListService();
        }
    }
}
