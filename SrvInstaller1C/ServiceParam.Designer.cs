namespace SrvInstaller1C
{
    partial class ServiceParam
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Label9 = new System.Windows.Forms.Label();
            this.Label8 = new System.Windows.Forms.Label();
            this.Login = new System.Windows.Forms.TextBox();
            this.RadioButtonUser2 = new System.Windows.Forms.RadioButton();
            this.RadioButtonUser1 = new System.Windows.Forms.RadioButton();
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.Password = new System.Windows.Forms.TextBox();
            this.CheckBoxDebug = new System.Windows.Forms.CheckBox();
            this.Label3 = new System.Windows.Forms.Label();
            this.Label4 = new System.Windows.Forms.Label();
            this.Button3 = new System.Windows.Forms.Button();
            this.Label5 = new System.Windows.Forms.Label();
            this.Button2 = new System.Windows.Forms.Button();
            this.PortAgent = new System.Windows.Forms.MaskedTextBox();
            this.PortMngr = new System.Windows.Forms.MaskedTextBox();
            this.PortProcessEnd = new System.Windows.Forms.MaskedTextBox();
            this.PortProcessBegin = new System.Windows.Forms.MaskedTextBox();
            this.GroupBox2 = new System.Windows.Forms.GroupBox();
            this.Label6 = new System.Windows.Forms.Label();
            this.Label1 = new System.Windows.Forms.Label();
            this.Label2 = new System.Windows.Forms.Label();
            this.Button1 = new System.Windows.Forms.Button();
            this.ServiceName = new System.Windows.Forms.TextBox();
            this.DisplayName = new System.Windows.Forms.TextBox();
            this.Button6 = new System.Windows.Forms.Button();
            this.ExeFile = new System.Windows.Forms.TextBox();
            this.ClusterFiles = new System.Windows.Forms.TextBox();
            this.Label7 = new System.Windows.Forms.Label();
            this.Button4 = new System.Windows.Forms.Button();
            this.ButtonSave = new System.Windows.Forms.Button();
            this.GroupBox1.SuspendLayout();
            this.GroupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // Label9
            // 
            this.Label9.AutoSize = true;
            this.Label9.Location = new System.Drawing.Point(32, 101);
            this.Label9.Name = "Label9";
            this.Label9.Size = new System.Drawing.Size(45, 13);
            this.Label9.TabIndex = 17;
            this.Label9.Text = "Пароль";
            // 
            // Label8
            // 
            this.Label8.AutoSize = true;
            this.Label8.Location = new System.Drawing.Point(32, 76);
            this.Label8.Name = "Label8";
            this.Label8.Size = new System.Drawing.Size(38, 13);
            this.Label8.TabIndex = 17;
            this.Label8.Text = "Логин";
            // 
            // Login
            // 
            this.Login.Location = new System.Drawing.Point(81, 73);
            this.Login.Name = "Login";
            this.Login.Size = new System.Drawing.Size(134, 20);
            this.Login.TabIndex = 16;
            // 
            // RadioButtonUser2
            // 
            this.RadioButtonUser2.AutoSize = true;
            this.RadioButtonUser2.Location = new System.Drawing.Point(17, 49);
            this.RadioButtonUser2.Name = "RadioButtonUser2";
            this.RadioButtonUser2.Size = new System.Drawing.Size(161, 17);
            this.RadioButtonUser2.TabIndex = 15;
            this.RadioButtonUser2.TabStop = true;
            this.RadioButtonUser2.Text = "Отдельной учетной записи";
            this.RadioButtonUser2.UseVisualStyleBackColor = true;
            // 
            // RadioButtonUser1
            // 
            this.RadioButtonUser1.AutoSize = true;
            this.RadioButtonUser1.Location = new System.Drawing.Point(17, 29);
            this.RadioButtonUser1.Name = "RadioButtonUser1";
            this.RadioButtonUser1.Size = new System.Drawing.Size(129, 17);
            this.RadioButtonUser1.TabIndex = 15;
            this.RadioButtonUser1.TabStop = true;
            this.RadioButtonUser1.Text = "Локальной системы";
            this.RadioButtonUser1.UseVisualStyleBackColor = true;
            // 
            // GroupBox1
            // 
            this.GroupBox1.Controls.Add(this.Label9);
            this.GroupBox1.Controls.Add(this.Label8);
            this.GroupBox1.Controls.Add(this.Password);
            this.GroupBox1.Controls.Add(this.Login);
            this.GroupBox1.Controls.Add(this.RadioButtonUser2);
            this.GroupBox1.Controls.Add(this.RadioButtonUser1);
            this.GroupBox1.Location = new System.Drawing.Point(282, 161);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Size = new System.Drawing.Size(261, 123);
            this.GroupBox1.TabIndex = 32;
            this.GroupBox1.TabStop = false;
            this.GroupBox1.Text = "Вход от имени (можно не указывать для существующей службы)";
            // 
            // Password
            // 
            this.Password.Location = new System.Drawing.Point(81, 99);
            this.Password.Name = "Password";
            this.Password.PasswordChar = '*';
            this.Password.Size = new System.Drawing.Size(134, 20);
            this.Password.TabIndex = 16;
            this.Password.UseSystemPasswordChar = true;
            // 
            // CheckBoxDebug
            // 
            this.CheckBoxDebug.AutoSize = true;
            this.CheckBoxDebug.Location = new System.Drawing.Point(17, 290);
            this.CheckBoxDebug.Name = "CheckBoxDebug";
            this.CheckBoxDebug.Size = new System.Drawing.Size(185, 17);
            this.CheckBoxDebug.TabIndex = 31;
            this.CheckBoxDebug.Text = "Разрешить отладку на сервере";
            this.CheckBoxDebug.UseVisualStyleBackColor = true;
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.Location = new System.Drawing.Point(6, 21);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(103, 13);
            this.Label3.TabIndex = 11;
            this.Label3.Text = "Агента сервера 1С";
            // 
            // Label4
            // 
            this.Label4.AutoSize = true;
            this.Label4.Location = new System.Drawing.Point(6, 46);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(116, 13);
            this.Label4.TabIndex = 11;
            this.Label4.Text = "Менеджера кластера";
            // 
            // Button3
            // 
            this.Button3.Location = new System.Drawing.Point(138, 94);
            this.Button3.Name = "Button3";
            this.Button3.Size = new System.Drawing.Size(50, 23);
            this.Button3.TabIndex = 14;
            this.Button3.Text = "-1000";
            this.Button3.UseVisualStyleBackColor = true;
            // 
            // Label5
            // 
            this.Label5.AutoSize = true;
            this.Label5.Location = new System.Drawing.Point(6, 71);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(105, 13);
            this.Label5.TabIndex = 11;
            this.Label5.Text = "Рабочих процессов";
            // 
            // Button2
            // 
            this.Button2.Location = new System.Drawing.Point(195, 94);
            this.Button2.Name = "Button2";
            this.Button2.Size = new System.Drawing.Size(50, 23);
            this.Button2.TabIndex = 14;
            this.Button2.Text = "+1000";
            this.Button2.UseVisualStyleBackColor = true;
            // 
            // PortAgent
            // 
            this.PortAgent.Location = new System.Drawing.Point(138, 18);
            this.PortAgent.Mask = "00000";
            this.PortAgent.Name = "PortAgent";
            this.PortAgent.Size = new System.Drawing.Size(51, 20);
            this.PortAgent.TabIndex = 13;
            this.PortAgent.ValidatingType = typeof(int);
            // 
            // PortMngr
            // 
            this.PortMngr.Location = new System.Drawing.Point(138, 44);
            this.PortMngr.Mask = "00000";
            this.PortMngr.Name = "PortMngr";
            this.PortMngr.Size = new System.Drawing.Size(51, 20);
            this.PortMngr.TabIndex = 13;
            this.PortMngr.ValidatingType = typeof(int);
            // 
            // PortProcessEnd
            // 
            this.PortProcessEnd.Location = new System.Drawing.Point(195, 68);
            this.PortProcessEnd.Mask = "00000";
            this.PortProcessEnd.Name = "PortProcessEnd";
            this.PortProcessEnd.Size = new System.Drawing.Size(50, 20);
            this.PortProcessEnd.TabIndex = 13;
            this.PortProcessEnd.ValidatingType = typeof(int);
            // 
            // PortProcessBegin
            // 
            this.PortProcessBegin.Location = new System.Drawing.Point(138, 68);
            this.PortProcessBegin.Mask = "00000";
            this.PortProcessBegin.Name = "PortProcessBegin";
            this.PortProcessBegin.Size = new System.Drawing.Size(51, 20);
            this.PortProcessBegin.TabIndex = 13;
            this.PortProcessBegin.ValidatingType = typeof(int);
            // 
            // GroupBox2
            // 
            this.GroupBox2.Controls.Add(this.Label3);
            this.GroupBox2.Controls.Add(this.Label4);
            this.GroupBox2.Controls.Add(this.Button3);
            this.GroupBox2.Controls.Add(this.Label5);
            this.GroupBox2.Controls.Add(this.Button2);
            this.GroupBox2.Controls.Add(this.PortAgent);
            this.GroupBox2.Controls.Add(this.PortMngr);
            this.GroupBox2.Controls.Add(this.PortProcessEnd);
            this.GroupBox2.Controls.Add(this.PortProcessBegin);
            this.GroupBox2.Location = new System.Drawing.Point(15, 161);
            this.GroupBox2.Name = "GroupBox2";
            this.GroupBox2.Size = new System.Drawing.Size(261, 123);
            this.GroupBox2.TabIndex = 33;
            this.GroupBox2.TabStop = false;
            this.GroupBox2.Text = "Рабочие порты";
            // 
            // Label6
            // 
            this.Label6.AutoSize = true;
            this.Label6.Location = new System.Drawing.Point(14, 44);
            this.Label6.Name = "Label6";
            this.Label6.Size = new System.Drawing.Size(149, 13);
            this.Label6.TabIndex = 27;
            this.Label6.Text = "Отображаемое имя службы";
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(15, 83);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(152, 13);
            this.Label1.TabIndex = 28;
            this.Label1.Text = "Путь к исполняемому файлу";
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Location = new System.Drawing.Point(15, 119);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(139, 13);
            this.Label2.TabIndex = 29;
            this.Label2.Text = "Каталог файлов кластера";
            // 
            // Button1
            // 
            this.Button1.Location = new System.Drawing.Point(472, 133);
            this.Button1.Name = "Button1";
            this.Button1.Size = new System.Drawing.Size(71, 23);
            this.Button1.TabIndex = 25;
            this.Button1.Text = "Выбрать";
            this.Button1.UseVisualStyleBackColor = true;
            // 
            // ServiceName
            // 
            this.ServiceName.BackColor = System.Drawing.SystemColors.Window;
            this.ServiceName.Location = new System.Drawing.Point(12, 21);
            this.ServiceName.Name = "ServiceName";
            this.ServiceName.Size = new System.Drawing.Size(531, 20);
            this.ServiceName.TabIndex = 21;
            // 
            // DisplayName
            // 
            this.DisplayName.BackColor = System.Drawing.SystemColors.Window;
            this.DisplayName.Location = new System.Drawing.Point(12, 60);
            this.DisplayName.Name = "DisplayName";
            this.DisplayName.Size = new System.Drawing.Size(531, 20);
            this.DisplayName.TabIndex = 22;
            // 
            // Button6
            // 
            this.Button6.Location = new System.Drawing.Point(472, 97);
            this.Button6.Name = "Button6";
            this.Button6.Size = new System.Drawing.Size(71, 23);
            this.Button6.TabIndex = 26;
            this.Button6.Text = "Выбрать";
            this.Button6.UseVisualStyleBackColor = true;
            // 
            // ExeFile
            // 
            this.ExeFile.Location = new System.Drawing.Point(12, 99);
            this.ExeFile.Name = "ExeFile";
            this.ExeFile.Size = new System.Drawing.Size(454, 20);
            this.ExeFile.TabIndex = 23;
            // 
            // ClusterFiles
            // 
            this.ClusterFiles.Location = new System.Drawing.Point(12, 135);
            this.ClusterFiles.Name = "ClusterFiles";
            this.ClusterFiles.Size = new System.Drawing.Size(454, 20);
            this.ClusterFiles.TabIndex = 24;
            // 
            // Label7
            // 
            this.Label7.AutoSize = true;
            this.Label7.Location = new System.Drawing.Point(14, 5);
            this.Label7.Name = "Label7";
            this.Label7.Size = new System.Drawing.Size(68, 13);
            this.Label7.TabIndex = 30;
            this.Label7.Text = "Код службы";
            // 
            // Button4
            // 
            this.Button4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Button4.Image = global::SrvInstaller1C.Properties.Resources.stop;
            this.Button4.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Button4.Location = new System.Drawing.Point(282, 313);
            this.Button4.Name = "Button4";
            this.Button4.Size = new System.Drawing.Size(261, 48);
            this.Button4.TabIndex = 19;
            this.Button4.Text = "Отменить операцию";
            this.Button4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Button4.UseVisualStyleBackColor = true;
            // 
            // ButtonSave
            // 
            this.ButtonSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ButtonSave.Image = global::SrvInstaller1C.Properties.Resources.save_all;
            this.ButtonSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ButtonSave.Location = new System.Drawing.Point(12, 313);
            this.ButtonSave.Name = "ButtonSave";
            this.ButtonSave.Size = new System.Drawing.Size(264, 48);
            this.ButtonSave.TabIndex = 20;
            this.ButtonSave.Text = "Сохранить изменения";
            this.ButtonSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ButtonSave.UseVisualStyleBackColor = true;
            // 
            // ServiceParam
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(553, 371);
            this.Controls.Add(this.Button4);
            this.Controls.Add(this.GroupBox1);
            this.Controls.Add(this.ButtonSave);
            this.Controls.Add(this.CheckBoxDebug);
            this.Controls.Add(this.GroupBox2);
            this.Controls.Add(this.Label6);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.Button1);
            this.Controls.Add(this.ServiceName);
            this.Controls.Add(this.DisplayName);
            this.Controls.Add(this.Button6);
            this.Controls.Add(this.ExeFile);
            this.Controls.Add(this.ClusterFiles);
            this.Controls.Add(this.Label7);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "ServiceParam";
            this.Text = "Параметры запуска службы сервера 1С";
            this.Load += new System.EventHandler(this.ServiceParam_Load);
            this.GroupBox1.ResumeLayout(false);
            this.GroupBox1.PerformLayout();
            this.GroupBox2.ResumeLayout(false);
            this.GroupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Button Button4;
        internal System.Windows.Forms.Label Label9;
        internal System.Windows.Forms.Label Label8;
        internal System.Windows.Forms.TextBox Login;
        internal System.Windows.Forms.RadioButton RadioButtonUser2;
        internal System.Windows.Forms.RadioButton RadioButtonUser1;
        internal System.Windows.Forms.GroupBox GroupBox1;
        internal System.Windows.Forms.TextBox Password;
        internal System.Windows.Forms.Button ButtonSave;
        internal System.Windows.Forms.CheckBox CheckBoxDebug;
        internal System.Windows.Forms.Label Label3;
        internal System.Windows.Forms.Label Label4;
        internal System.Windows.Forms.Button Button3;
        internal System.Windows.Forms.Label Label5;
        internal System.Windows.Forms.Button Button2;
        internal System.Windows.Forms.MaskedTextBox PortAgent;
        internal System.Windows.Forms.MaskedTextBox PortMngr;
        internal System.Windows.Forms.MaskedTextBox PortProcessEnd;
        internal System.Windows.Forms.MaskedTextBox PortProcessBegin;
        internal System.Windows.Forms.GroupBox GroupBox2;
        internal System.Windows.Forms.Label Label6;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.Button Button1;
        internal System.Windows.Forms.TextBox ServiceName;
        internal System.Windows.Forms.TextBox DisplayName;
        internal System.Windows.Forms.Button Button6;
        internal System.Windows.Forms.TextBox ExeFile;
        internal System.Windows.Forms.TextBox ClusterFiles;
        internal System.Windows.Forms.Label Label7;
    }
}