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
using System.IO;

namespace SrvInstaller1C
{
    public partial class ServiceParam : Form
    {
        public Service1C Serv;
        public bool ItsAdd = false;
        public bool ItsEdit = false;

        public ServiceParam()
        {
            InitializeComponent();
        }

        private void ServiceParam_Load(object sender, EventArgs e)
        {
            ServiceName.Text      = Serv.Name;
            ExeFile.Text          = Serv.ExeFile;
            ClusterFiles.Text     = Serv.ClusterFiles;
            PortAgent.Text        = Serv.PortAgent.ToString();
            PortMngr.Text         = Serv.PortMngr.ToString();
            PortProcessBegin.Text = Serv.PortProcessBegin.ToString();
            PortProcessEnd.Text   = Serv.PortProcessEnd.ToString();
            CheckBoxDebug.Checked = Serv.Debug;
            DisplayName.Text      = Serv.DisplayName;

            if (Serv.User == "LocalSystem")
            {
                RadioButtonUser1.Checked = true;
            }
            else
            {
                RadioButtonUser2.Checked = true;
                Login.Text = Serv.User;
                Password.Text = "";
            }

            if (ItsAdd)
                Text = "Добавление новой службы сервера 1С";
            else if (ItsEdit)
                Text = "Изменение параметров существующей службы сервера 1С";
        }

        private void Button6_Click(object sender, EventArgs e)
        {
            OpenFileDialog.FileName = ExeFile.Text;
            OpenFileDialog.ShowDialog();
            ExeFile.Text = OpenFileDialog.FileName;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog.RootFolder = Environment.SpecialFolder.MyComputer;
            FolderBrowserDialog.SelectedPath = ClusterFiles.Text;
            FolderBrowserDialog.ShowDialog();
            ClusterFiles.Text = FolderBrowserDialog.SelectedPath;
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            PortAgent.Text = (Convert.ToInt32(PortAgent.Text) - 1000).ToString();
            PortMngr.Text = (Convert.ToInt32(PortMngr.Text) - 1000).ToString();
            PortProcessBegin.Text = (Convert.ToInt32(PortProcessBegin.Text) - 1000).ToString();
            PortProcessEnd.Text = (Convert.ToInt32(PortProcessEnd.Text) - 1000).ToString();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            PortAgent.Text = (Convert.ToInt32(PortAgent.Text) + 1000).ToString();
            PortMngr.Text = (Convert.ToInt32(PortMngr.Text) + 1000).ToString();
            PortProcessBegin.Text = (Convert.ToInt32(PortProcessBegin.Text) + 1000).ToString();
            PortProcessEnd.Text = (Convert.ToInt32(PortProcessEnd.Text) + 1000).ToString();
        }

        public string GetNewNameForService()
        {
            string result = "";

            string BaseName = "1C:Enterprise 8 Server Agent #";
            int i = 1;

            result = BaseName + i.ToString();

            while (!CheckNameForService(result))
            {
                i++;
                result = BaseName + i.ToString();
            }

            return result;
        }

        public bool CheckNameForService(string Name)
        {
            ManagementObjectSearcher search = new ManagementObjectSearcher("SELECT * FROM Win32_Service WHERE Name = '" + Name + "'");
            return (search.Get().Count == 0);
        }

        public void SetDefaultColor()
        {
            DisplayName.BackColor = Color.White;
            ExeFile.BackColor = Color.White;
            ClusterFiles.BackColor = Color.White;

            PortAgent.BackColor = Color.White;
            PortMngr.BackColor = Color.White;
            PortProcessBegin.BackColor = Color.White;
            PortProcessEnd.BackColor = Color.White;
        }

        private void ButtonSave_Click(object sender, EventArgs e)
        {
            SetDefaultColor();

            if (string.IsNullOrWhiteSpace(DisplayName.Text))
            {
                DisplayName.BackColor = Color.Pink;
                MessageBox.Show("Отображаемое имя службы должно быть указано");
                return;
            }

            if (ItsAdd)
            {
                ManagementObjectSearcher search = new ManagementObjectSearcher("SELECT * FROM Win32_Service WHERE Name = '" + DisplayName.Text + "'");
                if (search.Get().Count > 0)
                {
                    DisplayName.BackColor = Color.Pink;
                    MessageBox.Show("Служба с таким именем уже зарегистрирована. Укажите другое наименование.");
                    return;
                }
            }

            if (string.IsNullOrWhiteSpace(ExeFile.Text))
            {
                ExeFile.BackColor = Color.Pink;
                MessageBox.Show("Путь к исполняемому файлу должен быть указан");
                return;
            }

            if (!File.Exists(ExeFile.Text))
            {
                ExeFile.BackColor = Color.Pink;
                MessageBox.Show("Исполняемый файл не существует");
                return;
            }

            if (string.IsNullOrWhiteSpace(ClusterFiles.Text))
            {
                ClusterFiles.BackColor = Color.Pink;
                MessageBox.Show("Путь к каталогу файлов кластера должен быть указан");
                return;
            }

            if (PortProcessEnd.Text == "0" || PortProcessBegin.Text == "0" || PortAgent.Text == "0" || PortMngr.Text == "0")
            {
                PortAgent.BackColor = Color.Pink;
                PortMngr.BackColor = Color.Pink;
                PortProcessBegin.BackColor = Color.Pink;
                PortProcessEnd.BackColor = Color.Pink;

                MessageBox.Show("Значения портов агента сервера, менеджера кластера и рабочих процессов должны быть указаны");
                return;
            }

            if (!(Convert.ToInt32(PortProcessEnd.Text) > Convert.ToInt32(PortProcessBegin.Text)))
            {
                PortProcessEnd.BackColor = Color.Pink;
                PortProcessBegin.BackColor = Color.Pink;
                MessageBox.Show("Конечный порт рабочего процесса должен быть больше начального порта");
                return;
            }

            string PathName = "" + ExeFile.Text + "\" {0} -srvc -agent -regport {1} -port {2} -range {3}:{4} -d \"{5}\"";
            // condition ? consequent : alternative

            PathName = String.Format(PathName, CheckBoxDebug.Checked ? "-debug" : "", PortMngr.Text, PortAgent.Text, PortProcessBegin.Text, PortProcessEnd.Text, ClusterFiles.Text);

            string lpDependencies = "Tcpip" + Char.MinValue + "Dnscache" + Char.MinValue + "lanmanworkstation" + Char.MinValue + "lanmanserver";

            string User = "";
            string Pwd = "";

            if (RadioButtonUser1.Checked)
            {
                User = "LocalSystem";
            }
            else
            {
                User = Login.Text;
                Pwd = Password.Text;
            }

            if (ItsAdd)
            {
                string ServName = GetNewNameForService();
            }

        }
    }
}
