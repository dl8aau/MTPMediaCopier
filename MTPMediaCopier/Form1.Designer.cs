
namespace MTPMediaCopier
{
    partial class Form1
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
            this.btn_findDevice = new System.Windows.Forms.Button();
            this.btn_selectFolder = new System.Windows.Forms.Button();
            this.txt_folder = new System.Windows.Forms.TextBox();
            this.btn_copy = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.cd_deviceName = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btn_findDevice
            // 
            this.btn_findDevice.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(29)))), ((int)(((byte)(56)))));
            this.btn_findDevice.FlatAppearance.BorderSize = 0;
            this.btn_findDevice.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_findDevice.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_findDevice.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(188)))), ((int)(((byte)(180)))), ((int)(((byte)(222)))));
            this.btn_findDevice.Location = new System.Drawing.Point(36, 77);
            this.btn_findDevice.Name = "btn_findDevice";
            this.btn_findDevice.Size = new System.Drawing.Size(160, 42);
            this.btn_findDevice.TabIndex = 0;
            this.btn_findDevice.Text = "Find Phone";
            this.btn_findDevice.UseVisualStyleBackColor = false;
            this.btn_findDevice.Click += new System.EventHandler(this.button1_Click);
            // 
            // btn_selectFolder
            // 
            this.btn_selectFolder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(29)))), ((int)(((byte)(56)))));
            this.btn_selectFolder.FlatAppearance.BorderSize = 0;
            this.btn_selectFolder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_selectFolder.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_selectFolder.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(188)))), ((int)(((byte)(180)))), ((int)(((byte)(222)))));
            this.btn_selectFolder.Location = new System.Drawing.Point(36, 141);
            this.btn_selectFolder.Name = "btn_selectFolder";
            this.btn_selectFolder.Size = new System.Drawing.Size(160, 42);
            this.btn_selectFolder.TabIndex = 1;
            this.btn_selectFolder.Text = "Select Folder";
            this.btn_selectFolder.UseVisualStyleBackColor = false;
            this.btn_selectFolder.Click += new System.EventHandler(this.button2_Click);
            // 
            // txt_folder
            // 
            this.txt_folder.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_folder.Location = new System.Drawing.Point(226, 146);
            this.txt_folder.Name = "txt_folder";
            this.txt_folder.Size = new System.Drawing.Size(261, 33);
            this.txt_folder.TabIndex = 3;
            // 
            // btn_copy
            // 
            this.btn_copy.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(29)))), ((int)(((byte)(56)))));
            this.btn_copy.FlatAppearance.BorderSize = 0;
            this.btn_copy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_copy.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_copy.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(188)))), ((int)(((byte)(180)))), ((int)(((byte)(222)))));
            this.btn_copy.Location = new System.Drawing.Point(276, 213);
            this.btn_copy.Name = "btn_copy";
            this.btn_copy.Size = new System.Drawing.Size(136, 48);
            this.btn_copy.TabIndex = 4;
            this.btn_copy.Text = "Copy";
            this.btn_copy.UseVisualStyleBackColor = false;
            this.btn_copy.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.FlatAppearance.BorderSize = 0;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Location = new System.Drawing.Point(503, 1);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(28, 23);
            this.button4.TabIndex = 5;
            this.button4.Text = "X";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // cd_deviceName
            // 
            this.cd_deviceName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cd_deviceName.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cd_deviceName.FormattingEnabled = true;
            this.cd_deviceName.Location = new System.Drawing.Point(226, 77);
            this.cd_deviceName.Name = "cd_deviceName";
            this.cd_deviceName.Size = new System.Drawing.Size(261, 34);
            this.cd_deviceName.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(188)))), ((int)(((byte)(180)))), ((int)(((byte)(222)))));
            this.label1.Location = new System.Drawing.Point(176, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(198, 26);
            this.label1.TabIndex = 7;
            this.label1.Text = "Image Backup Device";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(395, 273);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(136, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Provided to you by Vitoman";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(48)))), ((int)(((byte)(92)))));
            this.ClientSize = new System.Drawing.Size(530, 295);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cd_deviceName);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.btn_copy);
            this.Controls.Add(this.txt_folder);
            this.Controls.Add(this.btn_selectFolder);
            this.Controls.Add(this.btn_findDevice);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MTP";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_findDevice;
        private System.Windows.Forms.Button btn_selectFolder;
        private System.Windows.Forms.TextBox txt_folder;
        private System.Windows.Forms.Button btn_copy;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.ComboBox cd_deviceName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}

