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




            /*
            Локальная(система)
            Локальная(служба)
            Сетевая(служба)
            */

            /*
    ExeFile.Text = Serv.ExeFile
    ClusterFiles.Text = Serv.ClusterFiles
    PortAgent.Text = Serv.PortAgent
    PortMngr.Text = Serv.PortMngr
    PortProcessBegin.Text = Serv.PortProcessBegin
    PortProcessEnd.Text = Serv.PortProcessEnd

    CheckBoxDebug.Checked = Serv.Debug

    'DescriptionService.Text = Serv.Description
    DisplayName.Text = Serv.DisplayName

    'Локальная(система)
    'Локальная(служба)
    'Сетевая(служба)

    'If Serv.User = "NT AUTHORITY\NetworkService" Then
    '    RadioButtonUser1.Checked = True
    '    TechUser.Text = TechUser.Items(2)

    'ElseIf Serv.User = "NT AUTHORITY\LocalService" Then
    '    RadioButtonUser1.Checked = True
    '    TechUser.Text = TechUser.Items(1)

    'Else


    If Serv.User = "LocalSystem" Then
        RadioButtonUser1.Checked = True
    Else
        RadioButtonUser2.Checked = True
        Login.Text = Serv.User
        Password.Text = ""
    End If

    If ItsAdd Then
        Text = "Добавление новой службы сервера 1С"
    ElseIf ItsEdit Then
        Text = "Изменение параметров существующей службы сервера 1С"
    End If
    */
        }
    }
}
