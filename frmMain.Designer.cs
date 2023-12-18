namespace LRes
{
    partial class frmMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            panel1 = new Panel();
            label5 = new Label();
            btnTest = new Button();
            comboBox_DisplayProfiles = new ComboBox();
            label1 = new Label();
            panel2 = new Panel();
            label4 = new Label();
            tbWorkingDirectory = new TextBox();
            label3 = new Label();
            btnBrowse = new Button();
            tbFilename = new TextBox();
            label2 = new Label();
            dlgOpenFile = new OpenFileDialog();
            tmrUiMonitor = new System.Windows.Forms.Timer(components);
            btnSave = new Button();
            label6 = new Label();
            tbProcToMon = new TextBox();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BorderStyle = BorderStyle.Fixed3D;
            panel1.Controls.Add(label5);
            panel1.Controls.Add(btnTest);
            panel1.Controls.Add(comboBox_DisplayProfiles);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(12, 12);
            panel1.Name = "panel1";
            panel1.Size = new Size(817, 112);
            panel1.TabIndex = 0;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.ForeColor = Color.DarkGray;
            label5.Location = new Point(25, 17);
            label5.Name = "label5";
            label5.Size = new Size(138, 15);
            label5.TabIndex = 5;
            label5.Text = "Available Display Profiles";
            // 
            // btnTest
            // 
            btnTest.Location = new Point(735, 35);
            btnTest.Name = "btnTest";
            btnTest.Size = new Size(75, 23);
            btnTest.TabIndex = 2;
            btnTest.Text = "Test";
            btnTest.UseVisualStyleBackColor = true;
            btnTest.Click += btnTest_Click;
            // 
            // comboBox_DisplayProfiles
            // 
            comboBox_DisplayProfiles.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_DisplayProfiles.FormattingEnabled = true;
            comboBox_DisplayProfiles.Location = new Point(25, 35);
            comboBox_DisplayProfiles.Name = "comboBox_DisplayProfiles";
            comboBox_DisplayProfiles.Size = new Size(704, 23);
            comboBox_DisplayProfiles.TabIndex = 1;
            comboBox_DisplayProfiles.SelectedIndexChanged += comboBox_DisplayProfiles_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(3, 0);
            label1.Name = "label1";
            label1.Size = new Size(93, 17);
            label1.TabIndex = 0;
            label1.Text = "Display Profile";
            // 
            // panel2
            // 
            panel2.AllowDrop = true;
            panel2.BorderStyle = BorderStyle.Fixed3D;
            panel2.Controls.Add(tbProcToMon);
            panel2.Controls.Add(label6);
            panel2.Controls.Add(label4);
            panel2.Controls.Add(tbWorkingDirectory);
            panel2.Controls.Add(label3);
            panel2.Controls.Add(btnBrowse);
            panel2.Controls.Add(tbFilename);
            panel2.Controls.Add(label2);
            panel2.Location = new Point(12, 137);
            panel2.Name = "panel2";
            panel2.Size = new Size(817, 162);
            panel2.TabIndex = 1;
            panel2.DragEnter += panel2_DragEnter;
            panel2.DragOver += panel2_DragOver;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.ForeColor = Color.DarkGray;
            label4.Location = new Point(25, 56);
            label4.Name = "label4";
            label4.Size = new Size(103, 15);
            label4.TabIndex = 6;
            label4.Text = "Working Directory";
            // 
            // tbWorkingDirectory
            // 
            tbWorkingDirectory.Enabled = false;
            tbWorkingDirectory.Location = new Point(25, 74);
            tbWorkingDirectory.Name = "tbWorkingDirectory";
            tbWorkingDirectory.Size = new Size(785, 23);
            tbWorkingDirectory.TabIndex = 5;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.ForeColor = Color.DarkGray;
            label3.Location = new Point(25, 17);
            label3.Name = "label3";
            label3.Size = new Size(55, 15);
            label3.TabIndex = 4;
            label3.Text = "Filename";
            // 
            // btnBrowse
            // 
            btnBrowse.Location = new Point(776, 29);
            btnBrowse.Name = "btnBrowse";
            btnBrowse.Size = new Size(34, 23);
            btnBrowse.TabIndex = 3;
            btnBrowse.Text = "...";
            btnBrowse.UseVisualStyleBackColor = true;
            btnBrowse.Click += btnBrowse_Click;
            // 
            // tbFilename
            // 
            tbFilename.Location = new Point(25, 30);
            tbFilename.Name = "tbFilename";
            tbFilename.Size = new Size(745, 23);
            tbFilename.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(3, 0);
            label2.Name = "label2";
            label2.Size = new Size(103, 17);
            label2.TabIndex = 1;
            label2.Text = "Program Profile";
            // 
            // dlgOpenFile
            // 
            dlgOpenFile.Filter = "Executable Files|*.exe|Link Files|*.lnk";
            dlgOpenFile.InitialDirectory = "C:\\";
            dlgOpenFile.ShowHiddenFiles = true;
            dlgOpenFile.Title = "Select Executable";
            dlgOpenFile.FileOk += dlgOpenFile_FileOk;
            // 
            // tmrUiMonitor
            // 
            tmrUiMonitor.Enabled = true;
            tmrUiMonitor.Tick += tmrUiMonitor_Tick;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(12, 425);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(75, 23);
            btnSave.TabIndex = 2;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.ForeColor = Color.DarkGray;
            label6.Location = new Point(25, 100);
            label6.Name = "label6";
            label6.Size = new Size(107, 15);
            label6.TabIndex = 7;
            label6.Text = "Process to Monitor";
            // 
            // tbProcToMon
            // 
            tbProcToMon.Location = new Point(25, 118);
            tbProcToMon.Name = "tbProcToMon";
            tbProcToMon.Size = new Size(785, 23);
            tbProcToMon.TabIndex = 8;
            // 
            // frmMain
            // 
            AllowDrop = true;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(841, 450);
            Controls.Add(btnSave);
            Controls.Add(panel2);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            MaximizeBox = false;
            Name = "frmMain";
            Text = "LRes (c) Leo C. Bergamo";
            Load += frmMain_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private ComboBox comboBox_DisplayProfiles;
        private Label label1;
        private Button btnTest;
        private Panel panel2;
        private TextBox tbFilename;
        private Label label2;
        private Button btnBrowse;
        private OpenFileDialog dlgOpenFile;
        private Label label3;
        private Label label4;
        private TextBox tbWorkingDirectory;
        private Label label5;
        private System.Windows.Forms.Timer tmrUiMonitor;
        private Button btnSave;
        private TextBox tbProcToMon;
        private Label label6;
    }
}
