namespace SrvInstaller1C
{
    partial class AvailableServices
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
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.ListAllServices = new System.Windows.Forms.ListView();
            this.ItemServiceType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ItemServiceTypePresentation = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ItemAppPath = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ItemVersion = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.GroupBox2 = new System.Windows.Forms.GroupBox();
            this.Button2 = new System.Windows.Forms.Button();
            this.Button1 = new System.Windows.Forms.Button();
            this.ButtonAdd = new System.Windows.Forms.Button();
            this.GroupBox1.SuspendLayout();
            this.GroupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // GroupBox1
            // 
            this.GroupBox1.Controls.Add(this.ListAllServices);
            this.GroupBox1.Location = new System.Drawing.Point(12, 12);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Size = new System.Drawing.Size(889, 296);
            this.GroupBox1.TabIndex = 23;
            this.GroupBox1.TabStop = false;
            this.GroupBox1.Text = "Создать новую службу из числа установленных приложений?";
            // 
            // ListAllServices
            // 
            this.ListAllServices.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ListAllServices.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ItemServiceType,
            this.ItemServiceTypePresentation,
            this.ItemAppPath,
            this.ItemVersion});
            this.ListAllServices.FullRowSelect = true;
            this.ListAllServices.HideSelection = false;
            this.ListAllServices.Location = new System.Drawing.Point(6, 17);
            this.ListAllServices.MultiSelect = false;
            this.ListAllServices.Name = "ListAllServices";
            this.ListAllServices.Size = new System.Drawing.Size(877, 270);
            this.ListAllServices.TabIndex = 20;
            this.ListAllServices.UseCompatibleStateImageBehavior = false;
            this.ListAllServices.View = System.Windows.Forms.View.Details;
            this.ListAllServices.SelectedIndexChanged += new System.EventHandler(this.ListAllServices_SelectedIndexChanged);
            this.ListAllServices.DoubleClick += new System.EventHandler(this.ListAllServices_DoubleClick);
            // 
            // ItemServiceType
            // 
            this.ItemServiceType.Text = "Код службы";
            this.ItemServiceType.Width = 0;
            // 
            // ItemServiceTypePresentation
            // 
            this.ItemServiceTypePresentation.Text = "Вид службы";
            this.ItemServiceTypePresentation.Width = 216;
            // 
            // ItemAppPath
            // 
            this.ItemAppPath.Text = "Путь к исполняемому файлу";
            this.ItemAppPath.Width = 462;
            // 
            // ItemVersion
            // 
            this.ItemVersion.Text = "Версия приложения";
            this.ItemVersion.Width = 118;
            // 
            // GroupBox2
            // 
            this.GroupBox2.Controls.Add(this.Button2);
            this.GroupBox2.Controls.Add(this.Button1);
            this.GroupBox2.Controls.Add(this.ButtonAdd);
            this.GroupBox2.Location = new System.Drawing.Point(12, 311);
            this.GroupBox2.Name = "GroupBox2";
            this.GroupBox2.Size = new System.Drawing.Size(889, 69);
            this.GroupBox2.TabIndex = 24;
            this.GroupBox2.TabStop = false;
            this.GroupBox2.Text = "Или ввести все параметры вручную";
            // 
            // Button2
            // 
            this.Button2.Image = global::SrvInstaller1C.Properties.Resources.edit_add_3860;
            this.Button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Button2.Location = new System.Drawing.Point(594, 15);
            this.Button2.Name = "Button2";
            this.Button2.Size = new System.Drawing.Size(287, 48);
            this.Button2.TabIndex = 21;
            this.Button2.Text = "Новая служба сервера администрирования";
            this.Button2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Button2.UseVisualStyleBackColor = true;
            // 
            // Button1
            // 
            this.Button1.Image = global::SrvInstaller1C.Properties.Resources.edit_add_3860;
            this.Button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Button1.Location = new System.Drawing.Point(301, 15);
            this.Button1.Name = "Button1";
            this.Button1.Size = new System.Drawing.Size(287, 48);
            this.Button1.TabIndex = 21;
            this.Button1.Text = "Новая служба сервера хранилища";
            this.Button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Button1.UseVisualStyleBackColor = true;
            this.Button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // ButtonAdd
            // 
            this.ButtonAdd.Image = global::SrvInstaller1C.Properties.Resources.edit_add_3860;
            this.ButtonAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ButtonAdd.Location = new System.Drawing.Point(8, 15);
            this.ButtonAdd.Name = "ButtonAdd";
            this.ButtonAdd.Size = new System.Drawing.Size(287, 48);
            this.ButtonAdd.TabIndex = 21;
            this.ButtonAdd.Text = "Новая служба сервера приложений";
            this.ButtonAdd.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ButtonAdd.UseVisualStyleBackColor = true;
            this.ButtonAdd.Click += new System.EventHandler(this.ButtonAdd_Click);
            // 
            // AvailableServices
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(913, 393);
            this.Controls.Add(this.GroupBox1);
            this.Controls.Add(this.GroupBox2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "AvailableServices";
            this.Text = "AvailableServices";
            this.Load += new System.EventHandler(this.AvailableServices_Load);
            this.GroupBox1.ResumeLayout(false);
            this.GroupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.GroupBox GroupBox1;
        internal System.Windows.Forms.ListView ListAllServices;
        internal System.Windows.Forms.ColumnHeader ItemServiceType;
        internal System.Windows.Forms.ColumnHeader ItemServiceTypePresentation;
        internal System.Windows.Forms.ColumnHeader ItemAppPath;
        internal System.Windows.Forms.ColumnHeader ItemVersion;
        internal System.Windows.Forms.GroupBox GroupBox2;
        internal System.Windows.Forms.Button Button2;
        internal System.Windows.Forms.Button Button1;
        internal System.Windows.Forms.Button ButtonAdd;
    }
}