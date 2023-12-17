namespace LRes
{
    partial class Form1
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
            panel1 = new Panel();
            comboBox_DisplaySettingsInfo = new ComboBox();
            label1 = new Label();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(comboBox_DisplaySettingsInfo);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(12, 12);
            panel1.Name = "panel1";
            panel1.Size = new Size(776, 96);
            panel1.TabIndex = 0;
            // 
            // comboBox_DisplaySettingsInfo
            // 
            comboBox_DisplaySettingsInfo.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_DisplaySettingsInfo.FormattingEnabled = true;
            comboBox_DisplaySettingsInfo.Location = new Point(3, 18);
            comboBox_DisplaySettingsInfo.Name = "comboBox_DisplaySettingsInfo";
            comboBox_DisplaySettingsInfo.Size = new Size(770, 23);
            comboBox_DisplaySettingsInfo.TabIndex = 1;
            comboBox_DisplaySettingsInfo.SelectedIndexChanged += comboBox_DisplaySettingsInfo_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(3, 0);
            label1.Name = "label1";
            label1.Size = new Size(119, 15);
            label1.TabIndex = 0;
            label1.Text = "Available Resolutions";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(panel1);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private ComboBox comboBox_DisplaySettingsInfo;
        private Label label1;
    }
}
